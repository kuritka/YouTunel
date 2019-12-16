@echo off
@echo Zjistuji nastaveni vasi proxy.....
c:
cd Windows\System32
reg query "HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Internet Settings" | find /i "proxyserver"
reg query "HKEY_LOCAL_MACHINE\Software\Microsoft\Windows\CurrentVersion\Internet Settings" | find /i "proxyserver"
pause