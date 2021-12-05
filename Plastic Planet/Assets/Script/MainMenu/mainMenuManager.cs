using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;


public class mainMenuManager : MonoBehaviour
{
    public GameObject nameUsedText;
    public GameObject notEnoughSlotsTxt;

    public TMP_InputField saveName;

    public static List<string> slots = new List<string>();
    
    public Button[] slotButtons;
    public TextMeshProUGUI[] slotText;

    bool sameNameFound;

    int slotsAmount = 3;





    private void Start()
    {

        changeSlot();

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayerPrefs.DeleteAll();
        }
    }

    public void quitGame()
    {
        Application.Quit();
    }
    public void NewGame()
    {

        for (int i = 0; i < slots.Count; i++)
        {
          if (saveName.text == slots[i])
            {
                sameNameFound = true;
            }

        }

        if(sameNameFound == false)
        {
            if(slots.Count < slotsAmount)
            {
                GameManager.saveSlotName = saveName.text;
                slots.Add(saveName.text);
               
                notEnoughSlotsTxt.SetActive(false);
                nameUsedText.SetActive(false);
                changeSlot();
                GameManager.newGameSarted = true;
                SceneManager.LoadScene("PlayScene");
            }
            else
            {
                notEnoughSlotsTxt.SetActive(true);
                nameUsedText.SetActive(false);
            }
           
        }
        else
        {
            nameUsedText.SetActive(true);
            notEnoughSlotsTxt.SetActive(false);
        }
        sameNameFound = false;
    }

    public void loadGame(int slotNumber)
    {
        GameManager.newGameSarted = false;
        GameManager.saveSlotName = slotText[slotNumber].text;
        SceneManager.LoadScene("PlayScene");
    }

    public void changeSlot()
    {

            for (int i = 0; i < slots.Count; i++)
            {
                if (slotText[i].text == "Slot " + (i + 1))
                {
                    slotText[i].text = slots[i];
                    slotButtons[i].interactable = true;
                }
            }
    }

  


}
