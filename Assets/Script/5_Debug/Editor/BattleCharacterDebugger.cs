using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(DebugPlayerOnBattleData))]
public class BattleCharacterDebugger : Editor
{
    public override void OnInspectorGUI()
    {
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        EditorGUILayout.LabelField("====ĳ���� ����====");
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        DebugPlayerOnBattleData script = (DebugPlayerOnBattleData)target;
        if(GUILayout.Button("ĳ���� ����"))
        {
        }
    }
}


