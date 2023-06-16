using BepInEx;
using BepInEx.Configuration;
using BepInEx.Unity.IL2CPP;

using HarmonyLib;


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

[HarmonyPatch(
    typeof(DestroyableSingleton<HudManager>),
    nameof(DestroyableSingleton<HudManager>.Instance),
    MethodType.Getter)]
public static class TestPatch
{
    public static bool Prefix(DestroyableSingleton<HudManager> __instance)
    {
        BeplnExPlugin.Logger.LogInfo("Called!!");
        return true;
    }
}
