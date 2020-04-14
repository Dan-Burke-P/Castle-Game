using System;
using System.Collections;
using System.Collections.Generic;
using EventSystem;
using UnityEngine;

public class BoardSpace : MonoBehaviour
{
    public bool initialized { get; set; }

    public GameObject unitTemplate;
    public int boardWidth = 5, boardHeight = 5;
    public Dictionary<int, BaseUnit> unitData = new Dictionary<int, BaseUnit>();

    // Create slots for all the board Pieces
    private BoardSlot[,] _slots;
    
    public int latestUID = 0;


    /*
     * The initBoardSpace() function is used to internally build the array
     * of board slots used to virtualize the game board
     *
     * This should be called first thing before any interactions with the board take place,
     * if the board is resized post game start for some reason this should also be re-ran
     * 
     */
    private void _initBoardSpace(){
        Debug.Log("Initialized size " + boardWidth + ", " + boardHeight);
        _slots = new BoardSlot[boardWidth,boardHeight];
        
        for (int _x = 0; _x < boardWidth; _x++){
            for (int _y = 0; _y < boardHeight; _y++){
                _slots[_x, _y] = new BoardSlot(_x,_y);
            }
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        // Initialize the board space
        _initBoardSpace();
        initialized = true;
    }

    // Update is called once per frame
    void Update(){
        
    }

    public BaseUnit getPieceAtLoc(Vector2 loc){
        return getPieceAtLoc((int)loc.x, (int)loc.y);
    }

    public BaseUnit getPieceAtLoc(int x, int y){

        if (x >= 0 && y >= 0 && x < boardWidth && y < boardHeight){
            BoardSlot bs = _slots[x, y];
            return bs.unit;
        }
        else{
            return null;
        }
    }

    public void addUnitAt(BaseUnit bu, Vector2Int v2i){
        addUnitAt(bu, v2i.x, v2i.y);
    }
    public void addUnitAt(BaseUnit unit, int x, int y){
        BoardSlot bs;
        if (x >= 0 && y >= 0 && x < boardWidth && y < boardHeight){
             bs = _slots[x, y];
        }
        else{
            Debug.Log("Add unit at location failed, the index was out of range");
            return;
        }

        if (bs.unit){
            Debug.Log("Unit currently in that location");
        }
        else{
            // We need to check that the selection is in board boundry
            //print("Adding unit to the board");
            bs.unit = unit;
            unit.xPos = x;
            unit.yPos = y;
            
            EventDefinition displayEvent = new EventDefinition(SysTarget.UI, "addUnitDisplayObject", this);
            displayEvent.raise(unit.ID, this, new Dictionary<string, object> { {"BaseUnit", unit} });

        }
    }

    /*
     * Override the to string to we can properly parse and display the object for
     * debugging and testing
     */
    public override string ToString(){
        string ret = "";

        for (int _y = 0; _y < boardHeight; _y++) {
            for (int _x = 0; _x < boardWidth; _x++) {
                ret += _slots[_x, _y].ToString();
            }

            ret += "\n";
        }
        return ret;
    }
}
