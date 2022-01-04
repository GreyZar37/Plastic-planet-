using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    // Shop Data
    public float speedUpgradePrice;
    public float strengthPrice;
    public float ropeLengthPrice;
    public float capacityPrice;

    public int speedAdded;
    public int lengthAdded;
    public int strengthAdded;
    public int capacityAdded;



    //Player Data
    public float boatSpeed;
    public float Strength;
    public float ropeLength;
    public float trashCapacity;
    public float money;

    public float[] playerPosition;

    public List<string> slots = new List<string>();

    //Other Data
    public float time;

    public GameData(GameManager gameData)
    {
        //Plater Data
        boatSpeed = gameData.boatSpeed;
        Strength = gameData.Strength;
        ropeLength = gameData.ropeLength;
        trashCapacity = gameData.trashCapacity;
        money = gameData.money;
        playerPosition = new float[2];
        playerPosition[0] = gameData.playerPosition.transform.position.x;
        playerPosition[1] = gameData.playerPosition.transform.position.y;


        // Shop Data
        speedUpgradePrice = gameData.upgraderScript.speedUpgradePrice;
        strengthPrice = gameData.upgraderScript.strengthPrice;
        ropeLengthPrice = gameData.upgraderScript.ropeLengthPrice;
        capacityPrice = gameData.upgraderScript.capacityPrice;


        speedAdded = gameData.upgraderScript.speedAdded;
        lengthAdded = gameData.upgraderScript.lengthAdded;
        strengthAdded = gameData.upgraderScript.strengthAdded;
        capacityAdded = gameData.upgraderScript.capacityAdded;

        // Other Data
        time = gameData.time;
    }
    public GameData(mainMenuManager mainMenuData)
    {
        //lot Data
        slots = mainMenuData.slots;
    }

}
