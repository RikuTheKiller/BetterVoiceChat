using System.Collections.Generic;
using HarmonyLib;
using UnityEngine;

namespace BetterVoiceChat;

[HarmonyPatch(typeof(Settings))]
internal static class SettingsPatch
{
    [HarmonyPostfix]
    [HarmonyPatch("DefaultSettings")]
    private static void DefaultSettingsPostfix(List<Setting> __result)
    {
        Plugin.Logger?.LogInfo("Registering settings...");
        
        __result.Add(new SettingBool
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
        });

        __result.Add(new SettingFloat
        {
            name = ModSettings.PerceptualVolume,
            value = ModSettings.PerceptualVolumeDefault,
            min = 0f,
            max = 4f,
            apply = () =>
            {
                PlayerPrefs.SetFloat(ModSettings.PerceptualVolume,
                    Settings.Get<SettingFloat>(ModSettings.PerceptualVolume).value);
                PlayerPrefs.Save();
            },
            formatValue = v => $"{Mathf.RoundToInt(v * 100f)}%",
            category = Setting.SettingCategory.Audio
        });
        
        Plugin.Logger?.LogInfo("Registered settings successfully!");
    }
}