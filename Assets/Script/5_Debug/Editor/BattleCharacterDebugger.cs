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
        EditorGUILayout.LabelField("====캐릭터 생성====");
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        DebugPlayerOnBattleData script = (DebugPlayerOnBattleData)target;
        if(GUILayout.Button("캐릭터 생성"))
        {
        }
    }
}


