namespace BetterVoiceChat;

public static class ModSettings
{
    public const string NSEnabledId = "bettervoicechat.audio.noisesuppressionenabled";
    public const bool NSEnabledDefault = true;
    public const string AGCEnabledId = "bettervoicechat.audio.automaticgaincontrolenabled";
    public const bool AGCEnabledDefault = true;
    public const string AGCTargetId = "bettervoicechat.audio.automaticgaincontroltarget";
    public const float AGCTargetDefault = 1f;
}