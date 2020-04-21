using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.InputSystem;
using GameManagers;
using UnityEngine;

public class SingletonMonoInitializer : MonoBehaviour
{
    private void Awake(){
        var tmp = FInput.Instance;
        var tmp2 = GameMaster.Instance;
        Destroy(gameObject);      
    }
}
