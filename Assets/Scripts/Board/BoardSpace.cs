using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardSpace : MonoBehaviour
{
    public GameObject unitTemplate;
    public int boardWidth = 5, boardHeight = 5;
    public Dictionary<int, BaseUnit> unitData = new Dictionary<int, BaseUnit>();

    // Create slots for all the board Pieces
    public BaseUnit[,] boardPieces;
    
    public int latestUID = 0;
    // Start is called before the first frame update
    void Start()
    {
        boardPieces = new BaseUnit[boardWidth,boardHeight];
        
//    DELETE ONCE TESTING IS DONE
//        for (int _x = 0; _x < boardWidth; _x++){
//            for (int _y = 0; _y < boardHeight; _y++){
//                boardPieces[_x, _y];
//            }
//        }
        
        EventDefinition ed = new EventDefinition();
        ed.eventName = "AddUnitToBoard";
        ed.eventTarget = "addBaseUnit";
        ed.action = addGamepiece;
        EventBus.Instance().RegisterEvent(ed);
    }

    // Update is called once per frame
    void Update(){
        
    }

    void addGamepiece(Dictionary<string, object> prms){
        object tmp;

        prms.TryGetValue("unitData", out tmp);
        
        BaseUnit unitSO = tmp as BaseUnit;
        
        unitSO.obj = Instantiate(unitTemplate);
        
        unitData.Add(latestUID, unitSO);
        latestUID++;

        boardPieces[unitSO.xPos, unitSO.yPos] = unitSO;
        
        unitSO.obj.transform.position = new Vector3(unitSO.xPos, 0 ,unitSO.yPos);

    }

    public BaseUnit getPieceAtLoc(int x, int y){

        if (x < boardWidth && y < boardHeight){
            return boardPieces[x,y];
        }
        else{
            return null;
        }
        
        
    }
}
