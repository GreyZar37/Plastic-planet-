using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookBoarder : MonoBehaviour
{
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Hook")
        {
            AimScript.ropeLength = 0;
        }
    }
}
