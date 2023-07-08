# MushWorld
Hey there! Mushworld is my playground and will have my final project for the Game Engine course I am taking at university.

## Features
The main features that I implemented for this videogame were having a first person controller that can be used either with keyboard and mouse as an input or an xbox cotroller, respawning, collecting items in the world (mushrooms mainly), adding them in an inventory, being able to place them in the world, having responsive audio based on the place you are in the world right now, being able to change the volume, and going into a secondary scene. There are others like being able to "clink" the glasses and eat cake/cupcakes.

### First person controller
#### Moving
My first person controller is physics-based, meaning that the movement is done by adding a force to the rigidbody. Getting input from the user is done through the New Unity input system, where I map the controllers so that either mouse and keyboard or xbox controller can be used.

#### Moving the head
I decided having the player only be able to turn around (in yaw rotation), move horizontally, and jumping was not enough. I wanted the player to be able to move the head too (in pitch) like in real life when we move the chin down and up. To accomplish that, I needed to change the way that my character was made, so that it had independend head and body. The head was a child of the body and would also hear the input, so that it could rotate by itself, I also made it in a way that there was a minimum and a maximum rotation, so that it could not go beyond these and it would mantain integrity.

#### Respawning
While testing I realized it was kind of awful falling and just keep falling, so besides adding invisible colliders in the scene, I also implemented  pretty simple respawn. It is a box collider that, whenever you leave it, it knows it OnTriggeExit and it takes you back to an initial position in the world. That way I avoid endless falling. Let it be noted that I make sure that only the player tag triggers it, so I do not accidentally have a mushroom or another collectible or weapon trigger it.

### Collecting items
#### By collision
At the beginning, I had collecting items set up in a way that whenever you collided with them they would automatically be absorbed. And that was done by checking an OnTriggerEnter on the mushrooms, as they were the ones handling their own collisions. Nevertheless, I afterwards decided that the game was actually going to be a world-building game, so it did not make sense that the collectibles where automatically absorbed. 

#### By clicking on them
So I chnaged it so instead o fthem being automatically collected, you needed to point at them and 

### Inventory
When I decided to have an inventory I did not know how hard it was going to be. First, I needed a way to know which item I was collecting, and making it have a 2d representation for the inventory UI. Then, I needed to let the inventory know that something needed to be added, but checking whether it had been added before or not. Because if it had been added, I needed to raise the number in the current slot that had that colletcible. But if it had not been added before, I needed to find which was the next available slot (from left to right) and then 


## Modeling
I decided to model all of my assets, to put into practice **blender**. For that, I have created multiple nature low-poly models, as well as materials (directly in Unity).

### Mushwroom world
![MushroomsWorld](https://user-images.githubusercontent.com/46715001/236161331-749cc415-aa6c-436a-a480-7460e192e7d6.png)

## Shaders
As part of my personal exercises, I have cretaed different coded shaders that work on my URP. Here are some videos on how they look like!

### Water
https://user-images.githubusercontent.com/46715001/236160817-5d3a1466-fb91-4440-be0a-64a8e22ee08b.mp4

