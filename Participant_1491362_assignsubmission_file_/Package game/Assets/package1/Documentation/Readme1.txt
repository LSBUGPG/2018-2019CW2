This package contains various scripts for Animation, Follower, Spawn and Trap_Activate
What should happen is that the Follower script should start moving towards whatever object was placed inside of the public variable
Space will spawn whatever prefab is in the Spawn script and the blocks that have the Trap_activate script attach will disappear when colliding 
with any object that has the Player tag on it, the main goal is to get the follower object to touch the final object that will trigger the animation.

Follower -
The follower script will be attached to whatever object the user wants to have follow a specific object.
After attaching it an object you must also place an object in script called "Target transform" that way the 
object will then follow the object that is listed. you can then input the speed to make the object faster or slower.
To make sure the object works as intended be sure to add a rigidbody to the object so it has gravity and also add a colidor
so it does not phase through objects.

Spawn - 
The spawn script will spawn whatever prefab is set inside the public script caled "Spawnable" to position of the spawned object
will be spawned in whatever gameobject is set in the "New position" area of the script so its not needed to set the script on the
object you want it spawned from but it helps organise it.

Trap_activate
This script sets whatever object it's attached to disappear when it colides with another object that has the "Player" tag
the object that the script is attached too must have a collidor attached and have "Is Trigger" ticked on, the object that
is considered a player object should also have a collidor too but have the "Is trigger" ticked off

Animation - 
This script plays an animation when a certain tagged object colides with whatever is attached to it, in this case to activate
an animation the object that needs to collide with it needs to be set to the "Follower" Tag the object that this script is attached too
must also have an animation created to activate then placed in the "Rotation" area of the scrip, to make sure the script works the object itself
must have  Box collider that has "Is Trigger" ticked on and the object with a follower tag have a collider with the "Is trigger" ticked off


