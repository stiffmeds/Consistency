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
        internal const int ModDate = 20240117;
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
        /* devs patched this method in version 1.3.02
        [HarmonyPrefix]
        [HarmonyPatch(typeof(GameManager), "Awake")]
        public static void GameManagerAwakePrefix(ref GameManager __instance)
        {
            Traverse.Create(__instance).Field("pDXEnabled").SetValue(false);
        }*/

        [HarmonyPrefix]
        [HarmonyPatch(typeof(MainMenuManager), "CreatePDXDropdowns")]
        public static bool CreatePDXDropdownsPrefix(ref MainMenuManager __instance)
        {
            __instance.ResetPDXScreens();
            __instance.paradoxT.gameObject.SetActive(false);
            return false; // do not run original method
        }

        [HarmonyPrefix]
        [HarmonyPatch(typeof(MainMenuManager), "ShowPDXPreLogin")]
        public static bool ShowPDXPreLoginPrefix(ref MainMenuManager __instance)
        {
            __instance.ResetPDXScreens();
            __instance.paradoxT.gameObject.SetActive(false);
            return false; // do not run original method
        }

        [HarmonyPrefix]
        [HarmonyPatch(typeof(MainMenuManager), "ShowPDXLogin")]
        public static bool ShowPDXLoginPrefix(ref MainMenuManager __instance)
        {
            __instance.ResetPDXScreens();
            __instance.paradoxT.gameObject.SetActive(false);
            return false; // do not run original method
        }

        [HarmonyPrefix]
        [HarmonyPatch(typeof(MainMenuManager), "ShowPDXLogged")]
        public static bool ShowPDXLoggedPrefix(ref MainMenuManager __instance)
        {
            __instance.ResetPDXScreens();
            __instance.paradoxT.gameObject.SetActive(false);
            return false; // do not run original method
        }

        [HarmonyPrefix]
        [HarmonyPatch(typeof(Paradox.Startup), "ShowDocumentFromStartup")]
        public static bool ShowDocumentFromStartupPrefix()
        {
            Paradox.Startup.waitingForLoginDocuments = false;
            MainMenuManager.Instance.paradoxDocumentPopup.gameObject.SetActive(false);
            return false; // do not run original method
        }

        [HarmonyPrefix]
        [HarmonyPatch(typeof(Paradox.Telemetry), "SendStartGame")]
        public static bool SendStartGamePrefix()
        {
            return false; // do not run original method
        }

        [HarmonyPrefix]
        [HarmonyPatch(typeof(Paradox.Telemetry), "SendPlaysessionStart")]
        public static bool SendPlaysessionStartPrefix()
        {
            return false; // do not run original method
        }

        [HarmonyPrefix]
        [HarmonyPatch(typeof(Paradox.Telemetry), "SendPlaysessionEnd")]
        public static bool SendPlaysessionEndPrefix()
        {
            return false; // do not run original method
        }

        [HarmonyPrefix]
        [HarmonyPatch(typeof(Paradox.Telemetry), "SendActStart")]
        public static bool SendActStartPrefix()
        {
            return false; // do not run original method
        }

        [HarmonyPrefix]
        [HarmonyPatch(typeof(Paradox.Telemetry), "SendUnlock")]
        public static bool SendUnlockPrefix()
        {
            return false; // do not run original method
        }
    }
}
