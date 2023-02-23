using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Items))]
public class CustomTypeEditor : Editor
{

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        Items type = (Items)target;

        EditorGUILayout.PropertyField(serializedObject.FindProperty("itemtype"));

        switch (type.itemtype)
        {
            case Items.ItemType.Consume:
                EditorGUILayout.PropertyField(serializedObject.FindProperty("itemconsume"));
                break;
            case Items.ItemType.Gear:
                EditorGUILayout.PropertyField(serializedObject.FindProperty("itemcgear"));
                break;
        }

        serializedObject.ApplyModifiedProperties();
    }
}
