using BepInEx;
using BepInEx.Configuration;
using BepInEx.Unity.IL2CPP;

using HarmonyLib;

using Innersloth.Assets;

namespace IssueProject;


[BepInAutoPlugin("me.yukieiji.test", "BeplnEx.CantPatchGenericClass")]
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

[HarmonyPatch(typeof(AddressableAsset<HatViewData>), nameof(AddressableAsset<HatViewData>.GetAsset))]
public static class HAddressableAssetGetAssetPatch
{
    public static bool Prefix(HatViewData __result)
    {
        BeplnExPlugin.Logger.LogInfo("Called!!");
        return true;
    }
}
