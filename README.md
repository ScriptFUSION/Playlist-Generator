Playlist Generator ![Playlist Generator Logo][1]
==================

Playlist Generator creates music playlist files for the files in a given directory. Currently only M3U format is supported but the application has been designed to be extended easily.

The solution comprises four C# projects:

 - Application library
 - GUI application
 - Console application
 - Test suite

GUI
---

![Playlist Generator GUI v1.1 screenshot](https://raw.github.com/wiki/ScriptFUSION/Playlist-Generator/images/gui%201.1%20screenshot.gif)

Select a directory by using the `Browse` button, editing the path manually or drag-and-drop a directory onto either the interface or application shortcut icon. The file types in the specified directory are listed in descending order of frequency. A preview of the files matching the selected file type are shown. Only one file type can be selected. The `Generate` button writes the file names in the preview to a playlist in the specified directory.

Compiling
---------

Loading the solution into Visual Studio and hitting *start* should be sufficient to run the GUI application. The console application requires the *Mono.Options* library, which NuGet will download and install automatically, but to the wrong location because [NuGet is shit][2] [by design][3]. Dependency packages are copied to the *packages* directory instead of the respective project folders. You can either reinstall packages using the NuGet Package Manager CLI or uninstall and reinstall using the GUI built into Visual Studio to copy the package files to the project directories.

The test suite tests the console application and therefore has the same dependencies.

Design
------

The application library contains all the application logic and is shared between the other three projects. The shared library design eliminates code duplication between the GUI and console versions of the application and allows more interfaces to be added, such as a Web application, without introducing further duplication.

The entire project has been designed with extensibility in mind so feel free to send pull requests with your improvements.


  [1]: https://raw.github.com/wiki/ScriptFUSION/Playlist-Generator/images/logo%201.2%20grey%20x35.png
  [2]: http://stackoverflow.com/questions/14942374/nuget-package-files-not-being-copied-to-project-content-during-build
  [3]: http://docs.nuget.org/docs/reference/package-restore
