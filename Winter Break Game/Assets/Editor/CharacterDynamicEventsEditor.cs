using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Reflection;
using System.Linq;
using UnityEngine.Events;

[CustomEditor(typeof(Character))]
public class CharacterDynamicEventsEditor : Editor
{
    SerializedProperty configProp;
    SerializedProperty eventList;
    
    private void OnEnable()
    {
        configProp = serializedObject.FindProperty("configManager").FindPropertyRelative("config");
        eventList = serializedObject.FindProperty("eventManager").FindPropertyRelative("inspectorHandler").FindPropertyRelative("Events");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.PropertyField(configProp);
        EditorGUILayout.Space(3);

        GUI.skin.label.fontSize = 30;

        GUILayout.BeginVertical();
        GUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();
        
        EditorGUILayout.LabelField("Events In Character", EditorStyles.boldLabel);
        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();
        GUILayout.EndVertical();

        EditorGUILayout.PropertyField(eventList);

        Character character = (Character)target;
        //character.eventManager.UpdateCharacterEvents((CharacterConfig)configProp.objectReferenceValue);
        EventManagerInspectorHandler eventInspectorHandler = (EventManagerInspectorHandler)character.eventManager.GetType().GetField("inspectorHandler", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(character.eventManager);
        
        eventInspectorHandler.UpdateCharacterEvents(character, character.configManager);

        serializedObject.ApplyModifiedProperties();
    }
}
