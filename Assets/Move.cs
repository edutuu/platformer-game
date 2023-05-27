using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Move : MonoBehaviour
{
   
    public float moveSpeed;
    private float timer2 = 0;
    public float destroyTime;

    void Update()
    {
        
        transform.position= transform.position + Vector3.left*moveSpeed * Time.deltaTime;

        if (timer2 < destroyTime)
        {
            timer2 = timer2 + Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
            timer2 = 0;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }


}
