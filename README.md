# LR2Arena

Play LR2 online with a friend!

## Requirements

- [.NET Framework 4.7.2](https://dotnet.microsoft.com/download/dotnet-framework/net472)
- [Visual C++ 2017 Redistribuable x86](https://aka.ms/vs/16/release/vc_redist.x86.exe)

## Setup

Grab the latest release from the [Releases tab](https://github.com/SayakaIsBaka/LR2Arena/releases) and run `LR2Arena.exe`.
**Every player needs to have port 2224 (UDP) opened to be able to connect!** Be sure to route everything correctly if you have NAT enabled and add an exception to your firewall.

## Building

You will need at least Visual Studio 2019 to build this project.
**The DLL's source code (LR2mind.dll) has been voluntarily omitted from the repository to avoid enabling cheating, as the DLL is being injected into LR2's process.**

## TODO

- Overlay on LR2??? (probably not)

## Special thanks

- Nothilvien for writing LR2mind's original code and the original injector's code (in C++) and basically giving me the motivation to actually make this (yet again)
- Mushus for making [bms-parser](https://github.com/Mushus/bms-parser) (which I totally stole the code of for the BMS parsing part again)
- marie for testing the program with me
