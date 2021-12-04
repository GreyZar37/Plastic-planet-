using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameManager gameManager;

    public MenuItem[] menues;
    public AudioSource audioSource;
    public AudioClip bookClose;
    public AudioClip bookOpen;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        handleMenuChanges();

    }

    public void toogle(GameObject menu)
    {

        bool open = !menu.activeSelf;

        if (open)
        {
            closeMenues();
            Time.timeScale = 0;
            gameManager.gamePaused = true;
            audioSource.PlayOneShot(bookOpen);
        }
        else
        {

            Time.timeScale = 1;
            gameManager.gamePaused = false;
            audioSource.PlayOneShot(bookClose);
        }

        menu.SetActive(open);


    }
    void closeMenues()
    {
        for (int i = 0; i < menues.Length; i++)
        {
            menues[i].menu.SetActive(false);
        }
        audioSource.PlayOneShot(bookClose);
    }

    void handleMenuChanges()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && anyMenuOpen())
        {
            closeMenues();
            Time.timeScale = 1;
            gameManager.gamePaused = false;
            return;
        }


        for (int i = 0; i < menues.Length; i++)
        {
            if (menues[i].requireNearShop && !SellTrash.nearShop)
            {
                continue;
            }

            if (Input.GetKeyDown(menues[i].key))
            {
                toogle(menues[i].menu);
                print(menues[i].key);
            }

        }


    }
    bool anyMenuOpen()
    {
        for (int i = 0; i < menues.Length; i++)
        {
            if (menues[i].menu.activeSelf)
            {
                return true;
            }
        }

        return false;
    }
}
