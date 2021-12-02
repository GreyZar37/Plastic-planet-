using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject[] item;
    public GameObject plasticSoup;
    float xRandomNumber;
    float yRandomNumber;

    public float yMin, yMax;
    public float xMin, xMax;

    int randomItemNumber;

    float randomRotation;


    public float timer = 3f;
    float currentTimer;

    Vector3 position;


    // Start is called before the first frame update
    void Start()
    {

        currentTimer = timer;
    }

    // Update is called once per frame
    void Update()
    {
        currentTimer -= Time.deltaTime;
        if (currentTimer <= 0)
        {
            spawner();
            currentTimer = timer;
            randomItemNumber = Random.Range(0, item.Length);
        }


    }

    void spawner()
    {
        xRandomNumber = Random.Range(xMin, xMax);
        yRandomNumber = Random.Range(yMin, yMax);
        randomRotation = Random.Range(0, 360);

        position = new Vector2(xRandomNumber, yRandomNumber);

        if(item[0].tag == "Fish")
        {
            Instantiate(item[randomItemNumber], position, Quaternion.identity, plasticSoup.transform);
        }
        if (item[0].tag == "Plastic")
        {
            Instantiate(item[randomItemNumber], position, Quaternion.Euler(0, 0, randomRotation), plasticSoup.transform);

        }
    }
}
