using BepInEx;
using BepInEx.Configuration;
using BepInEx.Unity.IL2CPP;

using HarmonyLib;

namespace IssueProject;


[BepInAutoPlugin("me.yukieiji.test", "BeplnEx.SameOverrideMethodPatch")]
[BepInProcess("Among Us.exe")]
public partial class BeplnExPlugin : BasePlugin
{
    public Harmony Harmony { get; } = new Harmony(Id);

    internal static BepInEx.Logging.ManualLogSource Logger;
    public static ConfigEntry<bool> DebugMode { get; private set; }

    public override void Load()
    {
        Logger = Log;
        Harmony.PatchAll();
    }
}

[HarmonyPatch(typeof(HatData), nameof(HatData.CreateAddressableAsset))]
public static class HatDataPatch
{
    public static bool Prefix()
    {
        BeplnExPlugin.Logger.LogInfo("HatData Called!!");
        return true;
    }
}

[HarmonyPatch(typeof(VisorData), nameof(VisorData.CreateAddressableAsset))]
public static class VisorDataPatch
{
    public static bool Prefix()
    {
        BeplnExPlugin.Logger.LogInfo("VisorData Called!!");
        return true;
    }
}

[HarmonyPatch(typeof(NamePlateData), nameof(NamePlateData.CreateAddressableAsset))]
public static class NamePlateDataPatch
{
    public static bool Prefix()
    {
        BeplnExPlugin.Logger.LogInfo("NamePlateData Called!!");
        return true;
    }
}
