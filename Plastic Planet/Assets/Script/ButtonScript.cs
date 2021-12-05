using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class ButtonScript : MonoBehaviour
{

    
    EventTrigger trigger;
    Button thisButton;

    private void Start()
    {
        thisButton = gameObject.GetComponent<Button>();
        trigger = gameObject.GetComponent<EventTrigger>();
    }

    private void Update()
    {
        if(thisButton.interactable == false)
        {
            trigger.enabled = false;
        }
        else
        {
            trigger.enabled = true;

        }
    }

}
