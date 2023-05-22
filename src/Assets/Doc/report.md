# Assignment 1 implementation

![Final look](./InGame.png)

## (Cute) procedural figures
For the procedural figures I decided to create a cube, a tetrahaedron, a heart, an A, and a Octahedrons. 

### Instantiating a figure
I decided to have only one file for all of the figures implementation, and a way of choosing which figure to render on the editor. What I did was creating an Enum of type ProceduralFigure, and create a private instance of it on a Procedural Figure class. Nevertheless, this is displayed on the editor of the game object by being a Serialized field, which means that the user can choose from a drop-down which figure to render, and then the class will make sure to use the correct function to render all of the needed triangles for that figure.

### The different figures
Even though there are 5 based figures (mentioned above), I actually have way more options of figures that can be rendered. I decided to look at the difference in shading between, for example, a cube where only 8 vertices are created and all of the triangles generated are made with these, in comparison with a cube where all of the triangles are generated with unique vertices. These different figures can be found on the ProceduralFiguresPlayground scene.

### Colliders
I wanted my procedural figures to be able to interact with my beams, so I also make sure to add the newly generated mesh into a collider component on the game object.

## Rotation
I have multiple scripts that can achieve similar goals with rotation, these are shortly explained.

### Rotating around own axis
I implemented one where the only thing that it does is rotate the object around its same axis. What it does is add a defined _degreesPerSecond into the current rotation of the transform.

### Rotate around
Makes the object rotate around a target that can be set with any other object on the scene. It rotates with a defined _degreesPerSecond that can be changed on the editor.

### Orbit around parent
Makes the object rotate around its parent with a defined _degreesPerSecond that can be changed on the editor.

#### Rotating slantly
The helped class OrbitAroundParent has a private SerializeField rotateSlantly which lets the user choose whether the movement will be slantly against the parent object, or not.

### Look at
Is a helper class where the only thing that happens is that the object that has it as a component looks at another defined target.

## Raycasting
For the bouncing raycast I decided to implement a raycast with a maximum amount of bounces (that can be defined by the user) and which is rendered on the scene using a Line Rendered. What I do is that every time that there is a collision, I get the point where that happen and 
a) add it into the line renderer so another line is created
b) use it for raycasting another ray, by reflecting the current ray using a Vector3 function which take sthe current direction and the normal.

### Coroutine for raycast
The way that my beams are emitting is by a Shoot coroutinge that starts on Awake on my shooter object (in this case, the procedural cube) and continues until the scene is over.

### Beamer
Beamer is my class that lets any object shoot beams, which are my raycasts that reflect based on which angle they hit.

## Bezier
For the bezier curve, I implemented a function that takes tehe given 4 points (4 game object transforms) and uses them to make an object (the one that has the component attached) move through this bezier curve both back and forth (achieved while checking in which point of the curve we are currently in.)

This class also lets you define the speed at which the shooter (or any game with the BezierCurve component attached) will be going in.

## Making it pretty
I was able to make the scene pretty by adding different materials, light, and using a skybox by BOXOSKY. This assignment is inside of my bigger project of the 3D class, hence I already had things like the skybox and colors to make it look nice.