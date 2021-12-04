using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Upgrader : MonoBehaviour
{

    public GameManager gameManager;

    public float speedUpgradePrice = 0.2f;
    public float strengthPrice = 0.3f;
    public float ropeLengthPrice = 0.1f;
    public float capacityPrice = 1f;

    public int speedAdded = 0;
    public int lengthAdded = 0;
    public int strengthAdded = 0;
    public int capacityAdded = 0;

    float speedAdd = 0.25f;
    float lengthAdd = 1.5f;
    float strengthAdd = 0.30f;
    float capacityAdd = 1;


    float multipierOne = 2, multipierTwo = 1.5f;
    int highMultiplier = 5;
    int lowMultiplier = 10;

    public TextMeshProUGUI speedUpgradeTxt;
    public TextMeshProUGUI strengthTxt;
    public TextMeshProUGUI ropeLengthTxt;
    public TextMeshProUGUI capacityTxt;

    public TextMeshProUGUI speedUpgradeTxt_;
    public TextMeshProUGUI strengthTxt_;
    public TextMeshProUGUI ropeLengthTxt_;
    public TextMeshProUGUI capacityTxt_;

    public AudioSource audioSource;
    public AudioClip buySound;


    [Header("Upgrade Visuals")]
    public GameObject lvlOneSpeed;
    public GameObject lvlFiveSpeed;
    public GameObject lvlTenSpeed;

    public GameObject lvlOneStandHook;
    public GameObject lvlFiveStandHook;
    public GameObject lvlTenStandHook;

    public GameObject lvlOneHook;
    public GameObject lvlFiveHook;
    public GameObject lvlTenHook;

    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        changeVisual();


        speedUpgradeTxt.text = "Boat Speed +1" + " Upgrade " + "(" + speedUpgradePrice.ToString("F2") + "�" + ")";
        strengthTxt.text = "Strength +1" + " Upgrade " + "(" + strengthPrice.ToString("F2") + "�" + ")";
        ropeLengthTxt.text = "Rope Length +1" + " Upgrade " + "(" + ropeLengthPrice.ToString("F2") + "�" + ")";
        capacityTxt.text = "Capacity +1" + " Upgrade " + "(" + capacityPrice.ToString("F2") + "�" + ")";

        speedUpgradeTxt_.text = "Speed: " + speedAdded.ToString();
        strengthTxt_.text = "Strength: " + strengthAdded.ToString();
        ropeLengthTxt_.text = "Rope length: " + lengthAdded.ToString();
        capacityTxt_.text = "Capacity: " + capacityAdded.ToString();

    }

    public void upgradeSpeed()
    {
        if(gameManager.money >= speedUpgradePrice)
        {

            gameManager.boatSpeed += speedAdd;
            gameManager.money -= speedUpgradePrice;
           
            if (speedAdded <= highMultiplier)
            {
                speedUpgradePrice *= multipierOne;
            }
            else if (speedAdded > highMultiplier)
            {
                speedUpgradePrice *= multipierTwo;
            }

            speedAdded += 1;
            audioSource.PlayOneShot(buySound);
        }
    }
    public void upgradeRopeLength()
    {
        if (gameManager.money >= ropeLengthPrice)
        {
            AimScript.ropeLength = gameManager.ropeLength;
            gameManager.ropeLength += lengthAdd;
            gameManager.money -= ropeLengthPrice;
            
            if(lengthAdded <= highMultiplier)
            {
                ropeLengthPrice *= multipierOne;
            }
            else if (lengthAdded > highMultiplier)
            {
                ropeLengthPrice *= multipierTwo;
            }

            lengthAdded += 1;
            audioSource.PlayOneShot(buySound);
        }
    }
    public void upgradeStrength()
    {
        if (gameManager.money >= strengthPrice)
        {
            strengthAdded += 1;
            gameManager.Strength += strengthAdd;
            gameManager.money -= strengthPrice;

            if (strengthAdded <= highMultiplier)
            {
                strengthPrice *= multipierOne;
            }
            else if (strengthAdded > highMultiplier)
            {
                strengthPrice *= multipierTwo;
            }
            audioSource.PlayOneShot(buySound);

        }
    }
    public void upgradeCapacity()
    {
        if (gameManager.money >= capacityPrice)
        {
            capacityAdded += 1;
            gameManager.trashCapacity += capacityAdd;
            gameManager.money -= capacityPrice;
           
            if (capacityAdded <= highMultiplier)
            {
                capacityPrice *= multipierOne;
            }
            else if (capacityAdded > highMultiplier)
            {
               capacityPrice *= multipierTwo;
            }
            audioSource.PlayOneShot(buySound);

        }
    }
    public void changeVisual()
    {
        switch (speedAdded)
        {
            case 5:
                lvlFiveSpeed.SetActive(true);
              
                break;

            case 10:
                lvlOneSpeed.SetActive(false);
                lvlTenSpeed.SetActive(true);
                break;

            default:
                break;
        }

        switch (strengthAdded)
        {
            case 5:
                lvlFiveStandHook.SetActive(true);
                lvlOneStandHook.SetActive(false);
                break;

            case 10:
                lvlFiveStandHook.SetActive(false);
                lvlTenStandHook.SetActive(true);
                break;

            default:
                break;

              
        }
        switch (lengthAdded)
        {
            case 5:
                lvlFiveHook.SetActive(true);
                lvlOneHook.SetActive(false);
                break;

            case 10:
                lvlFiveHook.SetActive(false);
                lvlTenHook.SetActive(true);
                break;

            default:
                break;
        }
    }
}
