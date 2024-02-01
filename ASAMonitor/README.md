# ASA Monitor

Configure and monitor your ARK Survival Ascended private server.  ASA Monitor will restart your server when it crashes, first checking and installing any new updates from Steam.  A built-in mobile friendly web interface can be used to configure the settings in the Game.INI and GameUserSettings.INI files, as well as manage any installed mods from CurseForge.

## Installing

1. Download the latest package from the [releases](https://github.com/gflansburg/ASAMonitor/releases) page.
2. Extract the contents to any folder of your choosing.
3. Edit the ASAMonitor.exe.config file to enter your system path to your installation of SteamCmd and your system path to your ARK server installation.
4. Run ASAMonitor.exe.  Clicking on the close or minimize buttons will minimize ASA Monitor to your system tray.
5. (Optional) Add ASA Monitor to your StartUp apps.  Doing this will allow ASA Monitor to restart your ARK server after a system reboot.

## Running
ASA Monitor will run in the system tray. Right click on the system tray icon to show or close the application. Additionaly, you may double-click on the system tray icon to show it.  Clicking the "Pause" button will stop ASA Monitor from restarting your ARK server if it goes offline.  This is handy if you need to take it offline for a particular reason and do not want ASA to constantly try to restart it.  To close ASA Monitor, simply select "Exit" from the menu by right-clicking on the system tray icon.

## ASAMonitor.exe.config appSettings.
**CurseForgeID**: This is the app id on CurseForge for ARK Survival Ascended modules.  **Do not change this!**

**CurseForgeAPIKey**: This is the API key needed to access the CurseForge database for their ARK Survival Ascended modules list.  **Do not change this unless you have your own API key you wish to use.**

**SteamCmdPath**: This is the system path to your SteamCmd installation.

**ASAServerPath**: This is the system path to your ARK Survival Ascended server installation.

**WebServerPort**: This is the port to use for the web interface. I use 5150 but you could easily use port 80 if you do not already run a web server.  You will need to open a pin hole in the firewall of your router if you want outside access.

**ThirdPartyEdit**: This option allows you to edit settings for third party mods whose settings are stored in the GameUserSettings.INI file.  The default is True.

**MobileHideThirdParty**: Because the tabs can add up quickly, this option allows you to turn off third party editing when viewing from a mobile device.  The default is True.

**AllowServerPasswordAccess**: This option allows both the server password as well as the server admin password the ability to log in.  When using the server password everything can be edited except for the passwords.  I use this option to allow my users the ability to tweak settings and install mods but not give them access to the admin functions within the game.  The default is False.

**Note**: SSL is not supported.  Unless you have use a SSL certificate in your firewall to handle incoming and outgoing SSL encryptions/decryptions, all passwords will be sent "plain text" and not encrypted.  If this is a problem then do not open the web interface to the public by allowing access through your firewall and only use the web interface on the computer the server is running on.
