using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class deathCount : MonoBehaviour
{
    public static int death_cnt = 0;
    Text death;
    // Start is called before the first frame update
    void Start()
    {
        death = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (death_cnt == 1)
        {
            death.text = "you've died once";
        }
        else
        {
            death.text= "you've died " + death_cnt + " times";
        } 
    }
}
