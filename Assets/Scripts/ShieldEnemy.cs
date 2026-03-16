using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script controls the Shield Enemy's behaviour

public class ShieldEnemy : MonoBehaviour, IDamageable
{
    //Reference to the player
    private Transform player;

    //This is to have a delay on the enemy object destroying
    //so that it can wait till the death animation finishes
    public float deathDelay = 0.2f;

    void Start()
    {
        //Find the player in the scene
        player = FindObjectOfType<PlayerController>().transform;
    }

    void Update()
    {
        FacePlayer();
    }

    //Enemy always rotates to face the player
    void FacePlayer()
    {
        if (player == null) return;

        Vector3 direction = player.position - transform.position;
        direction.y = 0f;

        if (direction.magnitude > 0.1f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);

            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                targetRotation,
                5f * Time.deltaTime
            );
        }
    }

    //Called when the enemy is hit by a FireBall
    public void TakeDamage()
    {
        Debug.Log("Enemy Killed!");

        //Trigger the enemy killed event
        GameEvents.OnEnemyDeath?.Invoke();

        //Destroy the enemy object after the delayed time
        Invoke(nameof(DestroyEnemy), deathDelay);
    }

    //Destroys the enemy
    void DestroyEnemy()
    {
        Destroy(gameObject);
    }
}
