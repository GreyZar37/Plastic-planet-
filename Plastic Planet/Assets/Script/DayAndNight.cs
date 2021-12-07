using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class DayAndNight : MonoBehaviour
{
    public static bool day;
    public static bool night;


    public Light2D sun;

    public float dayTime = 1.2f;
    public float nightTime = 0.5f;

    public float ChangeDay = 0.2f;

    public bool changingDay;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if(sun.intensity > nightTime && sun.intensity >= dayTime)
        {
            day = true;
            changingDay = false;
        }

        if (sun.intensity < nightTime && sun.intensity <= dayTime)
        {
            night = true;
            day = false;
        }
        else if (sun.intensity > nightTime)
        {
            night = false;
        }





        if(sun.intensity < ChangeDay)
        {
            changingDay = true;
        }



        if (changingDay == true)
        {
            sun.intensity += 0.005f * Time.deltaTime;
        }
        else
        {
            sun.intensity -= 0.005f * Time.deltaTime;
        }



    }
}
