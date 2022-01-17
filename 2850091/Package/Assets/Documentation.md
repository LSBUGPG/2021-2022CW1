# FPS Controller

Add these components in a game to create a simple FPS controller and gun system.

## Contents

These components are made up of several scripts which control different aspects of the controller:

- Player Movement
- Mouse look controls
- Gun
- Switching weapons
- Target
- Camera zoom

## Player Movement

As the header suggests, this script allows the player to use a character controller to move around, jump and be effected by gravity. It has values for the speed of the character,
gravity strength and jump height. There is also a ground check to ensure the gravity system works properly and will need to have a game object assigned in the inspector.

## Mouse look controls

This allows the mouse to lock to the screen, the cursor to become invisible and let the player look around with the mouse movement.

## Gun

Assigning this component to a game object allows the player to use the left mouse button to fire a raycast which can cause an effect on specified targets. 
The range, damage, impact force, fire rate, reload time and ammo count, are all editable in the inspector.
Additionally, the script allows for a particle effect to be instantiated upon shooting as well as when the raycast collides with an object.

## Target

This component can be assigned to a game object, and has an editable value for health. When the health has been lowered to zero or less, the object will be destroyed.

## Switching Weapons

This component allows the player to change between weapons using the mouse scroll wheel and number keys.

## Camera zoom

This compenent allows the player to zoom the camera in with the right mouse button to aim better. The zoom effects the camera's field of view, and can be edited in the inspector.
Additionally, there is an editable value for how smooth the zoom transition is.
