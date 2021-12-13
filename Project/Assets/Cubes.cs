using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject CubesPrefab;
    
    GameObject[] Cubes = new GameObject[512];

    public float maxScale;

    // Start is called before the first frame update
    void Start()
    {
        for(int i =0; i < 512; i++)
        {
            GameObject InstanceCube = (GameObject)Instantiate (CubesPrefab);
            InstanceCube.transform.position = this.transform.position;
            InstanceCube.transform.parent = this.transform;
            InstanceCube.name = "SampleCube" + i;
            this.transform.eulerAngles = new Vector3 (0, -0.703125f *i, 0);
            InstanceCube.transform.position = Vector3.forward * 100;
            Cubes[i] = InstanceCube;
        }
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < 512; i++)
        {
            if(Cubes != null)
            {
                Cubes[i].transform.localscale = new Vector3(10, (AudioVisable.samples[i] * maxScale) + 2, 10);
            }
        }
    }
}