using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script waits for the player escaped event to be triggered
//then activates the Win Screen

//This script also locks the player movment after the escaped event is triggered

public class WinScreen : MonoBehaviour
{
    public GameObject winText;
    public GameObject winPanel;

    private PlayerController player;

    void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    void OnEnable()
    {
        GameEvents.OnPlayerEscaped += ShowWinScreen;
    }

    void OnDisable()
    {
        GameEvents.OnPlayerEscaped -= ShowWinScreen;
    }

    void ShowWinScreen()
    {
        //Activate the objects for the win screen
        if (winText != null)
        {
            winText.SetActive(true);
        }
        if (winPanel != null)
        {
            winPanel.SetActive(true);
        }

        //Disables player movement
        if (player != null)
        {
            player.enabled = false;
        }
    }
}
