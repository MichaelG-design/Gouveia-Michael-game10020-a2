using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script listens for the enemy killed event and plays a dying animation

public class EnemyDeath : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void OnEnable()
    {
        GameEvents.OnEnemyDeath += PlayDeathAnimation;
    }

    void OnDisable()
    {
        GameEvents.OnEnemyDeath -= PlayDeathAnimation;
    }

    void PlayDeathAnimation()
    {
        if (animator != null)
        {
            animator.SetTrigger("Die");
        }
    }
}
