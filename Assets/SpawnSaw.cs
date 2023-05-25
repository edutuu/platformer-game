using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnSaw : MonoBehaviour
{
    public GameObject saw;
    public float spawnTime;
    private float timer1 = 0;
   

    // Update is called once per frame
    void Update()
    {
        if(timer1<spawnTime)
        {
            timer1 = timer1 + Time.deltaTime;
        }
        else
        {
            Instantiate(saw, transform.position, transform.rotation);
            timer1 = 0;
           
        }

    }

}
