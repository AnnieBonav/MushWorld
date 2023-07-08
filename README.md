# MushWorld
Hey there! Mushworld is my playground and will have my final project for the Game Engine course I am taking at university.

## Features
The main features that I implemented for this videogame were having a first person controller that can be used either with keyboard and mouse as an input or an xbox cotroller, respawning, collecting items in the world (mushrooms mainly), adding them in an inventory, being able to place them in the world, having responsive audio based on the place you are in the world right now, being able to change the volume, and going into a secondary scene. There are others like being able to "clink" the glasses and eat cake/cupcakes.

### First person controller
#### Moving
My first person controller is physics-based, meaning that the movement is done by adding a force to the rigidbody. Getting input from the user is done through the New Unity input system, where I map the controllers so that either mouse and keyboard or xbox controller can be used.

** Mention more stuff about the implementation, like having serialized fields and stuff**

#### Moving the head
I decided having the player only be able to turn around (in yaw rotation), move horizontally, and jumping was not enough. I wanted the player to be able to move the head too (in pitch) like in real life when we move the chin down and up. To accomplish that, I needed to change the way that my character was made, so that it had independend head and body. The head was a child of the body and would also hear the input, so that it could rotate by itself, I also made it in a way that there was a minimum and a maximum rotation, so that it could not go beyond these and it would mantain integrity.

#### Respawning
While testing I realized it was kind of awful falling and just keep falling, so besides adding invisible colliders in the scene, I also implemented  pretty simple respawn. It is a box collider that, whenever you leave it, it knows it OnTriggeExit and it takes you back to an initial position in the world. That way I avoid endless falling. Let it be noted that I make sure that only the player tag triggers it, so I do not accidentally have a mushroom or another collectible or weapon trigger it.

### Collecting items
#### By collision
At the beginning, I had collecting items set up in a way that whenever you collided with them they would automatically be absorbed. And that was done by checking an OnTriggerEnter on the mushrooms, as they were the ones handling their own collisions. Nevertheless, I afterwards decided that the game was actually going to be a world-building game, so it did not make sense that the collectibles where automatically absorbed. 

#### By clicking on them
So I chnaged it so instead of them being automatically collected, you needed to point at them and then click b or left click to collect. What this does is emmit a raycast from the middle of the camera (where the pointer is) and, if it collides with an object that has the tag grabbable, it goes through its componnets to emmit the public function Grab inside of the componnet Grabbable. This is my parent class where all of the grabbables extend from, that serves as a common interface so I can have different actions that happen, only by using a single class I extend from.

If the raycast does find a grabbable, each of the grabbables will do what they need. The mushrooms will start with the process of being added into the inventory, the galsses wiull sound "clink", the cakes will start being eaten...

#### Puff
Also, after removing mushrooms that you have already placed, tghey emmit a particle, so that there is both a visula and a sound representation of the action.

### Inventory
When I decided to have an inventory I did not know how hard it was going to be. First, I needed a way to know which item I was collecting, and making it have a 2d representation for the inventory UI. Then, I needed to let the inventory know that something needed to be added, but checking whether it had been added before or not. Because if it had been added, I needed to raise the number in the current slot that had that colletcible. But if it had not been added before, I needed to find which was the next available slot (from left to right) and then add the new collectible slot with the 2d representation of the mushroom that was collected.

My first implementation used scriptable objects to do this adding of the 2d sprite into tje inventory UI, but then I realized that since I already had a collectible class, I could simply add the sprite referrence there and, whenever the Grab function included adding into the inventory (as explained before) I would ismply pass the UI representation into the inventory. 

though using scriptable objects was pretty cool, as it let me understand the concept of the resources folder. Which is a folder that needs to be called that way and lie on the Assets, and if there are scriptable objects there, I can easily access them with built-in functions.

### Graphics
#### 3D models
Most of the 3D models that I used at the beginning of my development were made by me, like trees, the terrain where you cna walk through, the house, the lake...But, due to time constraints, I also added models made by polymodels, which I donwoaded from the Unity assets store.

#### Shaders
I used this project as an oppirtunity to try-out my shaders skills, and you can see it on the lake. The water of the lake has a material that uses a shader that I made. It has displacemenet of the vertices based on wave funcitons (so it looked like the water was moving), a noice map that goes trhough it (so there are shadows), some colour change, and shift using time and other funcitons. Even though this might have been completely unnecesarry, it was super cool implementing it, and it looks pretty chill.

#### Skybox
The skybox also works with a shader. Even though I did not invent it, I used it as a base to learn from it and was able to modify the parameters and colours so it fit what I wanted.

### Audio implementation
For the audio implementation I used wwise, and I made sure that everything that should sound, sounded. Besides adding the normal backrgouns music and SFX for walking, i also have others that take into consideration the distance that my character has from the object that is emmitting the sound. I also have a section of my game where there is a cake and if you enter the trigger the mexican song of happy birthday sounds.

### Changing scene
Another one of the sound changes that I have is whenever I enter to my second scene, there is a change in the background music, in reverb, in the way thay you interact with the objects inside... All of teh composition of teh game I made, but the one I like the most is this second scene, as it looks pretty cool. I made sure to use differet light settings to give a complete different feeling than outside.

## Modeling
I decided to model all of my assets, to put into practice **blender**. For that, I have created multiple nature low-poly models, as well as materials (directly in Unity).

### Mushwroom world
![MushroomsWorld](https://user-images.githubusercontent.com/46715001/236161331-749cc415-aa6c-436a-a480-7460e192e7d6.png)

## Shaders
As part of my personal exercises, I have cretaed different coded shaders that work on my URP. Here are some videos on how they look like!

### Water
https://user-images.githubusercontent.com/46715001/236160817-5d3a1466-fb91-4440-be0a-64a8e22ee08b.mp4

