### The Event System

The goal of the event system is to allow different components to communicate with eachother at run time while maintaining a loose couple at compile time. The reason for this is we do not want to link things to strongly as that would prevent us from being able to easily swap, upgrade, or maintain code. Although while the project remains small the event system will seem like over kill once there are sufficient actors in the system it will simplify factoring out responsibilties of systems and avoiding compositional errors during development as failed events will provide insite into where system communication failed.

The system can be broken down into a few key components that make up the bulk of the system. While it is fairly straight forward to use already there will be updates to the event system in the future so please be aware of any changes that get made so the code and usage can remain consistant.  

- Event Definition  
    This will provide a way to store the information about an event to make sure you do not need to retype the event every location in a file that you need it, instead you will create a definition and from there you will be able to invoke the event in a straight forward way.

- Event Bus
    This is the back bone of the system, it is a static class that allows for a unified location for events to funnel through. As such there is a requirement that there is only ever one Event Bus system in the code at a given time, as such a singleton pattern has been used. Thus to access the event bus you simply have to call the static instance method found within to get the current event bus, as well it can be noted that the constructor is private inorder to prevent accidental reinstantiation of the event bus.