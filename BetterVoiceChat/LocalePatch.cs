using HarmonyLib;

namespace BetterVoiceChat;

[HarmonyPatch(typeof(Locale))]
internal static class LocalePatch
{
    [HarmonyPostfix]
    [HarmonyPatch(nameof(Locale.LoadLanguage))]
    private static void LoadLanguagePostfix()
    {
        Plugin.Logger?.LogInfo("Loading custom localization bullshit...");
            
        Locale.currentLang.other.Add($"gameset{ModSettings.NSEnabledId}", "VC noise suppression");
        Locale.currentLang.other.Add($"gameset{ModSettings.NSEnabledId}dsc",
            "Toggle multiplayer voice chat background noise suppression");
            
        Locale.currentLang.other.Add($"gameset{ModSettings.PerceptualVolume}", "VC perceptual mic volume");
        Locale.currentLang.other.Add($"gameset{ModSettings.PerceptualVolume}dsc",
            "Set multiplayer voice chat perceptual mic volume multiplier (increasing it makes you louder and vice versa, scales MUCH better than the default slider)");
            
        Plugin.Logger?.LogInfo("Loaded custom localization bullshit successfully!");
    }
}