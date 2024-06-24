This package contains what is needed to add respawning mechanics into a game there is a player and lava if
the player falls off and touches the lava they will respawn to where they were at the start of the game
very useful for adding hazards to games

The two scripts camera camouselock were previously used in another package they are simply here to allow movement to
demonstrate that the respawn scripts work so i will be focusing on the respawn script itself and how that works

Respawn - 

the two private transforms Player and respawnpoint have serializefield added to them so that they can show up in the 
inspector of the unity project it's there where we will add in our gameobjects our player and our respawn point for the player 
be sure that the Player object has the Player tag on it  and to add a spawn point create a empty game object by going
Game Object -> Create empty move this empty object where you want the player to respawn and then place it in the inspector field where
the script is asking for one 

The OnTriggerEnter enables detects if an object is going within the objects trigger zone and if it does it will transform 
the position of the object to the respawn point, it is checking for only objects that have the player tag on it 

The object you want to attach this script too is whatever object you wish to cause the player to respawn, the object itself
must have a collider which has "Is Trigger" ticked in order to work, if you want something else to also cause the player to respawn
for example spheres you can create a sphere add a collider with a "Is Trigger" ticked and then add the script and it should work
as long as you also have the Player and Respawn point in the field.
