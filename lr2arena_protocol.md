# LR2Arena protocol

LR2Arena relies on UDP to communicate with both the "implant" (the DLL being injected into LR2) and the remote client. Ports are distributed as follows:
- 2222: used for communication from the implant to LR2Arena
- 2223: used for communication from LR2Arena to the implant
- 2224: used for communication between clients (LR2Arena to LR2Arena)

Since even the communication between the implant and LR2Arena relies on UDP, it is possible to develop a new implant to work with LR2Arena, for example if you want to adapt LR2Arena to a different BMS client.

The UDP packets have a very simple structure:
```
[ id (1 byte) | data (n bytes) ]
```
`id` defines the operation carried by the UDP packet.
If you wish to develop a new implant for LR2Arena, you need to implement the following operations:

### Send (implant -> LR2Arena)

- `1`: returns the full path to the selected BMS in `data`, and a generated random. The path **must** be encoded in Shift-JIS. This should be sent right after selecting the chart. Packet format is as follows:
```
[ 1 | random (28 bytes) | path (n bytes) ]
```
`random` can be anything you want as long as both players can play using the same random with it; this is the implant's duty to implement it properly. In LR2mind's implementation, `random` does **NOT** correspond to the lanes' order. `random` **always** has to be generated, even if the player did not choose the Random option.
- `2`: returns the player's current score data. It should be sent on each note. Packet format is as follows (note that the `score` field refers to the old-style score (out of 200000) and not the exscore):
```
[ 2 | poor (4 bytes) | bad (4 bytes) | good (4 bytes) | great (4 bytes) | pgreat (4 bytes) | max_combo (4 bytes) | score (4 bytes) ]
```
- `3`: should be sent when the player cancels chart loading (before the chart has started). `data` is not checked, so it can be empty.

### Receive (LR2Arena -> implant)

- `1`: receives the remote player's exscore. It can be used to update the pacemaker in-game. `data` is a 4-byte long unsigned int (little-endian).
- `2`: notifies that the remote player is ready and has selected the correct chart. Can be used for syncing between clients. `data` is not checked, so it can be empty.
- `3`: receives a random to use for the next chart. This is always sent, even if the player did not choose the Random option. Structure is as follows:
```
[ 3 | random (28 bytes) ]
```
- `4`: tells whether if random flip should be activated or not. Random flip means that randoms should be mirrored. Structure is as follows:
```
[ 4 | random_flip_enabled (1 byte) ]
```