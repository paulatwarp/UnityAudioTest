using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator
{ 
    public float frequency = 440.0f;
    public float amplitude = 0.5f;
    float time;

    public Oscillator(float frequency, float amplitude)
    {
        this.frequency = frequency;
        this.amplitude = amplitude;
        time = 0;
    }

    public float Sample(float tick)
    {
        time = Mathf.Repeat(time + tick * frequency, 1f);
        return Mathf.Sin(time * 2.0f * Mathf.PI) * amplitude;
    }
}


public class PitchBend : MonoBehaviour
{
    public int frequency = 10;
    public float strength = 0.5f;
    public float pitch = 440.0f;
    public float amplitude = 1;
    float tick;
    Oscillator tone;
    Oscillator bend;

    private void Start()
    {
        tick = 1.0f / AudioSettings.outputSampleRate;
        tone = new Oscillator(pitch, amplitude);
        bend = new Oscillator(frequency, strength);
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
