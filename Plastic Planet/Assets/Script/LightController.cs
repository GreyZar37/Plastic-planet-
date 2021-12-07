using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LightController : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(DayAndNight.night == true)
        {
           gameObject.GetComponent<Light2D>().enabled = true;
        }
        else
        {
            gameObject.GetComponent<Light2D>().enabled = false;
        }
    }
}
