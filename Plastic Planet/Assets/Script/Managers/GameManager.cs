using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static string saveSlotName;
    public static bool newGameSarted;

    public Upgrader upgraderScript;

    public Transform playerPosition;

    public TextMeshProUGUI TrashCountText;
    public TextMeshProUGUI moneyText, moneyText_;

    public bool capacityReached;
    public bool gamePaused;

    public int TrashCount;

    float autoSafeTimer = 5f;
    float autoSafeCurrentTimer;


    public GameObject tutorialMenu;

    [Header("Stats to save")] 
    public float boatSpeed = 1.5f;
    public float Strength = 1.5f;
    public float ropeLength = 2;
    public float trashCapacity = 1;
    public float money;

    [Header("WorldTime")]
    public DayAndNight dayAndNightScript;
    public float time;

    private void Start()
    {
        upgraderScript.GetComponent<Upgrader>();
        gamePaused = true;
        
        if(newGameSarted == false)
        {
            LoadData();
            dayAndNightScript.time = time;
            tutorialMenu.SetActive(false);
            gamePaused = false;
            Time.timeScale = 1;
        }
    }



    private void Update()
    {
        time = dayAndNightScript.time;
        AutoSave();

        upgraderScript.changeVisual();

      
      


        TrashCountText.text = "Capacity: " + TrashCount.ToString() + "/" + trashCapacity.ToString();
        moneyText_.text = "Cash: " + money.ToString("F2") + "€";
        moneyText.text = "Cash: " +  money.ToString("F2") + "€";
    }

    public void quit()
    {
        Application.Quit();
    }
    public void returnToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

   public void SaveData()
    {
        SaveManager.SaveData(this, saveSlotName);
    }
   public void LoadData()
    {
        GameData data = SaveManager.LoadData(saveSlotName);

        // Player Data
        boatSpeed = data.boatSpeed;
        Strength = data.Strength;
        ropeLength = data.ropeLength;
        trashCapacity = data.trashCapacity;
        money = data.money;

        Vector2 position;
        position.x = data.playerPosition[0];
        position.y = data.playerPosition[1];
        playerPosition.position = position;

        // Shop Data
        upgraderScript.speedUpgradePrice = data.speedUpgradePrice;
        upgraderScript.strengthPrice = data.strengthPrice;
        upgraderScript.ropeLengthPrice = data.ropeLengthPrice;
        upgraderScript.capacityPrice = data.capacityPrice;

        upgraderScript.speedAdded = data.speedAdded;
        upgraderScript.strengthAdded = data.strengthAdded;
        upgraderScript.lengthAdded = data.lengthAdded;
        upgraderScript.capacityAdded = data.capacityAdded;

        //Other data 
        time = data.time;
    }

    public void AutoSave()
    {
       autoSafeCurrentTimer -= Time.deltaTime;

        if(autoSafeCurrentTimer <= 0)
        {
            SaveData();
            autoSafeCurrentTimer = autoSafeTimer;
        }
    }

}
