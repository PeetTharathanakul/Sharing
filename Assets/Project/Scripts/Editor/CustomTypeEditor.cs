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

        EditorGUILayout.PropertyField(serializedObject.FindProperty("Name"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("ItemSprite"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("Description"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("Value"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("Rate"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("itemtype"));

        switch (type.itemtype)
        {
            case Items.ItemType.Supplies:
                EditorGUILayout.PropertyField(serializedObject.FindProperty("itemsupplies"));
                break;
            case Items.ItemType.Gear:
                EditorGUILayout.PropertyField(serializedObject.FindProperty("itemgear"));
                break;
        }

        serializedObject.ApplyModifiedProperties();
    }
}
