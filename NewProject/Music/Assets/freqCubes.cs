using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class freqCubes : MonoBehaviour
{
    public int cubes;
    public float startScale, scaleMultiplier;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3(transform.localScale.x, (AudioVisable.freqenceCubes[cubes] * scaleMultiplier) + startScale, transform.localScale.z);
    }
}
