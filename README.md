3/9/2024 I created two RayShooter scripts for both players that face through the front of the player objects/ The fire button for player one is R and player two is Y. I also created two ReactiveTargetscripts for both players aswell. Each players have a max helth of 30 and starts with the max. Every time the other player shoots a player, their health loses 6 health, so they will reach 0 health after 5 hits. When a player's health reaches 0, they will fall over and be destroyed. The time will then be paused and the winner text will be edited to claim the alive player as the winner. I also changed the timer for the game down to 3 minutes and changed the interval of the changing collectibles to be 22 seconds instead of 30.

3/2/2024 I made two separate inventory systems for each player. Hooked up the collectible and jumpovertally scripts to both. I then removed the UI Managers, the the text UI is now coded within the inventories. There are Two different Score Boards for Each Player, one to show hoe many times they have jumped over the other player and for the collectibles. I have also edited the Times Up script to use the items in the inventory managers to determine the winner.

3/1/2024 I have included several new cube gameobjects with the name of box. With the inclusion of the RelativeMovement script, the player is able to push them around the arena. Additionally, I have fixed the issue with the CollectibleManager Script. I have now made it so the gameobject Collect Temp is set to active at all times with the 30 second interval of the other gameobjects with the tag "collect" appearing and disappearing. This has made it so the null error from before does not happen.

2/23/2024 I have updated the text boxes to the legacy text, to be able to input the information directly to them. The respective Player points UI use the collection of points from jumping over the other player and collecting collectibles. Once the time runs out, the times up script compares the points and uses a text UI to declare the winning player. I have also currently made it so that all of the gameobject with the "collect" tag start the game as set active, due to a null error that would crash the game. This will be edited to work correctly in a future update. //this ReadMe log has been paraphrased due to the loss of the previous build file.

2/16/2024 For this project, when I was fixing and trying to make it more enjoyable, I added and fixed a few things. I added in some unique jumping spots, increased the jump variable to 6f, made it so player one stops when the movement buttons are not pressed, got rid of the infinite jump, and made it so the players face the way they are moving. The Design Tools that I used were Goal and Constraint. For Goal, I made collectibles that appear around the map every 30 seconds. These also give players points, so they can try to collect all of these to increase their points in the game. For Constraint, I added a timer. The timer makes it so the game lasts for 4 minutes, once time it up it add the points from jumping over the other player and the collectibles for each player, tells them the points for each, and calculates who the winner is.
