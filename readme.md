# IIS Express WebApp Remote Share

This is a small webforms app to quicken the three configuration tasks that needs to be done before anyone can access your IIS Express web app site from a different computer.

The program performs three tasks:

1. Configure IIS Express with Local IP
2. Enable Access to the URL for All Users
3. Open the Port in Windows Firewall
4. Run Solution in Visual Studio as Admin

It gets the local IP from the system and the port from the solution files, adds the port to the firewall if it's not present, runs an elevated netsh command to allow connections to that IP and port, and adds the IP and port to the IIS Express config file.
