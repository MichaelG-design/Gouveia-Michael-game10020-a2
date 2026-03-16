using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script controls the exit door the player uses to beat the level/scenario

public class ExitDoor : MonoBehaviour, IInteractable
{
    //Different door states/sprites
    public GameObject lockedDoor;
    public GameObject unlockedDoor;

    //Tracks if the door is unlocked
    private bool isUnlocked = false;

    void Start()
    {
        //Start with the locked door activated/visible
        lockedDoor.SetActive(true);
        unlockedDoor.SetActive(false);
    }


    //Called when the player presses the 'E' key near the door
    public void Interact()
    {
        if (!isUnlocked)
        {
            Debug.Log("The door is locked? Duh!");
            return;
        }

        //Trigger the player escape event
        GameEvents.OnPlayerEscaped?.Invoke();
    }

    void OnEnable()
    {
        //Listen for the enemy death event
        GameEvents.OnEnemyDeath += UnlockDoor;
    }

    void OnDisable()
    {
        //Stop listening when disabled
        GameEvents.OnEnemyDeath -= UnlockDoor;
    }


    //Runs when enemy dies
    public void UnlockDoor()
    {
        isUnlocked = true;

        //Switch door sprites
        lockedDoor.SetActive(false);
        unlockedDoor.SetActive(true);

        Debug.Log("Door unlocked?");
    }
}
