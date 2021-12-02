using System.Collections.Generic;
using UnityEngine;
public class ShootHook : MonoBehaviour
{
    public GameObject plasticSoup;
    public GameObject itemHolder;
    public GameObject item;

    public static string currentItem;
    public static float trashWeight;

    public Item itemScript;
    
    public AudioSource audioSource;
    public AudioClip hit;
    public AudioClip brokeHook;

    bool brokenHook;
    bool playeBrokenSound;

    public List<GameObject> trash = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        audioSource.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
       
        if (AimScript.tooHeavy == true)
        {
            if(playeBrokenSound == false)
            {
                audioSource.PlayOneShot(brokeHook);
                playeBrokenSound = true;
            }
            

            trash.Remove(item);
            item.transform.parent = plasticSoup.transform;
            item.GetComponent<Collider2D>().enabled = true;
            brokenHook = true;

        }
        else
        {
            brokenHook = false;
            playeBrokenSound = false;
        }





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
        
      
        if (collision.tag == "Plastic" || collision.tag == "Fish")
        {
           
            if (GameManager.capacityReached != true && brokenHook == false)
            {
                
                item = collision.gameObject;
                currentItem = item.gameObject.GetComponent<Item>().trashType;
                itemScript = item.gameObject.GetComponent<Item>();
                item.gameObject.GetComponent<Collider2D>().enabled = false;
                item.gameObject.GetComponent<Item>().catched = true;
                item.gameObject.transform.parent = itemHolder.transform;
                trash.Add(item.gameObject);
                audioSource.PlayOneShot(hit);
                if (itemScript.weight >= trashWeight || trashWeight == 0)
                {
                    trashWeight = itemScript.weight;
                }
               
            }
           

        }
        
        
    }
}
