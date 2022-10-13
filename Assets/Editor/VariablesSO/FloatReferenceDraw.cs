using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace BrainlessPet.Scriptables
{
    [CustomPropertyDrawer(typeof(FloatReference))]
    public class FloatReferenceDraw: PropertyDrawer 
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) 
        {
            EditorGUI.BeginProperty(position, label, property);

            SerializedProperty useConstanteProp = property.FindPropertyRelative("UseConstante");
            SerializedProperty constanteValueProp = property.FindPropertyRelative("ConstanteValue");
            SerializedProperty variableProp = property.FindPropertyRelative("Variable");

            Rect labelPosition = new Rect(position.x, position.y, position.width, position.height);

            position = EditorGUI.PrefixLabel(labelPosition, EditorGUIUtility.GetControlID(FocusType.Passive), label);

            int indent = EditorGUI.indentLevel;
            EditorGUI.indentLevel = 0;

            var dropdownRect = new Rect(position.x, position.y, 20, position.height);
		    var inputRect = new Rect(position.x + 20, position.y, position.width - 20, position.height);

            // remove background
            GUI.backgroundColor = new Color(0, 0, 0, 0);
            GUI.contentColor = new Color(0, 0, 0, 0);

            // Draw Icon
            var iconRect = new Rect(position.x, position.y, 20, position.height);
            Texture icon = EditorGUIUtility.Load("icons/d_UnityEditor.SceneHierarchyWindow.png") as Texture2D;
            GUI.DrawTexture(iconRect, icon);

            // Create Popup and find bool value
            int popup = EditorGUI.Popup(dropdownRect, useConstanteProp.boolValue? 0 : 1, new string[] { "Use Constant", "Use Variable" });
            useConstanteProp.boolValue = popup == 0 ? true : false;

            // Return colours
            GUI.backgroundColor = Color.white;
            GUI.contentColor = Color.white;

            // show appropriate input
            if (useConstanteProp.boolValue)
            {
                EditorGUI.PropertyField(inputRect, constanteValueProp, GUIContent.none);
            } else
            {
                EditorGUI.PropertyField(inputRect, variableProp, GUIContent.none);
            }
            EditorGUI.indentLevel = indent;
            EditorGUI.EndProperty();
        }
    }

}