using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using NetworkSystem;
public class TSqueueTestDriver : MonoBehaviour{
    private Thread T1;
    private Thread T2;

    private TSqueue<string> test = new TSqueue<string>();
    
    private void Start(){
        T1 = new Thread(new ThreadStart(T1Logic));
        T1.IsBackground = true;
        T1.Start();
    }

    private void Update(){
        string ret;
        if (test.tryDequeue(out ret)){
            Debug.Log(ret);
        }
    }

    private void T1Logic(){
        for (int i = 0; i < 100; i++){
            test.enqueue("This is a test string! " + i);
        }
    }

    private void T2Logic(){
        
    }
}
