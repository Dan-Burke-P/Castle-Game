using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitOwnerDisplay : MonoBehaviour{
    public Color c;

    public void setDisplayColor(Color _c){
        Material mat = new Material(Shader.Find("Standard"));
        c = _c;
        mat.color = c;
        gameObject.GetComponent<MeshRenderer>().material = mat;

    }
}
