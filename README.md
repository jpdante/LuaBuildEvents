# LuaBuildEvents
[![Codacy Badge](https://api.codacy.com/project/badge/Grade/5f404d387599464d8de5b2ff937bf237)](https://www.codacy.com/manual/jpdante/LuaBuildEvents?utm_source=github.com&amp;utm_medium=referral&amp;utm_content=jpdante/LuaBuildEvents&amp;utm_campaign=Badge_Grade)

Cross platform automation program for pre and post build events, using lua scripts with csharp commands and types.

### Why use it ?
*   Avoid manual work by performing repetitive operations for each build.
*   The shell or bash used by IDE's like Visual Studio are often limited.
*   The commands used do not work between different operating systems.
*   Allows greater control and automation using scripts that can be edited without recompiling a program.
*   There are many other reasons, such as playing with Lua :)

### Why was this project developed ?

While I was developing projects there was a mismatch between the commands used on my Windows and my Linux notebook,
ie whenever I tried to compile the solution the BuildEvents of each project triggered an error that canceled the compilation of the solution. I developed this software to be cross platform and had more functions than a simple shell.

## Getting Started
To use this program you must have .Net Core 3.1 installed, in the future self-contained releases will be published.

### Prerequisites
*   [.Net Core 3.1](https://dotnet.microsoft.com/download)

### Installation
1.  Download the latest version at [https://github.com/jpdante/LuaBuildEvents/releases](https://github.com/jpdante/LuaBuildEvents/releases)
2.  Extract the files in an accessible location and with the necessary permissions to execute.
3.  Run the program within the events of an IDE such as Visual Studio or run it manually.

## Usage
To run the program just call dotnet and pass the file path to LuaBuildEvents.dll and then the path of a lua script.
```sh
dotnet <path>/LuaBuildEvents.dll <path>/script.lua <optional args>
```

## Wiki
See the [wiki](https://github.com/jpdante/LuaBuildEvents/wiki) for more information on how to use it.

## Roadmap
See the [open issues](https://github.com/jpdante/LuaBuildEvents/issues) for a list of proposed features (and known issues).

## License
Distributed under the MIT License. See `LICENSE` for more information.
