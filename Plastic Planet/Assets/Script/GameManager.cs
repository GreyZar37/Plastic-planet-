using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    public Upgrader upgraderScript;

    public TextMeshProUGUI TrashCountText;
    public TextMeshProUGUI moneyText, moneyText_;

    public static bool capacityReached;
    public static bool gamePaused;

    public static int TrashCount;
    

    public GameObject optionMenu;
    public GameObject tutorialMenu;

    [Header("Stats")] 
    public static float boatSpeed = 1.5f;
    public static float Strength = 1.5f;
    public static float ropeLength = 2;
    public static float trashCapacity = 1;

    public static float money;

    private void Start()
    {
        //loadData();
        upgraderScript.GetComponent<Upgrader>();
        gamePaused = true;
    }



    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.R))
        {
            resetData();
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            GameManager.money += 100;
        }
        //saveData();

        if (Input.GetKeyDown(KeyCode.Escape) && optionMenu.activeInHierarchy == false && tutorialMenu.activeInHierarchy == false && SellTrash.inShop == false)
        {
            optionMenu.SetActive(true);
            Time.timeScale = 0;
            gamePaused = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && optionMenu.activeInHierarchy == true)
        {
            optionMenu.SetActive(false);
            Time.timeScale = 1;
            gamePaused = false;
        }

        if (Input.GetKeyDown(KeyCode.H) && tutorialMenu.activeInHierarchy == false && optionMenu.activeInHierarchy == false && SellTrash.inShop == false)
        {
            tutorialMenu.SetActive(true);
            Time.timeScale = 0;
            gamePaused = true;
        }
        else if (Input.GetKeyDown(KeyCode.H) && tutorialMenu.activeInHierarchy == true)
        {
            tutorialMenu.SetActive(false);
            Time.timeScale = 1;
            gamePaused = false;
        }



        TrashCountText.text = "Capacity: " + TrashCount.ToString() + "/" + trashCapacity.ToString();
        moneyText_.text = "Cash: " + money.ToString("F2") + "€";
        moneyText.text = "Cash: " +  money.ToString("F2") + "€";
    }

    public void quit()
    {
        Application.Quit();
    }

    public void saveData()
    {
        PlayerPrefs.SetFloat("boatSpeed", boatSpeed);
        PlayerPrefs.SetFloat("Strength", Strength);
        PlayerPrefs.SetFloat("ropeLength", ropeLength);
        PlayerPrefs.SetFloat("trashCapacity", trashCapacity);
        PlayerPrefs.SetFloat("money", money);

        PlayerPrefs.SetFloat("speedUpgradePrice", upgraderScript.speedUpgradePrice);
        PlayerPrefs.SetFloat("strengthPrice", upgraderScript.strengthPrice);
        PlayerPrefs.SetFloat("ropeLengthPrice", upgraderScript.ropeLengthPrice);
        PlayerPrefs.SetFloat("capacityPrice", upgraderScript.capacityPrice);

        PlayerPrefs.SetInt("speedAdded", upgraderScript.speedAdded);
        PlayerPrefs.SetInt("lengthAdded", upgraderScript.lengthAdded);
        PlayerPrefs.SetInt("strengthAdded", upgraderScript.strengthAdded);
        PlayerPrefs.SetInt("capacityAdded", upgraderScript.capacityAdded);


}
    public void loadData()
    {
        boatSpeed = PlayerPrefs.GetFloat("boatSpeed", boatSpeed);
        Strength = PlayerPrefs.GetFloat("Strength", Strength);
        ropeLength = PlayerPrefs.GetFloat("ropeLength", ropeLength);
        trashCapacity = PlayerPrefs.GetFloat("trashCapacity", trashCapacity);
        money = PlayerPrefs.GetFloat("money", money);

        upgraderScript.speedUpgradePrice = PlayerPrefs.GetFloat("speedUpgradePrice", upgraderScript.speedUpgradePrice);
        upgraderScript.strengthPrice = PlayerPrefs.GetFloat("strengthPrice", upgraderScript.strengthPrice);
        upgraderScript.ropeLengthPrice = PlayerPrefs.GetFloat("ropeLengthPrice", upgraderScript.ropeLengthPrice);
        upgraderScript.capacityPrice = PlayerPrefs.GetFloat("capacityPrice", upgraderScript.capacityPrice);

        upgraderScript.speedAdded = PlayerPrefs.GetInt("speedAdded", upgraderScript.speedAdded);
        upgraderScript.lengthAdded = PlayerPrefs.GetInt("lengthAdded", upgraderScript.lengthAdded);
        upgraderScript.strengthAdded = PlayerPrefs.GetInt("strengthAdded", upgraderScript.strengthAdded);
        upgraderScript.capacityAdded = PlayerPrefs.GetInt("capacityAdded", upgraderScript.capacityAdded);
    }
    public void resetData()
    {
        PlayerPrefs.DeleteAll();
    }
}
