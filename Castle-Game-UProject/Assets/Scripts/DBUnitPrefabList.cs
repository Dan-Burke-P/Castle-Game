using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DBUnitPrefabList : MonoBehaviour{


    public static Dictionary<string, GameObject> UPL;

    private void Awake(){
        UPL = new Dictionary<string, GameObject>(){
            {"soldier", Resources.Load<GameObject>("Assets/Prefabs/Unit Display Objects/Capsule.prefab")}
        };
    }
}
