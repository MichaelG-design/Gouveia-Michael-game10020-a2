using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script listens for the item pick up event
//to then trigger two seperate listeners:
//A grab animation and icon UI pop up

public class PlayerItemPickup : MonoBehaviour
{
    private Animator animator;

    public GameObject itemIcon;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void OnEnable()
    {
        GameEvents.OnItemPickedUp += PlayItemPickUp;
    }

    void OnDisable()
    {
        GameEvents.OnItemPickedUp -= PlayItemPickUp;
    }

    void PlayItemPickUp()
    {
        //Play pick up animation
        if (animator != null)
        {
            animator.SetTrigger("Grab");
        }

        //Show icon
        if (itemIcon != null)
        {
            itemIcon.SetActive(true);
        }
    }
}