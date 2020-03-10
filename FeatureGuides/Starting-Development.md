# Guide for First Time Setup of Castle Game

## Setting up unity

Before you can begin to work on any game you must first get the engine you are going to be using.
For castle game the engine of choice is unity, the reason for this decision is it is a relatively user friendly engine and offers many great features while still being approachable by those without a lot of experience in game design. To get unity set up is very straight forward and does not require a great deal of work. Below will be a list of the steps that need to be taken to get set up with the engine.

### Setting Up An Account

A prerequisite to using unity is having a unity developer account. Unity is commercial software so while it is free to use as long as you are not breaching the limitations of the user agreement, you still need to be registered with them. You can choose either a student or personal account, it doesn't really matter as this project does not use any of the features found in higher tier versions of unity. Some of these features can be useful but I have never really found them to be a limiting factor in creating a project in unity so unless you don't qualify these accounts will be more then enough for most projects.    
   
The account setup can be found [on this page](https://store.unity.com/#plans-individual) I won't be going over it extensively as it should be straight forward.


### Getting The Engine

1. Download unity 
    You can find the download page [here](https://unity3d.com/get-unity/download). Simply click download unity hub and you are on your way.  
    ![Download Screen Guide](res/startingDevelopment/Unity-Download-Page.PNG)     

    *The reason I say unity hub is it will provide the same service as the stand alone engine but allows multiple engines incase versions change. You can use the stand alone engine but be wary of tracking what version of the engine you downloaded.*    

2. Install unity hub
    Just like any other application you install simply run the installer and it will handle the rest for you
    ![Showing Downloads and Installer](res/startingDevelopment/Unity-Hub-Installer.PNG)
3. Get the actual engine through unity hub
    - Once you have unity hub set up open the install tab   
    ![Home Page Showing Install](res/startingDevelopment/Hub-Start-Page-To-Installs.PNG)     


    - Click the add button to bring up the interface showing available engine downloads   
    ![Installs Page Showing Add](res/startingDevelopment/Hub-Installs-Page-Add.PNG)
    - Select the engine that has the version number you need    
    ![Version Selection Screen](res/startingDevelopment/Hub-Add-Menu-Version-Selection.PNG)   
    ***As of 3/10/2020 the version is 2019.3.1f1***   
    *Check the readme if you want to check for updates to the version being used however, there is a low chance that engine version will impact stability in a severe manor as long as it is close and optimally newer then the current version*    

    - Click next and select any required modules.    
    ![Module Selection Screen](res/startingDevelopment/Hub-Select-Modules-Done.PNG)    
    **No modules are required for castle-game currently, but they at worst just take up some hard disk space**
    - Select done and sit back and wait as unity hub will now download the engine. Once the download completes you can move on to the next setup steps, or start them while the engine installs.   
    ![Installation Final Screen](res/startingDevelopment/Adding-The-Engine-Final.PNG)

## Getting the files

First thing to getting started in castle-games development is getting all of the files contained in the game. These files include asset files such as prefabs for game objects, scriptable objects for data handling, or C# scripts that create the logic. These will all be found in the git repository and should be straight forward to get. However I will add a small aside here about how to do it incase you need a refresher.

- Clone the git repository with the command ** git clone https://github.com/Dan-Burke-P/Castle-Game.git ** 
- Optionally (And how I prefer to do it for various reasons) is using git desktop. Simply click the clone button and enter in the repository link and select where you want to put your local copy.   

*** As a thing to note about using git, sometimes you will create trash files when building the project or doing certain things which can clog up git, please keep track of what files you are adding to your commits and if you have a question about if a file is needed in the repo or not feel free to message someone else. I would prefer people slow down and ask rather then having to clean out the repo down the line ***

## Running the project