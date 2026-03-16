using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script focus on defining the objects the player can interact with in the game world

public interface IInteractable
{
    //This is called when the player interacts with an object
    void Interact();
}
