using UnityEngine;
using UnityEditor;

namespace BrainlessPet.Tools
{
    [CustomEditor(typeof(EnumsGenerator))]
    public class EnumGeneratorEditor : Editor
    {
         public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            EnumsGenerator enumsGenerator = (EnumsGenerator) target;

            EditorGUILayout.Space();
            EditorGUILayout.LabelField("In Editor Mode");
            if (GUILayout.Button("Generate Enum"))
            {
                enumsGenerator.Generate();
            }
        }
    }
}
