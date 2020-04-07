using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[ExecuteInEditMode]
public class BoardRenderer : MonoBehaviour
{

    public int mp_x = 5;
    public int mp_y = 5;
    
    public float tileSize = 1f;
    public int tileDivs = 1;

    public float tileStepX;
    public float tileStepY;
    
    
    public MeshVars mv;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private int _rowView(int x, int y)
    {
        return y * (mp_x + 1) + x;
    }
    public void render()
    {
        mv.verts.Clear();
        mv.triGroups.Clear();
        mv.normals.Clear();
        mv.UV.Clear();
        
        
        tileStepX = (float)1 / (mp_x);
        tileStepY = (float)1 / (mp_y);

        
        int currentVert = 0;
        Vector3 newV3;
        TriGroup newTG;
        
        for (int _y = 0; _y < mp_y + 1; _y++)
        {
 
            for (int _x = 0; _x < mp_x + 1; _x++)
            {
                
                // Set up our triangle
                // First make sure we are not in the last row where our triangles
                // Wouldn't have a new row to connect to
                if (_x < mp_x && _y < mp_y)
                {
                    // Since each quad is two triangles we will start by making one triangle group
                    newTG = new TriGroup();
                    // The root of our triangle should be our current vertex
                    newTG.first = _rowView(_x, _y);
                    // This connects to our current vertex plus the size of a row plus one
                    newTG.second = _rowView(_x + 1, _y + 1);
                    // We then connect back to the current vert + 1
                    newTG.third = _rowView(_x, _y + 1);
                    mv.triGroups.Add(newTG);
                    
                    
                    // Then a second triangle group to fill the quad
                    newTG = new TriGroup();
                    // The root of our triangle should be our current vertex
                    newTG.first =_rowView(_x, _y);
                    // This connects to our current vertex plus the size of a row plus one
                    newTG.second = _rowView(_x +1, _y);
                    // We then connect back to the current vert + 1
                    newTG.third = _rowView(_x + 1, _y + 1);
                    mv.triGroups.Add(newTG);
                }
                currentVert++;
                
                
                
                // Create a new vertex 
                newV3 = new Vector3(_x,_y,0);
                mv.verts.Add(newV3);
                mv.normals.Add(Vector3.forward);

                Vector2 newV2 = new Vector2(tileStepX * _x, tileStepY * _y);
                mv.UV.Add(newV2);
            }
        }
        
        Mesh mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        mesh.vertices = mv.verts.ToArray();
        mesh.normals = mv.normals.ToArray();
        mesh.triangles = mv.buildTris();
        mesh.uv = mv.UV.ToArray();

    }
}
