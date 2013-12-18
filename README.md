Playlist Generator
==================

Playlist Generator creates music playlist files for the files in a given directory. Currently only M3U format is supported but the application has been designed to be extended easily.

The solution comprises four C# projects:

 - Application library
 - GUI application
 - Console application
 - Test suite

Compiling
---------
Loading the solution into Visual Studio and hitting *start* should be sufficient to run the GUI application. The console application requires the *Mono.Options* library, which NuGet will download and install automatically, but to the wrong location because [NuGet is shit][1] [by design][2]. Dependency packages are copied to the *packages* folder instead of the respective project folders. You can either reinstall packages using the NuGet Package Manager CLI or uninstall and reinstall using the GUI built into Visual Studio to copy the package files to the project directories.

The test suite tests the console application and therefore has the same dependencies.

Design
------

The application library contains all the application logic and is shared between the other three projects. The shared library design eliminates code duplication between the GUI and console versions of the application and allows more interfaces to be added, such as a Web application, without introducing further duplication.

The entire project has been designed with extensibilty in mind so feel free to send pull requests with your improvements.

  [1]: http://stackoverflow.com/questions/14942374/nuget-package-files-not-being-copied-to-project-content-during-build
  [2]: http://docs.nuget.org/docs/reference/package-restore
