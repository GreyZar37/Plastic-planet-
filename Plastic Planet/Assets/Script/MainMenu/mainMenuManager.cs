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

    public List<string> slots = new List<string>();
    


    public Button[] slotButtons;
    public TextMeshProUGUI[] slotText;

    bool sameNameFound;

    int slotsAmount = 3;
    int slotsSaved;

    private void Start()
    {
        changeSlot();
        loadSlots();
    }
    private void Update()
    {
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
                saveSlots();
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

    public void saveSlots()
    {
        for (int i = 0; i < slots.Count; i++)
        {
            PlayerPrefs.SetString("Slot " + i, slots[i]);
            slotsSaved++;
            PlayerPrefs.SetInt("SlotsSaved ", slotsSaved);
        }
    }
    public void loadSlots()
    {
        slotsSaved = PlayerPrefs.GetInt("SlotsSaved ", slotsSaved);

        for (int i = 0; i < slotsSaved; i++)
        {
          

            string slotName = PlayerPrefs.GetString("Slot " + i, slots[i]);
            slots.Add(slotName);

        }

    }


}
