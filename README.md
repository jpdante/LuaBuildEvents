# LuaBuildEvents
Cross platform automation program for pre and post build events, using lua scripts with csharp commands and types.

**Why use it?**
* Avoid manual work by performing repetitive operations for each build.
* The shell or bash used by IDE's like Visual Studio are often limited.
* The commands used do not work between different operating systems.
* Allows greater control and automation using scripts that can be edited without recompiling a program.
* There are many other reasons, such as playing with Lua :)

**Why was this project developed?**

While I was developing projects there was a mismatch between the commands used on my Windows and my Linux notebook,
ie whenever I tried to compile the solution the BuildEvents of each project triggered an error that canceled the compilation of the solution. I developed this software to be cross platform and had more functions than a simple shell.

## Getting Started
To use this program you must have .Net Core 3.0 installed, in the future self-contained releases will be published.

### Prerequisites
* [.Net Core 3.0](https://dotnet.microsoft.com/download)

### Installation
1. Download the latest version at [https://github.com/jpdante/LuaBuildEvents/releases](https://github.com/jpdante/LuaBuildEvents/releases)
2. Extract the files in an accessible location and with the necessary permissions to execute.

## Usage
To run the program just call dotnet and pass the file path to LuaBuildEvents.dll and then the path of a lua script.
```sh
dotnet <path>/LuaBuildEvents.dll <path>/script.lua
```

## Roadmap
See the [open issues](https://github.com/othneildrew/Best-README-Template/issues) for a list of proposed features (and known issues).

## License
Distributed under the MIT License. See `LICENSE` for more information.
