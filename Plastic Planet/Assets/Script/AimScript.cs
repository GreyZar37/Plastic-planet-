using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimScript : MonoBehaviour
{

    public float throwSpeed;
    public static float returnSpeed = 2.5f;

    float counterThrow;
    float counterReturn;


    public GameObject toolPrefab;
    public Transform handPosition;

    public static bool thrown;

    Vector2 startPos;
    Vector2 endPos;
   


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rotateHand();
        shoot();


    }

    void rotateHand()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion roatation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, roatation, 2 * Time.deltaTime);
       
    }

    void shoot()
    {

       
        if (Input.GetMouseButtonDown(0) && thrown == false)
        {
            thrown = true;
            endPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            startPos = toolPrefab.transform.position;
        }
        if(thrown == true)
        {

            Vector2 mousePosition = endPos - (Vector2)toolPrefab.transform.position;
            float angle = Mathf.Atan2(mousePosition.y, mousePosition.x) * Mathf.Rad2Deg;
            toolPrefab.transform.rotation = Quaternion.Euler(0, 0, angle + 300);

            if (counterThrow >= 1)
            {
               
                counterReturn += Time.deltaTime * returnSpeed;
                toolPrefab.transform.position = Vector2.Lerp(endPos, startPos, counterReturn);
              
                if(counterReturn >= 1)
                {
                    thrown = false;
                    counterReturn = 0f;
                    counterThrow = 0f;
                }

            }
            else
            {
                counterThrow += Time.deltaTime * throwSpeed;
                toolPrefab.transform.position = Vector2.Lerp(startPos, endPos, counterThrow);

              

            }
           
        }
        else
        {
            toolPrefab.transform.position = handPosition.position;
            toolPrefab.transform.rotation = handPosition.rotation;
        }
      
        
    }

   

}
