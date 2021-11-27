using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{

    Rigidbody2D rb;

    float horizontal;

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        if(AimScript.thrown == true)
        {
            speed = 0;
        }
        else
        {
            speed = 2;
        }
            rb.velocity = new Vector2(horizontal * speed, rb.position.y);
        
        
    }
}
