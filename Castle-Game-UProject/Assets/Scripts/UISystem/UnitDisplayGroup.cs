using System.Collections;
using System.Collections.Generic;
using EventSystem;
using UnityEngine;

public class UnitDisplayGroup : MonoBehaviour{
    
    public Transform boardRoot;
    public GameObject unitObjPrefab;
    
    /// <summary>
    /// Creates and adds a display object to the system
    /// </summary>
    /// <param name="prms"></param>
    /// <param name="id"></param>
    /// <param name="caller"></param>
    public void addDisplayObject(Dictionary<string, object> prms, int id, object caller){
        //print("Adding display object to the game");
        object tmp;
        
        if (!prms.TryGetValue("BaseUnit", out tmp)){
            Debug.LogError("Message did not contain x parameter in dictionary");
            return;
        }

        BaseUnit _baseUnit = tmp as BaseUnit;

        GameObject go = Instantiate(unitObjPrefab, boardRoot, false);
        
        go.GetComponent<UnitDisplayObject>().setContent(_baseUnit);
        
    }

    // Start is called before the first frame update
    void Start()
    {
        EventDefinition ed = new EventDefinition(SysTarget.UI, "addUnitDisplayObject", this);
        ed.register(addDisplayObject);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
