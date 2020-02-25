using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

[ExecuteInEditMode]
public class GroundTile : MonoBehaviour
{
    public float sideLen = 1;

//    private Vector3[] newVerts =
//    {
//        new Vector3(0,0,0),
//        new Vector3(1,0,0),
//        new Vector3(1,1,0),
//        new Vector3(0,1,0),
//        new Vector3(0,1,1),
//        new Vector3(1,1,1),
//        new Vector3(1,0,1),
//        new Vector3(0,0,1)
//    };
//    
//    private Vector2[] newUV;
//    private int[] newTris =
//    {
//        0,2,1,
//        0,3,2,
//        2,3,4,
//        2,4,5,
//        1,2,5,
//        1,5,6,
//        0,7,4,
//        0,4,3,
//        5,4,7,
//        5,7,6,
//        0,6,7,
//        0,1,6
//    };

    
    public Vector3[] newVerts =
    {
        new Vector3(0,0,0),
        new Vector3(1,0,0),
        new Vector3(1,1,0),
        new Vector3(0,1,0)
    };
    
    public int[] newTris =
    {
        0,2,1,
        0,3,2
    };


    public void render()
    {
        Mesh mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        mesh.vertices = newVerts;
        //mesh.uv = newUV;
        mesh.triangles = newTris;

    }
    
    // Start is called before the first frame update
    void Start()
    {
        render();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
