using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioVisable : MonoBehaviour
{
    public static AudioVisable Instance;
    private void Awake()
    {
        Instance = this;
    }
    AudioSource audioSource;
    public static float[] samples = new float[512];
    public static float[] freqenceCubes = new float[8];
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();   
    }

    // Update is called once per frame
    void Update()
    {
        GetSpectrumAudioSource();
        GetFreqenceCubes();
    }

    void GetSpectrumAudioSource()
    {
        audioSource.GetSpectrumData(samples, 0, FFTWindow.Blackman);
    }

    void GetFreqenceCubes()
    {
        int count = 0;

        for(int i = 0; i < 8; i++)
        {
            float average = 0;
            int sampleCount = (int)Mathf.Pow (2, i) * 2;
            if(i == 7)
            {
                sampleCount += 2;
            }

            for(int j = 0; j < sampleCount; j++)
            {
                average += samples[count] * (count + 1);
                count++;
            }

            average /= count;

            freqenceCubes[i] = average * 10;
        }
    }
}