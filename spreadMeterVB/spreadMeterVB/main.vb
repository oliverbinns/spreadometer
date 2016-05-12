Imports System.Net
Imports System.Text
Imports System.IO
Imports System.Threading
Imports System.IO.Ports

Public Class mainForm

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles updateButton.Click
        mod1.httpReq()
        mod1.setVal()
        mod1.sendMsg()

    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs)
        'Send update to serial port
        mod1.sendMsg()
    End Sub

    Private Sub mainForm_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        startupSplash.Close()
        mod1.shutdown()
    End Sub

    Private Sub mainForm_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

    End Sub



    Private Sub mainForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Label8_Click(sender As System.Object, e As System.EventArgs)
        Me.statusLabel.Text = "Scanning for spread-o-meter"
        mod1.comFinder()
    End Sub

    Private Sub comCombo_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles comCombo.SelectedIndexChanged
        If mod1.comFinderOn = False Then
            mod1.updatePort(Me.comCombo.Text)
        End If
    End Sub

    Private Sub Button3_Click_1(sender As System.Object, e As System.EventArgs)
        mod1.shutdown()
    End Sub

    Private Sub itemExit_Click(sender As System.Object, e As System.EventArgs) Handles itemExit.Click
        Me.Close()
    End Sub

    Private Sub mainForm_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        If Me.WindowState = FormWindowState.Minimized Then
            NotifyIcon1.Visible = True
            Me.Hide()
        End If
    End Sub

    Private Sub itemShow_Click(sender As System.Object, e As System.EventArgs) Handles itemShow.Click
        Me.Show()
        Me.WindowState = FormWindowState.Normal
        Me.NotifyIcon1.Visible = False
    End Sub

    Private Sub NotifyIcon1_MouseDoubleClick(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles NotifyIcon1.MouseDoubleClick
        Me.Show()
        Me.WindowState = FormWindowState.Normal
        Me.NotifyIcon1.Visible = False
    End Sub

    Private Sub PictureBox1_Click(sender As System.Object, e As System.EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub Button1_Click_1(sender As System.Object, e As System.EventArgs) Handles manualButton.Click
        mod1.sendMsg()
    End Sub

    Private Sub ContextMenuStrip1_Opening(sender As System.Object, e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening

    End Sub

    Private Sub itemUpdate_Click(sender As System.Object, e As System.EventArgs) Handles itemUpdate.Click
        mod1.httpReq()
        mod1.setVal()
        mod1.sendMsg()
    End Sub
End Class



Public Class mod1
    Shared readerOn As Boolean = False
    Shared writerOn As Boolean = False
    Shared instHandlerOn As Boolean = False
    Shared _serialPort As SerialPort
    Shared writeMsg As String = ""
    Shared readMsg As String = ""
    Shared serClose As Boolean = False
    Shared latestVal As Integer
    Shared mainFrm As New mainForm
    Shared serverOK As Boolean = False
    Shared comPort As String = ""
    Public Shared comFinderOn = False

    Public Shared Sub startup()
        'Show the connecting progress dialog box
        scanFrm.Show()
        startupSplash.Close()

        'Show the main form and load the last set of values
        mainFrm.Show()
        mainFrm.IPsprMax.Text = My.Settings.maxValSaved.ToString()
        mainFrm.IPsprMin.Text = My.Settings.minValSaved.ToString()
        mainFrm.IPsprVal.Text = My.Settings.latestValSaved.ToString()

        'Find the correct COM port
findPort:
        updateStatus("Scanning for spread-o-meter")
        scanFrm.Refresh()
        comFinderOn = True
        comFinder()
        comFinderOn = False

        'Hide the splash
        startupSplash.Close()

        'Deal with spreadometer not found
        If comPort = "" Then
            scanFrm.Hide()
            Dim a = MsgBox("Could not find a spreadometer.  Check it is connected properly and click retry to scan again.", MsgBoxStyle.AbortRetryIgnore, "Meter not found")
            Debug.Print(a)
            Select Case a
                Case 4
                    'Retry
                    scanFrm.Show()
                    GoTo findPort

                Case 3
                    'Abort
                    mainFrm.Close()
                    scanFrm.Close()
                    Exit Sub

                Case 5
                    'Ignore
                    scanFrm.Close()

                Case Else
                    'Abort
                    scanFrm.Close()
                    Exit Sub

            End Select

        End If

        'Hide the scan form
        scanFrm.Close()

        'Enable the main form controls
        mainFrm.IPsprVal.Enabled = True
        mainFrm.IPsprMax.Enabled = True
        mainFrm.IPsprMin.Enabled = True
        mainFrm.comCombo.Enabled = True
        mainFrm.updateButton.Enabled = True
        mainFrm.manualButton.Enabled = True

        'If a COM port is selected, start the serial system
        If comPort <> "" Then
            startupSerial()
        End If



    End Sub

    Public Shared Sub startupSerial()
        updateStatus("Connecting to device on port COM" & comPort)
        connectForm.Show()
        connectForm.Label1.Text = "Connecting..."
        connectForm.Refresh()

        'Open the selected serial port
        Debug.Print("Opening serial port on COM" & comPort)
        _serialPort = New SerialPort()
        _serialPort.PortName = "COM" & comPort
        _serialPort.Open()
        serClose = False

        'Open read/write and handler threads
        Debug.Print("Starting serial writer thread")
        Dim writeThread As New Threading.Thread(AddressOf writer)
        writeThread.Start()

        Debug.Print("Starting serial reader thread")
        Dim readThread As New Threading.Thread(AddressOf reader)
        readThread.Start()

        Debug.Print("Starting instruction handler thread")
        Dim readHandler As New Threading.Thread(AddressOf instHandler)
        readHandler.Start()

        updateStatus("Now connected to device on port COM" & comPort)
        connectForm.Close()
    End Sub


    Public Shared Sub shutdown()
        updateStatus("Closing current connection.  Please wait.")
        connectForm.Show()
        connectForm.Label1.Text = "Disconnecting..."
        connectForm.Refresh()

        Debug.Print("threadstatus:" & readerOn & writerOn & instHandlerOn)
        Debug.Print("Shutting down - sending kill signal to serial threads")
        serClose = True

        'Loop whilst threads shut down
        Do While readerOn = True
            Do While writerOn = True
                Do While instHandlerOn = True
                Loop
            Loop
        Loop

        'Threads now shut down 
        Debug.Print("All serial threads report shut down.  Closing serial port")

        _serialPort.Close()
        connectForm.Close()

    End Sub

    Public Shared Sub comFinder()
        _serialPort = New SerialPort()
        mainFrm.Refresh()
        Dim ports As String() = SerialPort.GetPortNames
        Dim port As String
        Dim portNumber As Integer
        mainFrm.comCombo.Items.Clear()

        'Send a ping message on every port
        For Each port In ports
            Debug.WriteLine("Pinging port: " & port)
            mainFrm.comCombo.Items.Add(port)
            _serialPort.PortName = port
            _serialPort.ReadTimeout = 1000
            portNumber = Right(port, Len(port) - 3)
            Try
                _serialPort.Open()
                _serialPort.Write("-1,-1," & portNumber & vbLf)
                Try
                    Dim pingMsg As String = _serialPort.ReadLine()
                    Debug.WriteLine("Ping message: " & pingMsg)
                    Dim resp = InStr(pingMsg, "PING-SPREADOMETER-", CompareMethod.Text)
                    If resp > -1 Then
                        comPort = Right(pingMsg, Len(pingMsg) - 18)
                        Debug.Print("Setting COM port to " & comPort)
                        mainFrm.comCombo.Text = "COM" & comPort
                        updateStatus("Found spread-o-meter on port " & comPort)
                    End If
                Catch
                    Debug.WriteLine("Ping timeout")
                End Try
                _serialPort.Close()
            Catch
                Debug.Print("PING failed on " & port)
            End Try
        Next port

        If comPort = "" Then
            updateStatus("Could not find the spread-o-meter.  Check it is connected")
        End If

    End Sub

    Public Shared Sub updatePort(p As String)
        'Shutdown the serial threads
        shutdown()

        'change the COM port
        comPort = Right(p, Len(p) - 3)

        'Restart the serial port
        startupSerial()

    End Sub

    Public Shared Sub sendMsg()

        'prepare the values
        Dim sprVal = mainFrm.IPsprVal.Text
        Dim sprMin = mainFrm.IPsprMin.Text
        Dim sprMax = mainFrm.IPsprMax.Text

        'Send the message
        writeMsg = sprVal & "," & sprMin & "," & sprMax & vbLf

    End Sub

    Public Sub stopSer()
        serClose = True
    End Sub


    Public Shared Sub writer()
        While serClose = False
            writerOn = True
            Thread.Sleep(100)
            If writeMsg <> "" Then
                Debug.Print("Writing message:" & writeMsg)
                _serialPort.Write(writeMsg)
                writeMsg = ""
            End If
        End While
        Debug.Print("writer Stopped")
        writerOn = False
    End Sub

    Public Shared Sub reader()
        While serClose = False
            readerOn = True
            Thread.Sleep(100)
            Try
                _serialPort.ReadTimeout = 100
                Dim message As String = _serialPort.ReadLine()
                readMsg = message
            Catch generatedExceptionName As TimeoutException
                Debug.WriteLine("Reader timeout")
            End Try
        End While

        Debug.Print("reader Stopped")
        readerOn = False
    End Sub

    Public Shared Sub instHandler()

        While serClose = False
            instHandlerOn = True
            Thread.Sleep(100)
            If readMsg <> "" Then
                Debug.Print("Received: " & readMsg)

                Select Case True
                    Case InStr(readMsg, "PING", CompareMethod.Text)
                        Dim pingPort = Right(readMsg, Len(readMsg) - 18)
                        Debug.Print("*** Ping handler")
                        Debug.Print(pingPort)

                    Case InStr(readMsg, "ERROR", CompareMethod.Text)
                        Debug.Print("*** Error handler")
                        updateStatus("Error message from spread-o-meter (outside range)")
                        MsgBox("Warning: The spread value is outside the max/min values of the gauge")

                    Case InStr(readMsg, "Gauge set:", CompareMethod.Text)
                        Debug.Print("*** Success handler")
                        updateStatus(readMsg)


                    Case InStr(readMsg, "User requesting update", CompareMethod.Text)
                        Debug.Print("*** Request handler")
                        updateStatus("Update button pressed on spread-o-meter")
                        mod1.httpReq()
                        mod1.setVal()
                        mod1.sendMsg()

                    Case InStr(readMsg, "Standing by for input...", CompareMethod.Text)
                        Debug.Print("*** Request handler")
                        updateStatus("Spread-o-meter requesting update")
                        mod1.httpReq()
                        mod1.setVal()
                        mod1.sendMsg()

                    Case Else
                        Debug.Print("*** No handler")
                        updateStatus("Unknown message from spread-o-meter")

                End Select

                readMsg = ""
            End If
        End While
        Debug.Print("instHandler Stopped")
        instHandlerOn = False
    End Sub

    Public Shared Sub httpReq()
        'Get value from server
        updateStatus("Connecting to server...")
        Try
            ' Create a request using a URL that can receive a post. 
            Dim serverURL = My.Settings.serverURL.ToString()
            Dim request As WebRequest = WebRequest.Create(serverURL)

            request.Method = "POST"
            Dim postData As String = ""
            Dim byteArray As Byte() = Encoding.UTF8.GetBytes(postData)

            request.ContentType = "application/x-www-form-urlencoded"
            request.ContentLength = byteArray.Length

            Dim dataStream As Stream = request.GetRequestStream()
            dataStream.Write(byteArray, 0, byteArray.Length)
            dataStream.Close()

            Dim response As WebResponse = request.GetResponse()
            Debug.WriteLine("Server status: " & CType(response, HttpWebResponse).StatusDescription)
            dataStream = response.GetResponseStream()
            Dim reader As New StreamReader(dataStream)
            Dim responseFromServer As String = reader.ReadToEnd()
            Debug.WriteLine("Server response: " & responseFromServer)
            latestVal = responseFromServer

            reader.Close()
            dataStream.Close()
            response.Close()

            updateStatus("Updated spread - sending to gauge")
            serverOK = True
            My.Settings.latestValSaved = latestVal
            My.Settings.Save()
        Catch
            serverOK = False
            updateStatus("Error connecting to server.  Cannot update")
            MsgBox("There was an error connecting to the spread server - cannot update the gauge. Check your connection to the network and retry")
        End Try
    End Sub


    Delegate Sub setValCallBack()

    Public Shared Sub setVal()
        If mainFrm.InvokeRequired Then
            Dim d As New setValCallBack(AddressOf setVal)
            mainFrm.Invoke(d, New Object() {})
        Else
            mainFrm.IPsprVal.Text = latestVal.ToString()
        End If
    End Sub




    Delegate Sub UpdateStatusCallBack([text] As String)

    Public Shared Sub updateStatus(ByVal [text] As String)
        If mainFrm.InvokeRequired Then
            Dim d As New UpdateStatusCallBack(AddressOf updateStatus)
            mainFrm.Invoke(d, New Object() {[text]})
        Else
            mainFrm.statusLabel.Text = [text]
            mainFrm.Refresh()
            If mainFrm.NotifyIcon1.Visible = True Then

                mainFrm.NotifyIcon1.BalloonTipText = [text]
                mainFrm.NotifyIcon1.ShowBalloonTip(500)


            End If
        End If
    End Sub

End Class