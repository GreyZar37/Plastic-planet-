using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public Upgrader upgraderScript;

    public Transform playerPosition;

    public TextMeshProUGUI TrashCountText;
    public TextMeshProUGUI moneyText, moneyText_;

    public bool capacityReached;
    public bool gamePaused;

    public int TrashCount;

    

    [Header("Stats to save")] 
    public float boatSpeed = 1.5f;
    public float Strength = 1.5f;
    public float ropeLength = 2;
    public float trashCapacity = 1;
    public float money;

  

    private void Start()
    {
        upgraderScript.GetComponent<Upgrader>();
        gamePaused = true;
    }



    private void Update()
    {


        if (Input.GetKeyDown(KeyCode.G))
        {
            SaveData();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadData();
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            SaveManager.Deletedata();
        }


        if (Input.GetKeyDown(KeyCode.M))
        {
            money += 100;
        }
      


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
        SaveManager.SaveData(this);
    }
   public void LoadData()
    {
        PlayerData data = SaveManager.LoadData();
        boatSpeed = data.boatSpeed;
        Strength = data.Strength;
        ropeLength = data.ropeLength;
        trashCapacity = data.trashCapacity;
        money = data.money;

        Vector2 position;
        position.x = data.playerPosition[0];
        position.y = data.playerPosition[1];
        playerPosition.position = position;
    }
    

  
}
