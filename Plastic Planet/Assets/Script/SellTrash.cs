using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SellTrash : MonoBehaviour
{
  
    
    public static bool inShop;
    public static bool nearShop;

    AudioSource audioSource;

    public GameObject pressEText;

  

    private void Update()
    {

    }
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Raft" && AimScript.thrown == false)
        {
            pressEText.SetActive(true);
            nearShop = true;


            for (int i = 0; i < FindObjectOfType<ShootHook>().trash.Count; i++)
            {
                GameManager.money += FindObjectOfType<ShootHook>().trash[i].gameObject.GetComponent<Item>().moneyTogive;
                Destroy(FindObjectOfType<ShootHook>().trash[i]);

            }
            if (FindObjectOfType<ShootHook>().trash.Count > 0)
            {
                audioSource.Play();
            }

            FindObjectOfType<ShootHook>().trash.Clear();

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Raft")
        {
            pressEText.SetActive(false);
            inShop = false;
            nearShop = false;
        }
    }
}
