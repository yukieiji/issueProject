using System.Linq;

using BepInEx;
using BepInEx.Configuration;
using BepInEx.IL2CPP;

using HarmonyLib;


namespace ExtremeRoles
{

    [BepInAutoPlugin("me.yukieiji.test", "BeplnEx 411")]
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

    [HarmonyPatch(typeof(MainMenuManager), nameof(MainMenuManager.Start))]
    public static class MainMenuManagerStartPatch
    {
        public static void Postfix()
        {
            BeplnExPlugin.Logger.LogInfo(
                TranslationController.Instance.GetString(StringNames.Tasks));
        }
    }

}
