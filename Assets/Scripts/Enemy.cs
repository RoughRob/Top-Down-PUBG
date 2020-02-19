using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float health = 100f;


    void onCollisionEnter()
    {
        Destroy(gameObject);
    }


    public void TakeDamage (float amount)
    {
        health -= amount;
        if(health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
    // the git push worked!
}
