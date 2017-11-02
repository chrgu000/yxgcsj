Dim WshShell
Set WshShell=WScript.CreateObject("WScript.Shell")
WScript.Sleep 100
WshShell.AppActivate "Factorio 0.15.37"
'name=Inputbox("")
'Clipboard="MsHta vbscript:ClipBoardData.setData(""Text"","""&name&""")(Window.Close)"
'WScript.Sleep 200
'WshShell.Run(Clipboard)
WScript.Sleep 200
WshShell.SendKeys "`"
WshShell.SendKeys "^v"
WshShell.SendKeys "{ENTER}"
Clipboard="MsHta vbscript:ClipBoardData.setData(""Text"","""&a&""")(Window.Close)"
WScript.Sleep 200
WshShell.Run(Clipboard)