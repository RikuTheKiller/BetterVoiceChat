using System;

namespace BetterVoiceChat;

internal class PerceptualVolume
{
    private const float DbPerDoubling = 10f;
    
    private static readonly float Exponent = DbPerDoubling * MathF.Log(10) / (20f * MathF.Log(2));

    public static float ToLinearGain(float loudnessRatio)
    {
        if (loudnessRatio <= 0f)
            return 0f;
        
        return MathF.Pow(loudnessRatio, Exponent);
    }
}