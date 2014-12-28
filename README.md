SA-MP# boilerplate
=====================

This is repository contains very basic boilerplate for a [SA-MP#] gamemode/development environment.

Setup
-----
1. Install [Visual Studio]. You can download the Express edition for free.
1. Download [mono] and extract the contents to the `/env` directory.
1. Rename `/env/server.cfg.template` to `/env/server.cfg` and edit it. At the very least change the `rcon_password` value.
1. If you haven't already, download [sa-mp server] which is available on the forums. Store it wherever you like. If you store it in your project directory, don't forget to add it to the `.gitignore` file.
1. Open the `Boilerplate.sln` with Visual Studio.
1. In the Solution explorer, double click on Properties under the Boilerplate project.
1. Switch to the Debug tab, and uder Start Action select Start external program. Click on ... and select `samp-server.exe` from your server directory.
1. _optional_ If you like to change the name of your project follow these instructions:
 1. In the Solution Explorer, right click on the Boilerplate Solution and click Rename. Rename it to your gamemode's name. (It is best not to use spaces, and use CamelCase, for example `RiverShell`)
 1. In the Solution Explorer, right click on the Boilerplate Project and click Rename. Rename it to your gamemode's name.
 1. In the Solution explorer, double click on Properties under the Boilerplate project. Switch to the Application tab, and change both the Assembly name and Default namespace to your gamemode's name.
 1. In all four source files (*.cs files) change the namespace to your gamemode's name.
 1. _optional_ Your code is will still be stored in `/src/Boilerplate`. If you want to change this, exit visual studio, rename `/src/Boilerplate to /src/(your gamemode's name)`, open the `(your gamemode's name).sln` file **with a texteditor** and change the project path near line 6 accordingly.

Contribute
----------
If these instructions are unclear, or you have a question, open an issue.

[sa-mp#]: https://github.com/ikkentim/SampSharp
[visual studio]: http://www.visualstudio.com/en-us/downloads/download-visual-studio-vs.aspx
[mono]: http://deploy.timpotze.nl/packages/mono-portable.zip
[sa-mp server]: http://forum.sa-mp.com/forumdisplay.php?f=74
