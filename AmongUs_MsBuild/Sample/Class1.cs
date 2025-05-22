using BepInEx;
using BepInEx.Configuration;
using BepInEx.Unity.IL2CPP;

using HarmonyLib;

namespace Sample;

[BepInAutoPlugin("me.yukieiji.sample", "sample")]
[BepInProcess("Among Us.exe")]
public partial class ExtremeRolesPlugin : BasePlugin
{
    public override void Load()
    {

    }
}