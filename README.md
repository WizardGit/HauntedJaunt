# HauntedJaunt
By Kaiser Slocum
Last Edited: 4/8/2022

Part 1: Completed by Kaiser Slocum
Part 2: In PlayerMovement.cs script in setPosText() function, I call the Vector3.Dot on the player vector and vector of the ending trigger.
This is displayed on the screen so the user knows when he is getting closer to the ending area.
Part 3: In PlayerMovement.cs script in setPosText() function, I call Color.Lerp on Colors red and white.  Then use 50% to get a shade of pink. (Basically averages the colors)
Part 4: On all four ghosts, I added a sparkly particle effect to them.
Part 5: Done

Part 4 and Part 2 are constantly called so you can just observe that.
Part 3 is only triggered if you come with 5 units of a ghost.

Bonus Additions!: 
1. if you go directly to the left of the spawn (and evad the gargoyle there!), you can enter in a room.
By passing through the doorway, you should trigger a movie to play!
2. On the top left of the screen are two constantly updating values.  The top tells you how close you are to the neartest ghost.
The bottom value is a normalization value showing how close you are to the ending, trigger area.  (i.e. the closer you are to 1, the better!)
3. An alarm will go off if you get within 3 units of a ghost, and the text will turn red.
If you get with 5 units of a ghost, the text will turn a shade of pink!
4. I built the game using WebGL, and published it here:https://play.unity.com/mg/other/webgl-builds-177536
Unfortunately, the video won't play since my video is not uploaded to the web, but everything else works nicely!

