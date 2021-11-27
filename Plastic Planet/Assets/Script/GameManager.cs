using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI TrashCountText;
    public TextMeshProUGUI moneyText;

    public static int trashCapacity = 2;
    public static bool capacityReached;

    public static int TrashCount;
    public static float money;

    private void Update()
    {
        TrashCountText.text = "Trash: " + TrashCount.ToString() + "/" + trashCapacity.ToString();
        moneyText.text = "Cash: " +  money.ToString() + "€";
    }
}
