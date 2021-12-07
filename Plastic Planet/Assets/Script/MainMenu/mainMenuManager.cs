using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;
using System;
using System.Text;


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





    private void Start()
    {
        
        LoadData();
        changeSlot();

    }
    private void Update()
    {
        for (int i = 0; i < slots.Count; i++)
        {
            print(slots[i]);
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
                SaveData();

                notEnoughSlotsTxt.SetActive(false);
                nameUsedText.SetActive(false);
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


    public void SaveData()
    {
        SaveManager.SaveMainMenuData(this);
    }
    public void LoadData()
    {
        GameData data = SaveManager.LoadMainMenuData();
        slots = data.slots;
       
    }





}
