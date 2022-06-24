using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Envelope : MonoBehaviour
{
    public AnimationCurve envelope;
    public Oscillator source;
    float time;

    public void Pluck()
    {
        time = 0;
        source.Trigger();
    }

    public float Sample(float tick)
    {
        float sample = source.Sample(tick) * envelope.Evaluate(time);
        time += tick;
        return sample;
    }
}
