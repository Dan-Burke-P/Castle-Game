using UnityEditor;
using UnityEngine;

#if UNITY_EDITOR

// Below is editor code! //
[CustomEditor(typeof(BoardRenderer))]
public class BoardRendererGUI : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        BoardRenderer br = (BoardRenderer) target;

        if (GUILayout.Button("Render"))
        {
            br.render();
        }
        
        //base.OnInspectorGUI();
    }  
}
#endif