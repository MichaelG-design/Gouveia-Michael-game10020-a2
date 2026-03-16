using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//This script is what holds my 3 events

public static class GameEvents
{
    //Event is triggered when an enemy is killed
    public static System.Action OnEnemyDeath;

    //Event happens when the player escapes
    public static System.Action OnPlayerEscaped;

    //This event happens when an item is picked up
    public static System.Action OnItemPickedUp;
}
