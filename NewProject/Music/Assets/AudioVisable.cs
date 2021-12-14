using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// The required componet is automatically added to the GameObject.
[RequireComponent(typeof(AudioSource))]
public class AudioVisable : MonoBehaviour
{
    public static AudioVisable Instance;

    //An AudioSource is attached to a GameObject for playing back souds in a 3D environment.
    AudioSource audioSource;

    //To create 512 cubes
    public static float[] samples = new float[512];
    //To create 8 cubes
    public static float[] freqenceCubes = new float[8];

    // Start is called before the first frame update
    void Start()
    {
        //This is fetch the AudioSource from the GameObject
        audioSource = GetComponent<AudioSource>();   
    }

    // Update is called once per frame
    void Update()
    {
        //To play the audio attach to the AudioSource component
        GetSpectrumAudioSource();
        //To get freqence cubes
        GetFreqenceCubes();
    }

    void GetSpectrumAudioSource()
    {
        //This is provides a block of the currently playing audio source's spectrum data.
        audioSource.GetSpectrumData(samples, 0, FFTWindow.Blackman);
    }

    void GetFreqenceCubes()
    {
        int count = 0;

        //Using loop to get diferent hertz for 8 cubes
        for(int i = 0; i < 8; i++)
        {
            float average = 0;
            //This function is power of a number means how many time to use the number in multiplication
            int sampleCount = (int)Mathf.Pow(2, i) * 2;


            if(i == 7)
            {
                sampleCount += 2;
            }

            //Using this loop to send the sampleCount to freqenceCubes
            for(int j = 0; j < sampleCount; j++)
            {
                average += samples[count] *  (count + 1);
                count++;
            }

            average /= count;

            //This is apply average to te freqenceCubes
            freqenceCubes[i] = average * 10;
        }
    }
}