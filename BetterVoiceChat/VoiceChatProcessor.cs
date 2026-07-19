using System;
using SpeexDSPSharp.Core;

namespace BetterVoiceChat;

internal sealed class VoiceChatProcessor(int sampleRate, int frameSize) : IDisposable
{
    public int SampleRate { get; } = sampleRate;
    public int FrameSize { get; } = frameSize;

    private readonly short[] _buffer = new short[frameSize];
    
    private readonly SpeexDSPPreprocessor _preprocessor = new(frameSize, sampleRate);

    public void Dispose()
    {
        _preprocessor.Dispose();
    }
    
    public bool UseDenoise
    {
        get;
        set
        {
            if (field == value)
                return;
            field = value;

            var input = value ? 1 : 0;
            _preprocessor.Ctl(PreprocessorCtl.SPEEX_PREPROCESS_SET_DENOISE, ref input);
        }
    }
    
    public void Run(Span<float> buffer)
    {
        if (buffer.Length != FrameSize)
        {
            throw new ArgumentException(
                $"Expected the length of '{nameof(buffer)}' to be '{FrameSize}', got '{buffer.Length}' instead");
        }
        
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