using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor.UIElements;
[ExecuteInEditMode]
#endif
public class GroundTile : MonoBehaviour
{
    public float sideLen = 1;

    public MeshVars mv;

    public float ttrReset = 3f;
    public float timeTillRender = 3f;
    public bool shouldAutoRender = false;

    public void render()
    {
        Debug.Log("Rendering GroundTile");
        Mesh mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        mesh.vertices = mv.verts.ToArray();
        mesh.normals = mv.normals.ToArray();
        mesh.triangles = mv.buildTris();
        mesh.uv = mv.UV.ToArray();

    }

    // Start is called before the first frame update
    void Start()
    {
        render();
    }

    // Update is called once per frame
    void Update()
    {
        if (shouldAutoRender)
        {
            render();
        }
    }
}
