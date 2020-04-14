using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DTestBoardGeneration {
    
    
    // This string is the expected print out when calling to string
    // on an empty board space with dimension 4X4
    public static string generatedBoardSpace_EMPTY_4x4 = 
        "{Coords: ( 0 , 0 )}{Coords: ( 1 , 0 )}{Coords: ( 2 , 0 )}{Coords: ( 3 , 0 )}\n" +
        "{Coords: ( 0 , 1 )}{Coords: ( 1 , 1 )}{Coords: ( 2 , 1 )}{Coords: ( 3 , 1 )}\n" +
        "{Coords: ( 0 , 2 )}{Coords: ( 1 , 2 )}{Coords: ( 2 , 2 )}{Coords: ( 3 , 2 )}\n" + 
        "{Coords: ( 0 , 3 )}{Coords: ( 1 , 3 )}{Coords: ( 2 , 3 )}{Coords: ( 3 , 3 )}\n";

    // Represents the to string generated when the board has a soldier placed at
    // X: 2 Y: 3
    public static string addedSoldierTo_x2y3_4X4 = 
        "{Coords: ( 0 , 0 )}{Coords: ( 1 , 0 )}{Coords: ( 2 , 0 )}{Coords: ( 3 , 0 )}\n" +
        "{Coords: ( 0 , 1 )}{Coords: ( 1 , 1 )}{Coords: ( 2 , 1 )}{Coords: ( 3 , 1 )}\n" +
        "{Coords: ( 0 , 2 )}{Coords: ( 1 , 2 )}{Coords: ( 2 , 2 )}{Coords: ( 3 , 2 )}\n" + 
        "{Coords: ( 0 , 3 )}{Coords: ( 1 , 3 )}{Coords: ( 2 , 3 ), Unit: (Soldier)}{Coords: ( 3 , 3 )}\n";

    
}
