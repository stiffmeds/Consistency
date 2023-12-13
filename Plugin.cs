using BepInEx;
using HarmonyLib;
using BepInEx.Logging;
using BepInEx.Bootstrap;

namespace Consistency
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    [BepInProcess("AcrossTheObelisk.exe")]
    public class Plugin : BaseUnityPlugin
    {
        internal const int ModDate = 20231213;
        private readonly Harmony harmony = new(PluginInfo.PLUGIN_GUID);

        private void Awake()
        {
            Logger.LogInfo($"{PluginInfo.PLUGIN_GUID} {PluginInfo.PLUGIN_VERSION} is loaded!");
            harmony.PatchAll();
        }
    }
    [HarmonyPatch]
    internal class Patches
    {
        [HarmonyPrefix]
        [HarmonyPatch(typeof(GameManager), "Awake")]
        public static void GameManagerAwakePrefix(ref GameManager __instance)
        {
            Traverse.Create(__instance).Field("pDXEnabled").SetValue(false);
        }
    }
}
