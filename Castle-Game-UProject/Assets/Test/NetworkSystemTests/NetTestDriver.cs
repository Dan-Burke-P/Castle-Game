using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NetworkSystem;
public class NetTestDriver : MonoBehaviour{
    
    public PrintWrapper pw;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Setup a connection as a host
    /// </summary>
    public void setHost(){
        Debug.Log("Setting as host!");
        NetConn test = new NetConn(pw ,"localhost", 33, mode.HOST);
    }


    public void setClient(){
        Debug.Log("Setting as client!");
        NetConn test = new NetConn(pw ,"localhost", 33, mode.CLIENT);
    }
}
