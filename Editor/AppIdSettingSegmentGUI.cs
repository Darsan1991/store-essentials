using UnityEditor;
using UnityEngine;

namespace Settings
{
    public class AppIdSettingSegmentGUI : SettingSegmentGUI
    {
        private readonly SerializedProperty _iosAppId;

        public AppIdSettingSegmentGUI(SerializedProperty iosAppId)
        {
            _iosAppId = iosAppId;
        }

        protected override void DrawGUI()
        {
            EditorGUILayout.BeginVertical(GUI.skin.box);
            EditorGUILayout.LabelField("App Ids", EditorStyles.boldLabel);
            EditorGUI.indentLevel++;
            EditorGUILayout.HelpBox("The App id require to create rating url. This is only for ios build.",
                MessageType.Info);
            EditorGUILayout.PropertyField(_iosAppId);
            EditorGUI.indentLevel--;
            EditorGUILayout.EndVertical();
        }

        protected override void ApplyModifiedProperties()
        {
            _iosAppId.serializedObject.ApplyModifiedProperties();
        }
    }
}