using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{

    public float boatSpeed;
    public float Strength;
    public float ropeLength;
    public float trashCapacity;
    public float money;

    public float[] playerPosition;


    public PlayerData(GameManager playerData)
    {
        boatSpeed = playerData.boatSpeed;
        Strength = playerData.Strength;
        ropeLength = playerData.ropeLength;
        trashCapacity = playerData.trashCapacity;
        money = playerData.money;
        playerPosition = new float[2];
        playerPosition[0] = playerData.playerPosition.transform.position.x;
        playerPosition[1] = playerData.playerPosition.transform.position.y;

    }

}
