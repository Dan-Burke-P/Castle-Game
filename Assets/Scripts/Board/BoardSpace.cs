using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardSpace : MonoBehaviour
{
    public GameObject unitTemplate;
    public int boardWidth = 5, boardHeight = 5;
    public Dictionary<int, BaseUnit> unitData = new Dictionary<int, BaseUnit>();

    public int latestUID = 0;
    // Start is called before the first frame update
    void Start()
    {
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

    }
}
