# LR2Arena

Play LR2 online with a friend!

## Requirements

- .NET Framework 4.7.2

## Setup

Grab the latest release from the [Releases tab](https://github.com/SayakaIsBaka/LR2Arena/releases) and run `LR2Arena.exe`.

## Building

You will need at least Visual Studio 2019 to build this project.
**The DLL's source code (LR2mind.dll) has been voluntarily omitted from the repository to avoid enabling cheating, as the DLL is being injected into LR2's process.**

## TODO

- Implement synchronization between clients (highest priority)
- Fix the 1-note late pacemaker "bug" (most likely related to latency, might not be fixable)
- Update pacemaker as soon as the DLL gets the packet instead of when the player hits a note (maybe)
- Making LR2mind not broadcast the message on UDP but instead only send it on localhost (low priority)
- Make the program work if the DLL's path contains non-ASCII characters

## Special thanks

- Nothilvien for writing LR2mind's original code and the original injector's code (in C++) and basically giving me the motivation to actually make this (yet again)
