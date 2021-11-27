using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellTrash : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Raft")
        {
            for (int i = 0; i < FindObjectOfType<ShootHook>().trash.Count; i++)
            {
                GameManager.money += FindObjectOfType<ShootHook>().trash[i].gameObject.GetComponent<Item>().moneyTogive;
                Destroy(FindObjectOfType<ShootHook>().trash[i]);
                
            }
            FindObjectOfType<ShootHook>().trash.Clear();

        }
    }
}
