using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateTestDriver : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void testChangeGameState(int state)
    {
        Dictionary<string, object> prms = new Dictionary<string, object>();

        prms.Add("state", state);
        
        //GameStateChangeScript.Instance().changeGameState(prms);
    }
}
