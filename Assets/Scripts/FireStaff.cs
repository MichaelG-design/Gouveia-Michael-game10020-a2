using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script controls the fire staff weapon, adding the IInteractble system
//so that the player can use this item

public class FireStaff : MonoBehaviour, IInteractable
{
    //Reference to the player
    private PlayerController player;

    void Start()
    {
        //Find the player in the scene
        player = FindObjectOfType<PlayerController>();
    }

    public void Interact()
    {
        Debug.Log("Player picked up the Fire Staff");

        //Trigger the staff pickup event
        GameEvents.OnItemPickedUp?.Invoke();

        player.EquipFireStaff(gameObject);
    }
}
