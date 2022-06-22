using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitchBend : MonoBehaviour
{
    public AudioSource source;
    public float frequency = 1;
    public float amplitude = 1;
    float time;

    private void Start()
    {
    }

    void Update()
    {
        time += Time.fixedDeltaTime * 2f * Mathf.PI * frequency;
        source.pitch = 1.0f + Mathf.Sin(time) * amplitude;
    }
}
