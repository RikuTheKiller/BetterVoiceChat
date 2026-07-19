using HarmonyLib;
using KrokoshaCasualtiesMP;
using UnityEngine;

namespace BetterVoiceChat;

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

        Plugin.Processor.UseDenoise = Settings.Get<SettingBool>(ModSettings.NSEnabledId).value;
        Plugin.Processor.Run(data);
        
        for (int i = 0; i < data.Length; i++)
        {
            data[i] *= PerceptualVolume.ToLinearGain(Settings.Get<SettingFloat>(ModSettings.PerceptualVolume).value);
        }
    }
}