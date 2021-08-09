# LR2Arena

Play LR2 online with a friend!

## Requirements

- [.NET Framework 4.7.2](https://dotnet.microsoft.com/download/dotnet-framework/net472)
- [Visual C++ 2017 Redistribuable x86](https://aka.ms/vs/16/release/vc_redist.x86.exe)

## Main features

- Real-time pacemaker in game
- Sync between clients for chart start
- Random sync
- Random flip
- MD5 check between clients (meaning that both players have to start the same chart to play)
- Database check (checks if the player has the selected chart, sends a message if they don't)

## Setup

Grab the latest release from the [Releases tab](https://github.com/SayakaIsBaka/LR2Arena/releases) and run `LR2Arena.exe`.
**Every player needs to have port 2224 (UDP) opened to be able to connect!** Be sure to route everything correctly if you have NAT enabled and add an exception to your firewall.

## Step-by-step instructions

1. Forward port 2224 (UDP) to your computer in your router (check your router's manual if you don't know how to do this). **Both players need to do this.**
2. Run LR2
3. Run LR2Arena.exe
4. Enter the other person's IP address in LR2Arena, then click on "OK". If you (or the other player) don't know what's your IP, look for "what's my IP" on Google.
5. Click on the "Inject DLL" button on LR2Arena. If everything went correctly, you should see a new console window appearing.
6. Enable the FPS counter (press F7) if you want to see some messages from LR2Arena directly in game! (only a message if P2 doesn't have the chart can be displayed right now, more to come)
7. That's it! Now just select a song (both players have to choose the same BMS) and it should work!
You can also use the "Check connectivity" button to verify if you can successfully connect to the other player.

## 使用方法 (translation by [Dolphin](https://twitter.com/DolphinDTM), thanks to him!)

1. インターネットルーターの設定にアクセスします。 ポート転送設定に移動します。 UDPトラフィック用にポート2224を開きます。 （ルーターはすべて異なるため、特定のルーターの手順を調べてください。）
これは両方のプレーヤーで必要です。
2. Lunatic Rave 2を実行します。
3. LR2Arena.exeを実行します
4. LR2Arena内に他のプレイヤーのIPアドレスを入力します。
5. 「Inject DLL」というボタンをクリックします。 一番左のボタンです。
6. 曲を選択してください！ 両方のプレーヤーが同じ譜面を選択していることを確認してください。

## Building

You will need at least Visual Studio 2019 to build this project.
**The DLL's source code (LR2mind.dll) has been voluntarily omitted from the repository to avoid enabling cheating, as the DLL is being injected into LR2's process.**

## Bugs

- Using the "MY BEST" pacemaker on LR2 breaks the in-game pacemaker; please use another pacemaker (A / AA / AAA pacemakers should be working)
- G-BATTLE does not work with LR2Arena
- Previews must be disabled for LR2Arena to work

## TODO

- Display P2's chosen chart in game (overlay)
- Overlay on LR2??? (probably not)

## Special thanks

- Nothilvien for writing LR2mind's original code and the original injector's code (in C++) and basically giving me the motivation to actually make this (yet again)
- Mushus for making [bms-parser](https://github.com/Mushus/bms-parser) (which I totally stole the code of for the BMS parsing part again)
- marie for testing the program with me
