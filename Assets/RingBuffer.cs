using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingBuffer : MonoBehaviour
{
    public float frequency;
    Queue<float> buffer;
    void Start()
    {
        int size = Mathf.CeilToInt((float)AudioSettings.outputSampleRate / frequency);
        buffer = new Queue<float>(size);
        for (int i = 0; i < size; ++i)
        {
            buffer.Enqueue(0.0f);
        }
    }

    public float Sample(float sample)
    {
        float output = buffer.Dequeue();
        buffer.Enqueue(sample);
        return output;
    }
}
