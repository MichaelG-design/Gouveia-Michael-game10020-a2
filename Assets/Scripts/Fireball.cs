using UnityEngine;

//This script handles the FireBall object including its movement
//and interaction with an enemy

public class Fireball : MonoBehaviour
{
    //How fast the fireball moves and its direction
    public float speed = 10f;
    private Vector3 direction;

    //Called when the fireball spawns
    public void SetDirection(Vector3 dir)
    {
        direction = dir.normalized;
    }

    void Update()
    {
        //Move the fireball forward
        transform.position += direction * speed * Time.deltaTime;
    }

    void OnTriggerEnter(Collider other)
    {
        //Anything that can be damaged will be affected by the FireBall
        IDamageable damageable = other.GetComponent<IDamageable>();

        if (damageable != null)
        {
            damageable.TakeDamage();
        }

        //Destroy the fireball object after hitting something
        Destroy(gameObject);
    }
}
