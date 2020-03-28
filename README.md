# Castle-Game


## Development Guides

### Coming soon, *FULL* Gameplay Design Document   

*Still accepting help designing some of the gameplay features past the basic loop, so if you want to be involved feel free to reach out with any ideas :)*

### Starting Guides and Design Principles  
1. [First Time Setup Guide](Documentation/Starting-Development.md)
2. [Introduction to Component Based Design](Documentation/Component-System-Design-Overview.md)  
3. [(Coming Soon)Introduction to unity testing framework]()
4. [(Coming Soon)Naming and formatting conventions]()  
5. [(Coming Soon)Folder Organization Standards]()

### System Layout 
1. [(Coming Soon)System Interaction Diagram]() 
2. [(Coming Soon)Individual System Class Diagrams]()
3. [(Coming Soon)Systems Testing Procedures]() 

### Feature Guides
1. [Creating new cards](Documentation/Adding-Cards.md)      
More feature guides are coming soon as I work through the documentation, I am being thourough and detailed so it will take some time alone. 


-------------

# Original Proposal

## Project Description

The project I would like to do is a multiplayer strategy game. The goal of the game revolves around the simple concept of invading your opponent’s territory and destroying their castle. Although this goal seems simple it becomes complicated as you are your opponent will have access to an array of units and structures that will help to defend their given castle from the opponent’s attacks.
    It is a cross of a card game and a turn based strategy game, the units will move across the board similar to how chess works, where each turn the player will have the option to use their units energy to enact an action that reaches them towards their goal of taking over the enemy base. As well with the addition of a card system the players will be able to consume resources to play cards from a deck that they construct to alter the battlefield by summoning new units and structures to help further their goal.
    
---
The following diagram shows how the average turn for a player would go, this is just to help envisioning what the end project would feel and play like.

![Diagram](https://github.com/Dan-Burke-P/Castle-Game/blob/master/ReadmeFiles/Turn%20Flow!Turn%20Flow_1.png)

This diagram is an extension of the previous diagram exposing the actions taken when selecting a unit.
![Diagram](https://github.com/Dan-Burke-P/Castle-Game/blob/master/ReadmeFiles/Unit%20Actions!Unit%20Actions_2.png) 

## my contribution

What I bring to the table with this project is an intermediate understanding of game design and programming. Having made multiple small games and a few medium sized projects I am well versed in how to layout components in a reusable and efficient way while achieving a fun and engaging experience for the end user. While I am also adept at programming the logic that is required to run the project, I am stronger at creating architecture that allows for components to be worked on independently without creating issues for other sections of code. I have a sizable amount of experience with the unity game engine specifically and would be able to teach people the basics all the way to an introduction to advanced engine usage. 

## High level UML
This is a high level representation of the general code structure for the game, this is not set in stone but gives a gist of how the project could be laid out
![Diagram](https://github.com/Dan-Burke-P/Castle-Game/blob/master/ReadmeFiles/Main%20Program%20Model!Main_0.png)


## Educational Relevance 

This project will take a lot of design and architecture to ensure that it runs smoothly and is extensible for adding new features to the game. Since games are not only developed and upkept by programmers it is important to design a system that while not trivial to use will allow for a designer to make changes to gameplay elements without diving deep into the code base to modify things. The result is a problem domain that although on the surface seems trivial becomes complicated as the layout and design of the code base must remain organized and easy to modify as new content is requested and designed.
    A system must be developed asides from actual code to layout the pieces of code in such a way that modification is simplified. As well there is the requirement that the code be reliable. This results in the creation of a system that decouples core actions in the program through interchangeable interfaces that allow for the program to be modified in parts to isolate the chance of creating errors that destabilize the game.

### list of educational goals
1. Properly creating diagrams to express and communicate concepts to maintain project stability
2. Use of object oriented design to maintain an extensible and coherant project
3. Unique testing and issue tracking as there is less set ways to verify integrity
4. Maintaining a strongly enforced versioning system to properly diagnose problems and provide fixes

## technologies

The different tools used to make a game can vary greatly on the scope and goal of a project. Although there are merits to developing an engine in house to streamline the run time of a program, for our time constraints it is more relevant to use a general purpose engine as it reduces over heads and is more then enough to create our project. The follow list is the different technologies that will be used followed by a short description of their role in the project.

1. unity   
	General purpose game engine that will be the backbone of the project and provide basic functionality
2. C#   
	Although unity offers the ability to make projects in java script as well, the whole project should use the same language for organization sake
3. Darkrift 2   
	This is a free extension of the unity game engine allowing for highly customizable networking interface which can be optimized to achieve the exact needs of the project
4. Blender   
	This is an open source modeling resource that will be used to create the basic models for units and graphics in the game, the graphics are not intended to be super detailed but this resource is good for basic geometries
5. star UML   
	This is a free to use UML drawing program that allows for highly detailed diagrams and flow charts that are easily traversable to create higher detail then simple image diagrams.
6. JSON   
	This is a way to serialize and pack data in a predetermined format and can be used to encode functionality of a program to make it easy to extend different elements and edit the stats of individual objects
