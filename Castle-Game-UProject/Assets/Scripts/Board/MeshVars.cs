using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.UIElements;
#endif

[CreateAssetMenu(menuName="Board/Mesh Vars")]
public class MeshVars : ScriptableObject
{
    
    public List<Vector3> verts;
    public List<Vector3> normals;
    public List<Vector2> UV;
    public List<TriGroup> triGroups;
    
    public int[] buildTris()    
    {
        List<int> ret = new List<int>();

        foreach (TriGroup tg in triGroups)
        {
            ret.Add(tg.first);
            ret.Add(tg.second);
            ret.Add(tg.third);
        }
        
        return ret.ToArray();
    }
}



[System.Serializable]
public struct TriGroup
{
    public int first;
    public int second;
    public int third;

    public TriGroup(int i, int j, int k)
    {
        first = i;
        second = j;
        third = k;
    }
    public int[] toArr()
    {
        var ret = new[] {first, second, third};
        return ret;
    }
    
}


#if UNITY_EDITOR

[CustomPropertyDrawer(typeof(TriGroup))]
public class MeshVarUIE: PropertyDrawer
{
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return 40;
    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        position.height += 50;
        EditorGUI.BeginProperty(position, label, property);

        float interval = 25;
        float objWid = 45;
        float txtWid = 45;
        float firstOff = objWid + interval, secondOff = firstOff * 2;
        
        position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);
        var indent = EditorGUI.indentLevel;
        EditorGUI.indentLevel = 0;
        
        var tst = new Rect(position.x,position.y,100,100);
        
        var firstLabel = new Rect(position.x, position.y, txtWid,10);
        var secondLabel = new Rect(position.x + firstOff, position.y, txtWid,10);
        var thirdLabel = new Rect(position.x + secondOff, position.y, txtWid,10);
        
        
        var first = new Rect(position.x, position.y+10, objWid, 20);
        var second = new Rect(position.x + firstOff, position.y+10, objWid, 20);
        var third = new Rect(position.x + secondOff, position.y+10, objWid, 20);

        EditorGUI.LabelField(firstLabel, "First");
        EditorGUI.LabelField(secondLabel, "Second");
        EditorGUI.LabelField(thirdLabel, "Third");

        
        EditorGUI.PropertyField(first, property.FindPropertyRelative("first"), GUIContent.none);
        EditorGUI.PropertyField(second, property.FindPropertyRelative("second"), GUIContent.none);
        EditorGUI.PropertyField(third, property.FindPropertyRelative("third"), GUIContent.none);

        
        EditorGUI.indentLevel = indent;
        
        EditorGUI.EndProperty();
    }
}

#endif
