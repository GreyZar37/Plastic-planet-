using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public string trashType;
    public float moneyTogive;
    public float weight;

    public bool catched;

    float speed;

    public float maxSpeed;
    public float minSpeed;

    Rigidbody2D rb;
    private void Awake()
    {
        speed = Random.Range(minSpeed, maxSpeed);
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(catched == false)
        {
           rb.velocity = new Vector2(1 * speed, 0);
        }

    }
}
