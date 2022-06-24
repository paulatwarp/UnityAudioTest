using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pluck : MonoBehaviour
{
    public RingBuffer ringBuffer;
    public Envelope pluck;
    public float fade = 0.996f;
    float tick;
    float [] previous = new float[2];
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PluckString();
        }
    }

    public void PluckString()
    {
        pluck.Pluck();
    }
    private void Start()
    {
        tick = 1.0f / AudioSettings.outputSampleRate;
    }
    void OnAudioFilterRead(float[] samples, int channels)
    {
        int index = 0;
        while (index < samples.Length)
        {
            float sample = (previous[0] + previous[1]) * 0.5f * fade;
            previous[0] = previous[1];
            previous[1] = ringBuffer.Sample(sample + pluck.Sample(tick));
            for (int channel = 0; channel < channels; ++channel)
            {
                samples[index + channel] = sample;
            }
            index += channels;
        }
    }
}
