using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitchBend : MonoBehaviour
{
    public float pitch = 440.0f;
    float tick;
    public Oscillator tone;
    public Oscillator bend;

    private void Start()
    {
        tick = 1.0f / AudioSettings.outputSampleRate;
    }

    void OnAudioFilterRead(float[] samples, int channels)
    {
        int index = 0;
        while (index < samples.Length)
        {
            tone.frequency = pitch * (1.0f + bend.Sample(tick));
            float sample = tone.Sample(tick);
            for (int channel = 0; channel < channels; ++channel)
            {
                samples[index + channel] = sample;
            }
            index += channels;
        }
    }
}
