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
            string tmp;
            if (test.getMessage(out tmp)){
                output.text += tmp + "\n";
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
        string message = input.text;
        input.text = "";
        test.sendMessage(message);
    }
}
