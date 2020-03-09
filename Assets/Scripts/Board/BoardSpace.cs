using System;
using System.Collections;
using System.Collections.Generic;
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
        
        EventDefinition ed = new EventDefinition();
        ed.eventName = "AddUnitToBoard";
        ed.eventTarget = "addBaseUnit";
        ed.action = addGamepiece;
        EventBus.Instance().RegisterEvent(ed);

        initialized = true;
    }

    // Update is called once per frame
    void Update(){
        
    }

    /*
     * Event function for adding units to the board
     *
     * Expects key values:
     * "unitData"    - int    - The baseUnit SO that represents the virtual unit
     * "x"           - int    - The x location we want to place the unit at
     * "y"           - int    - The y location we want to play the unit at
     * 
     */
    public void addGamepiece(Dictionary<string, object> prms){
        object tmp;

        object _x, _y;
        
        if(!prms.TryGetValue("unitData", out tmp)) {
            Debug.LogError("addGamepiece was raised without unit data");            
            return;
        }

        if (!prms.TryGetValue("x", out _x)) {
            Debug.LogError("addGamepiece was raised without x value");            
            return;
        }

        if (!prms.TryGetValue("y", out _y)) {
            Debug.LogError("addGamepiece was raised without y value");
            return;
        }
        
        BaseUnit unitSO = tmp as BaseUnit;
        if (unitSO != null) {
            unitSO.xPos = _x is int ? (int) _x : 0;
            unitSO.yPos = _y is int ? (int) _y : 0;
            unitSO.obj = Instantiate(unitTemplate);

            unitData.Add(latestUID, unitSO);
            latestUID++;

            _slots[unitSO.xPos, unitSO.yPos].unit = unitSO;

            unitSO.obj.transform.position = new Vector3(unitSO.xPos, 0, unitSO.yPos);
        }
        else {
            Debug.LogError("addGamepiece ended up with a null unitSO");
        }
    }

    public BaseUnit getPieceAtLoc(int x, int y){

        if (x < boardWidth && y < boardHeight) {
            BoardSlot bs = _slots[x, y];
            return bs.unit;
        }
        else{
            return null;
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
