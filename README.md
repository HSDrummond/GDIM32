Farming Frenzy

Elevator Pitch:
Farming Frenzy is a 2 player, local muliplayer, competitive top-down farming simulator game!
When the game begins, boths players are tasked with a 3 item order! Navigate the farm and
find the items that you need! Make sure you watch out for the farm animals, some of them
might be aggressive! Whichever player completes the most orders when the timer runs out wins!

*Note*
Crops in the tree is intentional. Right now it is whooever completes the most amount of orders
within the timelimit. You can not pick up animals yet but they do wander, run away, and approach 
when you have corn or wheat. The bull will pursue you if it sees you but can not attack you. 
walking over tomato plants causes you to grow while pumpkins shink you. Be careful to balance 
walking over these so you will be able to cross the bridges. 
*A lot of these design decision were made with the intention of a future implemented tool that
can be used for interacting with the other players, animals, and certain crops.

Controls:
Player 1 uses WASD to move, E tap to pick up items, and E hold to drop your most currently picked up item.
Player 2 uses Arrow Keys to move, / tap to pick up items, and / hold to drop your most currently picked up item.

Rules:
Player 1 is on the left and Player 2 are on the right.
When the game starts, a timer starts for 60 seconds.
Players will move around to collect items to complete orders.
The player with the most orders wins!


Deliverables:

1. Your game should allow for local multiplayer with at least 2 players.
- 2 Players each with their own systems working

2. Your game should have implemented at least 2 autonomous agents that move and exhibit distinct choices or sequences of actions. Examples would be choosing to fight or flee depending on some data, animals that search for food with some kind of strategy but change behavior when given food or flee from different animals or the player. The real goal here is that you implement one of the following: a finite state machine, a behavior tree or goal oriented action planning.
- FSM controlling all the animals and bull. All animals have diffrent state and bulls state machine is built alongside the others. Using the 2D Navmesh plugin was an trip

3. Optionally your game can have an option to have an AI replace one of the players (either opponent or co-op player)
- Will not have an AI replace yet but we seperated the player scripts (i.e order and inventory) so it will be easier to do so when we get there. 


NOTE FOR INSTRUCTORS=> Check the other txt file titled "Scripts Breakdown" for a breakdown of who worked on each script.