﻿using DGames.Temp;
using UnityEngine;

namespace DGames.Store
{
    public partial

    class StoreSettings : ScriptableObject
    {
        public const string DEFAULT_NAME = nameof(StoreSettings);


        [SerializeField] private string _iosAppId;
        public string IosAppId => _iosAppId;





#if UNITY_EDITOR
        [UnityEditor.MenuItem("MyGames/Settings/Store")]
        public static void Open()
        {
            ScriptableEditorUtils.OpenOrCreateDefault<StoreSettings>();
        }
#endif
    }

    public partial class StoreSettings
    {
        public static StoreSettings Default => Resources.Load<StoreSettings>(nameof(StoreSettings));
    }


    public partial class StoreSettings
    {

        public const string IOS_APP_ID = nameof(_iosAppId);



    }



}