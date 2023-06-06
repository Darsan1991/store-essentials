using UnityEditor;

namespace Settings
{
    public abstract class SettingSegmentGUI : ISettingSegmentGUI
    {
        public void OnGUI()
        {
            EditorGUI.BeginChangeCheck();

            DrawGUI();

            if (EditorGUI.EndChangeCheck())
            {
                ApplyModifiedProperties();
            }

        }

        protected abstract void ApplyModifiedProperties();
        protected abstract void DrawGUI();
    }
}