using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    public int max = 64;
    public GameObject cube1;
    [HideInInspector]
    //public static float Range(float min, float max);

    // Instantiate the Prefab somewhere between -10.0 and 10.0 on the x-z plane
    void Start() => spawn();

    // Update is called once per frame
    void Update()
    {
        
    }


    void spawn() 
    {
        for (var i = 0; i < max; i++)
        {
            Vector3 position = new Vector3(Random.Range(-10.0f, 10.0f), 0, Random.Range(-10.0f, 10.0f));
            Instantiate(cube1, position, Quaternion.identity);
        }
    }
}
