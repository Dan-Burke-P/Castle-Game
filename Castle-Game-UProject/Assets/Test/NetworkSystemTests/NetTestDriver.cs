using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NetworkSystem;
using UnityEngine.UI;

public class NetTestDriver : MonoBehaviour{
    
    public PrintWrapper pw;

    public InputField input;

    public Text output;
    
    private NetConn test;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update(){
        if (test != null){
            NetPacket tmp;
            if (test.getNetPacket(out tmp)){
                output.text += tmp.data + "\n";
            }
        }
    }

    /// <summary>
    /// Setup a connection as a host
    /// </summary>
    public void setHost(){
        Debug.Log("Setting as host!");
        test = new NetConn(pw ,"localhost", 12345, mode.HOST);
    }


    public void setClient(){
        Debug.Log("Setting as client!");
        test = new NetConn(pw ,"localhost", 12345, mode.CLIENT);
    }

    public void sendMessageS(){
        NetPacket np = new NetPacket();
        
        input.text = "";
        test.sendNetPacket(np);
    }
}
