using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseUnit : MonoBehaviour
{
    private float x = 0, y = 0;
    // Start is called before the first frame update
    void Start(){
        
        EventDefinition ed = new EventDefinition();
        ed.action = moveTo;
        ed.eventName = "MoveUnit";
        ed.eventTarget = "MoveTargetUnit";
        
        EventBus.Instance().RegisterEvent(ed);
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Transform>().localPosition = new Vector3(x,y, 3);
    }

    public void moveTo(Dictionary<string, object> prms){
        Debug.Log("moveTo function triggered");
        object tmp;
        prms.TryGetValue("x", out tmp);
        x = tmp is float ? (float) tmp : 0;
        prms.TryGetValue("y", out tmp);
        y = tmp is float ? (float) tmp : 0;
    }
}
