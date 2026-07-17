using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using KrokoshaCasualtiesMP;

namespace BetterVoiceChat;

[BepInProcess("CasualtiesUnknown.exe")]
[BepInPlugin(ModGUID, ModName, ModVersion)]
[BepInDependency("KrokoshaCasualtiesMP")]
public class Plugin : BaseUnityPlugin
{
    public const string ModGUID = "rikuthekiller.casualties.bettervoicechat";
    public const string ModName = MyPluginInfo.PLUGIN_NAME; // To change .dll name, change the name in vars.targets
    public const string ModVersion = MyPluginInfo.PLUGIN_VERSION;

    internal new static ManualLogSource? Logger;
    private readonly Harmony _harmony = new(ModGUID);
    internal static VoiceChatProcessor? Processor;
    
    [DllImport("kernel32.dll", SetLastError = true)]
    private static extern IntPtr LoadLibrary(string lpFileName);

    public void Awake()
    {
        Logger = base.Logger;
        
        var assembly = Assembly.GetExecutingAssembly();
        
        Logger.LogInfo("Loading native SpeexDSP binary...");
        string modFolderPath = Path.GetDirectoryName(assembly.Location) ?? assembly.Location;
        string nativeBinaryPath = Path.Combine(modFolderPath, $"{(Environment.Is64BitOperatingSystem ? "x64" : "x86")}\\speexdsp.dll");
        LoadLibrary(nativeBinaryPath);
        
        Logger.LogInfo("Creating voice chat processor...");
        Processor = new(Voicechat.SAMPLE_RATE, Voicechat.FRAME_SIZE);
        
        Logger.LogInfo("Patching all relevant methods...");
        _harmony.PatchAll();
        
        Logger.LogInfo("Loaded successfully!");
    }

    public void OnDestroy()
    {
        _harmony.UnpatchSelf();
        Processor?.Dispose();
    }
}
