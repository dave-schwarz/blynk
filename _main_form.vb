'**************************************************
'*
'*  blynk lync light for blink(1)
'*      talks to lync and sets the blink(1) to a color based on either status of call state
'*
'*  Version:    1.0
'*  Date:       November 2014
'*  Author:     David Schwarz (dave.schwarz@gmail.com)
'*  
'*  This work is licensed under the Creative Commons Attribution-ShareAlike 4.0 
'*  International License. To view a copy of this license, 
'*  visit http://creativecommons.org/licenses/by-sa/4.0/.
'*
'***************************************************

'*************************************************       
' various class info is loaded
' we need a number of lync classes and the blinkLib class loaded as well

Imports Microsoft.Lync.Model
Imports Microsoft.Lync.Model.Conversation
Imports Microsoft.Lync.Model.Conversation.AudioVideo
Imports Microsoft.Win32
Imports System
Imports System.Threading
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Timers

Imports Blink1Lib
Imports Lync = Microsoft.Lync.Model.Conversation


Public Class _initial_Form
    '*************************************************       
    ' these two definitiations are used for callbacks when lync call status changes

    Public WithEvents _ConvMgr As Microsoft.Lync.Model.Conversation.ConversationManager
    Public WithEvents _Conv As Conversation

    Dim _Client = LyncClient.GetClient()
    Dim _Contact As Microsoft.Lync.Model.Contact
    Dim _blink1 As Blink1
    Dim _Only_Red As Integer
    Dim _Enable_Presence As Integer
    Dim _Enable_Call_Status As Integer
    ' Dim _new_blink_color As Color


    '*************************************************       
    'everything starts here 

    Private Sub form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim count As Integer
        Dim serial As String


        '*************************************************        ' 
        ' setup the form, ensure it stats up minimised, etc
        Me.WindowState = FormWindowState.Minimized

        '*************************************************
        ' read local settings and set flags and varibles to correct state on form and in code
        ' there are two ways to track the lync client state, via presence and via call status
        ' these settings saved to track which type off events we want to track
        ' if the user has a laptop and unplug unexpectadly, the blink can be left on in a weird state
        ' trackikng just call status events, means this is less likely
        ' the only red flag also needs to be set on laptops other wise the blink can get left set on green
        ' for days on end

        ' here we will set the save defaults on the main form

        ' enable presence will change color of blink based on calander entries or calls
        _radio_button_Presence.Checked = My.Settings.Enable_Presense

        'call status only uses changes in the state when a call is made
        _radio_button_Call_Status.Checked = My.Settings.Enable_Call_status

        ' red only, will only turn the blink into red, handles laptops that may be unpluged and the blink stays red for ever
        _chkbox_Never_Green.CheckState = My.Settings.Never_Green

        ' auto start on logon
        _Chk_box_Auto_start.CheckState = My.Settings.Auto_Start

        '*********************************************************
        ' wrap the lync initation so if we get an error we pop it up
        ' initalise both types, as its simpler to set them both up at the start and filter out events later
        ' rather than trying to work out what should be turned on or off, and changing it when buttons are clicked
        Try
            'initialise lync presense stuff
            _Contact = _Client.GetClient().Self.Contact
            AddHandler _Contact.ContactInformationChanged, AddressOf _Self_ContactInformationChanged

            'initalise lync call conversation change state 
            _ConvMgr = _Client.ConversationManager
        Catch generatedExceptionName As ClientNotFoundException
            'MessageBox.Show("Error: Lync client is not running")
            'Application.Exit()
        End Try

        '*********************************************************
        ' blink initialisation
        ' check if a blink is installed, and if so initalise it
        ' doesn't handle the blink being run by another copy of the program (yet)
        ' or blink not installed

        _blink1 = New Blink1
        _blink1.open()
        count = _blink1.enumerate()
        _label_Status.Text = ("Detected " + CStr(count) + " Blink(1) devices")
        serial = CStr(_blink1.getCachedSerial(0))
        
        'finished initalisation
        'turn off blink (need to fix and set it to correct color based on current state and setting)
        _blink1.close()
        _blink1 = Nothing

        If (count = 0) Then
            MessageBox.Show("Error: No blink identified, do you have another tool running such as blink Control ?")
            Application.Exit()
        End If

        'if we find no blinks pop up an error message and exit
        ' set color to green (as a guess)
        Change_Blink_Color(Color.Green)
    End Sub

    Private Sub Form_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Change_Blink_Color(Color.Black)
        _Flash_Timer.Enabled = False
    End Sub


    '**********************************************************
    ' code to handle color changes based on global flags etc, called with color to change to

    Private Sub Change_Blink_Color(ByVal _New_Blink_Color As Color)

        ' setback ground color in the color status box
        ' this will always match the current state (unlike the blink, whihcmay be on or off based on settings
        _Color_Status_Box.BackColor = _New_Blink_Color
        'Open the blink
        _blink1 = New Blink1
        _blink1.open()
        'turn off blinking
        _Stop_Flash_Blink_Color()
        ' if only never green flag set we never go green, otherwise we go what ever color is called
        ' used to support laptops that are unpluged and leave the blink in a green state
        If _blink1 IsNot Nothing Then
            If _chkbox_Never_Green.CheckState = CheckState.Checked Then
                If (_New_Blink_Color = Color.Green) Then
                    _blink1.setRGB(0, 0, 0)
                Else
                    _blink1.setRGB(_New_Blink_Color.R, _New_Blink_Color.G, _New_Blink_Color.B)
                End If
            Else ' if not set we go what ever color we need to go
                _blink1.setRGB(_New_Blink_Color.R, _New_Blink_Color.G, _New_Blink_Color.B)
            End If
        End If
        _blink1.close()
        _blink1 = Nothing
    End Sub

    '**************************************************************
    ' code to handle events like phone rining, bascially flashes the blink
    ' while we are waiting for state changes

    Private Sub _Start_Flash_Blink_Color(ByVal _New_Blink_Color As Color)

        '**************************************************************
        ' setup the flash management for the following settings
        ' transfer color via the tag attribute
        'fire every second
        ' and then enable

        _Flash_Timer.Interval = 2000
        _Flash_Timer.AutoReset = True
        _Flash_Timer.Enabled = True


    End Sub
    '**************************************************
    ' turn off the timer thats blinking

    Private Sub _Stop_Flash_Blink_Color()
        Try
            _Flash_Timer.Enabled = False
            _label_Status.Text = ""
        Catch
            '
        End Try
    End Sub
    '***************************************************
    ' handles the events that fire every cycle
    ' effectively blinks the blink

    Private Sub _Flash_Timer_Elapsed(sender As Object, e As ElapsedEventArgs) Handles _Flash_Timer.Elapsed
        'Private Sub _Flash_Timer_Tick(sender As Object, e As EventArgs) Handles _Flash_Timer.Tick
        'Private Shared Sub _Flash_Timer_Tick(sender As Object, e As EventArgs)
        'Debug.Print("tick")
        Dim _new_blink_color As Color '= _Flash_Timer.Tag
        _new_blink_color = Color.Orange
        ' open the blink
        _blink1 = New Blink1
        _blink1.open()


        '_new_blink_color = Color.Blue
        'Beep()
        _Color_Status_Box.BackColor = _new_blink_color
        _blink1.setRGB(_new_blink_color.R, _new_blink_color.G, _new_blink_color.B)
        _blink1.fadeToRGB(1000, 0, 0, 0)
        _Color_Status_Box.BackColor = Color.Black
        _label_Status.Text = ""
        _blink1.close()
        _blink1 = Nothing
    End Sub


    ' Code to handle being minimised
    Private Sub Form1_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        If Me.WindowState = FormWindowState.Minimized Then
            _Notify_Icon.Visible = True
            Me.Hide()
            Me.ShowInTaskbar = False
            _Notify_Icon.BalloonTipText = "Blynk minimised here"
            _Notify_Icon.ShowBalloonTip(50)
        End If
    End Sub

    'and maximised
    Private Sub _Notify_Icon_singleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Notify_Icon.MouseClick
        Me.Show()
        Me.WindowState = FormWindowState.Normal
        _Notify_Icon.Visible = False
        Me.ShowInTaskbar = True
    End Sub

    ' handle state change callbacks
    Private Sub _Self_ContactInformationChanged(sender As Object, e As ContactInformationChangedEventArgs)
        ' only do this if the Presence check box is ticked
        If _radio_button_Presence.Checked = True Then

            If (e.ChangedContactInformation.Contains(ContactInformationType.Availability)) Then

                Dim currentAvailability = sender.GetContactInformation(ContactInformationType.Availability)

                'Select Case e.NewState
                Select Case currentAvailability
                    Case ContactAvailability.Away
                        Change_Blink_Color(Color.Yellow)
                    Case ContactAvailability.Busy
                        'insert code here
                        Change_Blink_Color(Color.Red)
                    Case ContactAvailability.BusyIdle
                        'insert code here
                        Change_Blink_Color(Color.Purple)
                    Case ContactAvailability.DoNotDisturb
                        'insert code here
                        Change_Blink_Color(Color.Yellow)
                    Case ContactAvailability.Free
                        'insert code here
                        Change_Blink_Color(Color.Green)
                    Case ContactAvailability.FreeIdle
                        'insert code here
                        Change_Blink_Color(Color.Green)
                    Case ContactAvailability.Invalid
                        'insert code here
                        Change_Blink_Color(Color.Black)
                    Case ContactAvailability.None
                        'insert code here
                        Change_Blink_Color(Color.Black)
                    Case ContactAvailability.Offline
                        'insert code here
                        Change_Blink_Color(Color.Blue)
                    Case ContactAvailability.TemporarilyAway
                        'insert code here
                        Change_Blink_Color(Color.Yellow)

                End Select

            End If
        End If
    End Sub


    'create a new hook everytime a new conversation is started (I assume this is torn down automatically when the call completes
    Private Sub _ConvMgr_ConversationAdded(ByVal sender As Object, ByVal e As Microsoft.Lync.Model.Conversation.ConversationManagerEventArgs) Handles _ConvMgr.ConversationAdded
        AddHandler e.Conversation.Modalities(ModalityTypes.AudioVideo).ModalityStateChanged, AddressOf _self_AVModalityStateChanged
    End Sub

    'handle the events arround phone calls
    Private Sub _self_AVModalityStateChanged(sender As Object, e As ModalityStateChangedEventArgs)
        ' only do this if the Presence check box is ticked
        '_Stop_Flash_Blink_Color()
        'If _radio_button_Call_Status.Checked = True Then
        Select Case e.NewState
            Case ModalityState.Notified
                'Insert your code here
                _Start_Flash_Blink_Color(Color.Yellow)
            Case ModalityState.Connected
                Change_Blink_Color(Color.Red)
            Case ModalityState.ConnectingToCaller
                Change_Blink_Color(Color.Yellow)
            Case ModalityState.Connecting
                'Insert your code here
                Change_Blink_Color(Color.Yellow)
            Case ModalityState.Joining
                'Insert your code here
                Change_Blink_Color(Color.Yellow)
            Case ModalityState.Transferring
                'Insert your code here
                Change_Blink_Color(Color.Yellow)
            Case ModalityState.Disconnected
                'Insert your code here
                Change_Blink_Color(Color.Green)
            Case ModalityState.Disconnecting
                'Insert your code here
                Change_Blink_Color(Color.Green)
            Case ModalityState.Forwarding
                'Insert your code here
                Change_Blink_Color(Color.Yellow)
            Case ModalityState.OnHold
                'Insert your code here
                Change_Blink_Color(Color.Yellow)
            Case ModalityState.Suspended
                'Insert your code here
                Change_Blink_Color(Color.Yellow)
        End Select
        'End If
    End Sub


    Private Sub _radio_button_Presence_CheckedChanged(sender As Object, e As EventArgs) Handles _radio_button_Presence.CheckedChanged

        My.Settings.Enable_Presense = _radio_button_Presence.Checked
        My.Settings.Save()
    End Sub

    Private Sub _radio_button_Call_Status_CheckedChanged(sender As Object, e As EventArgs) Handles _radio_button_Call_Status.CheckedChanged

        My.Settings.Enable_Call_status = _radio_button_Call_Status.Checked
        My.Settings.Save()
    End Sub



    Private Sub _chkbox_Never_Green_CheckedChanged(sender As Object, e As EventArgs) Handles _chkbox_Never_Green.CheckedChanged

        My.Settings.Never_Green = _chkbox_Never_Green.CheckState
        My.Settings.Save()
        Change_Blink_Color(Color.Black)
    End Sub

    Private Sub _Chk_box_Auto_start_CheckedChanged(sender As Object, e As EventArgs) Handles _Chk_box_Auto_start.CheckedChanged
        Dim regKey As Microsoft.Win32.RegistryKey
        My.Settings.Auto_Start = _Chk_box_Auto_start.CheckState
        My.Settings.Save()
        ' if checked add to registry to auto run
        If _Chk_box_Auto_start.Checked = True Then
            regKey = Registry.CurrentUser.OpenSubKey("Software\Microsoft\Windows\CurrentVersion\Run", True)
            regKey.SetValue("Blynk - a lync status light for Blink(1)", Application.ExecutablePath)
            regKey.Close()
        Else
            regKey = Registry.CurrentUser.OpenSubKey("Software\Microsoft\Windows\CurrentVersion\Run", True)
            regKey.DeleteValue("Blynk - a lync status light for Blink(1)")
            regKey.Close()
        End If

    End Sub



    Private Sub _btn_Minimise_Click(sender As Object, e As EventArgs) Handles _btn_Minimise.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub HelpToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HelpToolStripMenuItem.Click

    End Sub

    Private Sub AboutBlynkToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutBlynkToolStripMenuItem.Click
        Blynk.ShowDialog()
    End Sub

    Private Sub ViewHelpToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewHelpToolStripMenuItem.Click
        _frm_Help.Show()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub


End Class