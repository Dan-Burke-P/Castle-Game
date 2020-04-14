#if UNITY_EDITOR

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GroundTile))]
public class GroundTileInspector : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        GroundTile gt = (GroundTile) target;

        if (GUILayout.Button("Render"))
        {
            gt.render();
        }
        
        //base.OnInspectorGUI();
    }
}

#endif