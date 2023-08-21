using DGames.Essentials.Attributes;
using UnityEngine;

namespace DGames.Store
{
    [DashboardResourceItem(path:"Settings")]

    public partial

    class StoreSettings : ScriptableObject
    {

[HelpBox("The App id require to create rating url. This is only for ios build.")]
        [SerializeField] private string _iosAppId;
        public string IosAppId => _iosAppId;





#if UNITY_EDITOR
        [UnityEditor.MenuItem("MyGames/Settings/Store")]
        public static void Open()
        {
            Temp.ScriptableEditorUtils.OpenOrCreateDefault<StoreSettings>();
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
