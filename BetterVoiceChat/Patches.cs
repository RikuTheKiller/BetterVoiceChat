using System.Collections.Generic;
using HarmonyLib;
using KrokoshaCasualtiesMP;
using UnityEngine;

namespace BetterVoiceChat;

internal static class Patches
{
    [HarmonyPatch(typeof(Voicechat))]
    internal static class VoiceChatPatch
    {
        [HarmonyPrefix]
        [HarmonyPatch("Client_SendMicDataFrame")]
        private static void SendMicDataFramePrefix(float[] data, bool is_not_last)
        {
            if (Plugin.Processor == null || Plugin.Processor.SampleRate != Voicechat.SAMPLE_RATE ||
                Plugin.Processor.FrameSize != Voicechat.FRAME_SIZE)
            {
                Plugin.Processor?.Dispose();
                Plugin.Processor = new(Voicechat.SAMPLE_RATE, Voicechat.FRAME_SIZE);
            }

            Plugin.Processor.UseDenoise =
                PlayerPrefs.GetInt(ModSettings.NSEnabledId, ModSettings.NSEnabledDefault ? 1 : 0) == 1;
            Plugin.Processor.UseAGC =
                PlayerPrefs.GetInt(ModSettings.AGCEnabledId, ModSettings.AGCEnabledDefault ? 1 : 0) == 1;
            Plugin.Processor.AGCTarget =
                PlayerPrefs.GetFloat(ModSettings.AGCTargetId, ModSettings.AGCTargetDefault);
            
            Plugin.Processor.Run(data);
        }
    }

    [HarmonyPatch(typeof(Settings))]
    internal static class SettingsPatch
    {
        [HarmonyPostfix]
        [HarmonyPatch("DefaultSettings")]
        private static void DefaultSettingsPostfix(List<Setting> __result)
        {
            Plugin.Logger?.LogInfo("Registering settings...");
            
            SettingBool nsEnabled = new()
            {
                name = ModSettings.NSEnabledId,
                value = ModSettings.NSEnabledDefault,
                apply = () =>
                {
                    PlayerPrefs.SetInt(ModSettings.NSEnabledId,
                        Settings.Get<SettingBool>(ModSettings.NSEnabledId).value ? 1 : 0);
                    PlayerPrefs.Save();
                },
                category = Setting.SettingCategory.Audio
            };
            
            __result.Add(nsEnabled);

            SettingBool agcEnabled = new()
            {
                name = ModSettings.AGCEnabledId,
                value = ModSettings.AGCEnabledDefault,
                apply = () =>
                {
                    PlayerPrefs.SetInt(ModSettings.AGCEnabledId,
                        Settings.Get<SettingBool>(ModSettings.AGCEnabledId).value ? 1 : 0);
                    PlayerPrefs.Save();
                },
                category = Setting.SettingCategory.Audio
            };
            
            __result.Add(agcEnabled);

            SettingFloat agcTarget = new()
            {
                name = ModSettings.AGCTargetId,
                value = ModSettings.AGCTargetDefault,
                min = 0.5f,
                max = 2f,
                apply = () =>
                {
                    PlayerPrefs.SetFloat(ModSettings.AGCTargetId,
                        Settings.Get<SettingFloat>(ModSettings.AGCTargetId).value);
                    PlayerPrefs.Save();
                },
                formatValue = v => $"{Mathf.RoundToInt(v * 100f)}%",
                category = Setting.SettingCategory.Audio
            };
            
            __result.Add(agcTarget);
            
            Plugin.Logger?.LogInfo("Registered settings successfully!");
        }
    }

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
            
            Locale.currentLang.other.Add($"gameset{ModSettings.AGCEnabledId}", "VC automatic gain control");
            Locale.currentLang.other.Add($"gameset{ModSettings.AGCEnabledId}dsc",
                "Toggle multiplayer voice chat automatic gain control (makes quiet mics/whispers louder and vice versa)");
            
            Locale.currentLang.other.Add($"gameset{ModSettings.AGCTargetId}", "VC automatic gain control target");
            Locale.currentLang.other.Add($"gameset{ModSettings.AGCTargetId}dsc",
                "Set multiplayer voice chat automatic gain control target (increasing it makes you louder and vice versa)");
            
            Plugin.Logger?.LogInfo("Loaded custom localization bullshit successfully!");
        }
    }
}
