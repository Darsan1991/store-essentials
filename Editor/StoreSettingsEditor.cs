using System.Collections.Generic;
using System.Linq;
using Settings;
using UnityEditor;
using UnityEngine;

namespace DGames.Store
{
    //[CustomEditor(typeof(StoreSettings))]

    public class StoreSettingsEditor : Editor
    {


        private readonly List<ISettingSegmentGUI> _segmentGuis = new();

        private void OnEnable()
        {
            _segmentGuis.Clear();
            _segmentGuis.AddRange(new ISettingSegmentGUI[]
            {
                new AppIdSettingSegmentGUI(serializedObject.FindProperty(StoreSettings.IOS_APP_ID)),
            });

        }

        public override void OnInspectorGUI()
        {
            foreach (var settingSegmentGUI in _segmentGuis)
            {
                settingSegmentGUI.OnGUI();
                EditorGUILayout.Space();
                EditorGUILayout.Space();
            }

            DrawFixIfNeeded();
        }

        private void DrawFixIfNeeded()
        {
            if (MissingSymbols())
            {
                if (GUILayout.Button("Fix Missing Symbols"))
                {
                    FixMissingSymbols();
                }
            }
        }

        private void FixMissingSymbols()
        {
            foreach (var settingSegmentGUIWithSymbols in _segmentGuis.OfType<ISettingSegmentGUIWithSymbols>()
                         .Where(s => s.HasSymbolsProblem()))
            {
                settingSegmentGUIWithSymbols.FixSymbolsProblem();
            }
        }

        private bool MissingSymbols()
        {
            return _segmentGuis.OfType<ISettingSegmentGUIWithSymbols>().Any(s => s.HasSymbolsProblem());
        }


    }
}