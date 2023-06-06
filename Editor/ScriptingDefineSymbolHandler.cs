using System.Linq;
using UnityEditor;

public static class ScriptingDefineSymbolHandler
{
    public static bool HaveBuildSymbol(BuildTargetGroup group, string symbol)
    {
        var scriptingDefineSymbolsForGroup = PlayerSettings.GetScriptingDefineSymbolsForGroup(group);
        var strings = scriptingDefineSymbolsForGroup.Split(';').ToList();

        return strings.Contains(symbol);
    }

    public static void AddBuildSymbol(BuildTargetGroup group, string symbol)
    {
        if (HaveBuildSymbol(group, symbol))
            return;
        var scriptingDefineSymbolsForGroup = PlayerSettings.GetScriptingDefineSymbolsForGroup(group);
        var strings = scriptingDefineSymbolsForGroup.Split(';').ToList();
        strings.Add(symbol);
        var str = "";
        foreach (var s in strings)
        {
            str += s + ";";
        }

        PlayerSettings.SetScriptingDefineSymbolsForGroup(group, str);
    }

    public static void RemoveBuildSymbol(BuildTargetGroup group, string symbol)
    {
        if (!HaveBuildSymbol(group, symbol))
            return;
        var scriptingDefineSymbolsForGroup = PlayerSettings.GetScriptingDefineSymbolsForGroup(group);
        var strings = scriptingDefineSymbolsForGroup.Split(';').ToList();
        strings.Remove(symbol);
        var str = "";
        foreach (var s in strings)
        {
            str += s + ";";
        }

        PlayerSettings.SetScriptingDefineSymbolsForGroup(group, str);
    }

    public static void HandleScriptingSymbol(BuildTargetGroup buildTargetGroup, bool enable, string key)
    {
        var scriptingDefineSymbolsForGroup = PlayerSettings.GetScriptingDefineSymbolsForGroup(buildTargetGroup);
        var strings = scriptingDefineSymbolsForGroup.Split(';').ToList();

        if (enable)
        {
            strings.Add(key);
        }
        else
        {
            strings.Remove(key);
        }


        PlayerSettings.SetScriptingDefineSymbolsForGroup(buildTargetGroup, string.Join(";", strings.Distinct()));
    }
}