using System.Linq;

using BepInEx;
using BepInEx.Configuration;
using BepInEx.IL2CPP;

using HarmonyLib;

using AmongUs.GameOptions;


namespace ExtremeRoles
{

    [BepInAutoPlugin("me.yukieiji.test", "BeplnEx 550")]
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
        public enum TestEnum
        {
            data,
            data2,
        }

        public static void Postfix()
        {
            roleTypeNullAble();
            testClassNullAble();
        }
        private static void roleTypeNullAble()
        {
            Il2CppSystem.Nullable<RoleTypes> roleType = new Il2CppSystem.Nullable<RoleTypes>(
                RoleTypes.Shapeshifter);
            BeplnExPlugin.Logger.LogDebug(roleType.Value);
        }

        private static void testClassNullAble()
        {
            Il2CppSystem.Nullable<TestEnum> test = new Il2CppSystem.Nullable<TestEnum>(TestEnum.data);
            BeplnExPlugin.Logger.LogDebug(test.Value);
        }
    }

}
