using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanctionCube : MonoBehaviour
{
    //Using prefab to create, configure, and store a GameObject complete with all its components, property values.
    public GameObject sampleCubePrefab;

    //To make 512 cubes
    GameObject[] sampleCube = new GameObject[512];
    public float maxScale;
    // Start is called before the first frame update
    void Start()
    {
        //Using loop to instantiation the 512 cubes
        for(int i = 0; i < 512; i++)
        {
            GameObject instanceSampleCube = (GameObject)Instantiate (sampleCubePrefab);
            instanceSampleCube.transform.position = this.transform.position;

            //Make child of object in this class running
            instanceSampleCube.transform.parent = this.transform;
            instanceSampleCube.name = "SampleCube" + i;

            //This is calculate how position for 512 cubes make a circle
            this.transform.eulerAngles = new Vector3(0, -0.703125f * i, 0);
            instanceSampleCube.transform.position = Vector3.forward * 100;

            //Make sampleCube in list can use in update
            sampleCube [i] = instanceSampleCube;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Make the cubes work
        for(int i = 0; i < 512; i++)
        {
            //To check is the 512 cubes work correctly.
            if(sampleCube != null)
            {
                sampleCube[i].transform.localScale = new Vector3(10, (AudioVisable.samples[i] * maxScale) + 2, 10);
            }
        }
    }
}
