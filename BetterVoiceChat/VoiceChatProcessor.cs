using System;
using SpeexDSPSharp.Core;

namespace BetterVoiceChat;

public sealed class VoiceChatProcessor(int sampleRate, int frameSize) : IDisposable
{
    public int SampleRate { get; } = sampleRate;
    public int FrameSize { get; } = frameSize;

    private readonly short[] _buffer = new short[frameSize];
    
    public bool UseDenoise
    {
        get;
        set
        {
            if (value == field)
                return;
            field = value;
            var input = value ? 1 : 0;
            _preprocessor.Ctl(PreprocessorCtl.SPEEX_PREPROCESS_SET_DENOISE, ref input);
        }
    }
    
    public bool UseAGC
    {
        get;
        set
        {
            if (value == field)
                return;
            field = value;
            var input = value ? 1 : 0;
            _preprocessor.Ctl(PreprocessorCtl.SPEEX_PREPROCESS_SET_AGC, ref input);
        }
    }

    public float AGCTarget
    {
        get;
        set
        {
            if (Math.Abs(field - value) < 0.0001f)
                return;
            field = value;
            var input = (int)Math.Round(value * 30000);
            _preprocessor.Ctl(PreprocessorCtl.SPEEX_PREPROCESS_SET_AGC_TARGET, ref input);
        }
    } = 1.0f;
    
    private readonly SpeexDSPPreprocessor _preprocessor = new(frameSize, sampleRate);

    public void Dispose()
    {
        _preprocessor.Dispose();
    }

    public void Run(Span<float> buffer)
    {
        for (int i = 0; i < _buffer.Length; i++)
        {
            _buffer[i] = (short)Math.Clamp(MathF.Round(buffer[i] * (short.MaxValue + 1)), short.MinValue, short.MaxValue);
        }

        _preprocessor.Run(_buffer);

        for (int i = 0; i < _buffer.Length; i++)
        {
            buffer[i] = _buffer[i] / (float)(short.MaxValue + 1);
        }
    }
}