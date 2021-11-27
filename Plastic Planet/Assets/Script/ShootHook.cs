using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class ShootHook : MonoBehaviour
{

    public GameObject itemHoalder;
    string currentItem;


    public List<GameObject> trash = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(AimScript.thrown == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                currentItem = "";
            }
        }
        print(currentItem);

        if (trash.Count == GameManager.trashCapacity)
        {
            GameManager.capacityReached = true;
        }
        else
        {
            GameManager.capacityReached = false;
        }
        GameManager.TrashCount = trash.Count;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
      
        if (collision.tag == "Plastic")
        {
            
            if (GameManager.capacityReached != true)
            {
                currentItem = collision.gameObject.GetComponent<Item>().trashType;
                collision.gameObject.transform.parent = itemHoalder.transform;
                trash.Add(collision.gameObject);
            }
           
        }
        
        switch (currentItem)
        {
            case "Box":

                AimScript.returnSpeed = 0.5f;

                break;

            case "Bottle":

                AimScript.returnSpeed = 2f;

                break;
            case "":

                AimScript.returnSpeed = 2.5f;

                break;
        }
    }
}
