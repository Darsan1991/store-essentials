using System.Collections.Generic;
using System.Linq;
using Settings;
using UnityEditor;
using UnityEngine;

namespace DGames.Store
{
    [CustomEditor(typeof(StoreSettings))]

    public class GameSettingsEditor : Editor
    {


        private readonly List<ISettingSegmentGUI> _segmentGuis = new();

        private void OnEnable()
        {
            _segmentGuis.Clear();
            _segmentGuis.AddRange(new ISettingSegmentGUI[]
            {
                new AppIdSettingSegmentGUI(serializedObject.FindProperty(StoreSettings.IOS_APP_ID)),
                // new AdsSettingsSegmentGUI(serializedObject.FindProperty(GameSettings.ADS_SETTINGS)),
#if DAILY_REWARD_SETTINGS
            new DailyRewardsSegmentGUI(serializedObject.FindProperty(GameSettings.DAILY_REWARD_SETTING)),
#endif
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


        //    private void DrawNotificationSetting()
        //    {
        ////        var enableProperty = _notificationSetting.FindPropertyRelative(nameof(NotificationSetting.enable));
        //
        //        EditorGUILayout.BeginVertical(GUI.skin.box);
        //        EditorGUILayout.BeginHorizontal();
        //        EditorGUILayout.LabelField("Notification Setting", EditorStyles.boldLabel);
        //        var enable = EditorGUILayout.ToggleLeft("", enableProperty.boolValue);
        //        EditorGUILayout.EndHorizontal();
        //        EditorGUI.indentLevel++;
        //
        //        if (enable != enableProperty.boolValue)
        //        {
        //            enableProperty.boolValue = enable;
        //            if (enableProperty.boolValue)
        //            {
        //                AddBuildSymbol(BuildTargetGroup.iOS, "NOTIFICATION");
        //                AddBuildSymbol(BuildTargetGroup.Android, "NOTIFICATION");
        //            }
        //            else
        //            {
        //                RemoveBuildSymbol(BuildTargetGroup.iOS, "NOTIFICATION");
        //                RemoveBuildSymbol(BuildTargetGroup.Android, "NOTIFICATION");
        //            }
        //        }
        //
        //        if (enableProperty.boolValue)
        //        {
        //            _notificationSetting.DrawChildrenDefault(nameof(NotificationSetting.enable));
        //        }
        //
        //        EditorGUI.indentLevel--;
        //        EditorGUILayout.EndVertical();
        //    }

    }
}