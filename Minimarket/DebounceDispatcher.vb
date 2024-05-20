Imports System.Windows.Threading

Public Class DebounceDispatcher
    Private timer As DispatcherTimer
    Private Property timerStarted As DateTime = DateTime.UtcNow.AddYears(-1)

    Public Sub Debounce(ByVal interval As Integer, ByVal action As Action(Of Object), Optional ByVal param As Object = Nothing, Optional ByVal priority As DispatcherPriority = DispatcherPriority.ApplicationIdle, Optional ByVal disp As Dispatcher = Nothing)
        If timer IsNot Nothing Then
            timer.Stop()
        End If
        timer = Nothing
        If disp Is Nothing Then disp = Dispatcher.CurrentDispatcher
        timer = New DispatcherTimer(TimeSpan.FromMilliseconds(interval), priority, Function(s, e)
                                                                                       If timer IsNot Nothing Then
                                                                                           timer.Stop()
                                                                                           timer = Nothing
                                                                                           action.Invoke(param)
                                                                                       End If

                                                                                   End Function, disp)
        timer.Start()
    End Sub

    Public Sub Throttle(ByVal interval As Integer, ByVal action As Action(Of Object), Optional ByVal param As Object = Nothing, Optional ByVal priority As DispatcherPriority = DispatcherPriority.ApplicationIdle, Optional ByVal disp As Dispatcher = Nothing)
        If timer IsNot Nothing Then
            timer.Stop()
        End If


        timer = Nothing
        If disp Is Nothing Then disp = Dispatcher.CurrentDispatcher
        Dim curTime = DateTime.UtcNow
        If curTime.Subtract(timerStarted).TotalMilliseconds < interval Then interval -= CInt(curTime.Subtract(timerStarted).TotalMilliseconds)
        timer = New DispatcherTimer(TimeSpan.FromMilliseconds(interval), priority, Function(s, e)
                                                                                       If timer IsNot Nothing Then
                                                                                           timer.Stop()

                                                                                           timer = Nothing
                                                                                           action.Invoke(param)
                                                                                       End If

                                                                                   End Function, disp)
        If timer IsNot Nothing Then
            timer.Start()
        End If

        timerStarted = curTime
    End Sub
End Class

