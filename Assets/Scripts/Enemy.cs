using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float health = 100f;
   // public static Enemy EnemyInstance;

    //#region Singleton
    //public void Awake()
    //{
    //    if (EnemyInstance != null)
    //    {
    //        Debug.Log("more that one inventory instance");
    //        return;
    //    }

    //    EnemyInstance = this;

    //}
    //#endregion


    //void onCollisionEnter()
    //{
    //    Destroy(gameObject);
    //}

    public void TakeDamage (float amount)
    {
        Debug.Log("took damage " + this.name);
        health -= amount;
        if(health <= 0f)
        {
            Die();
        }
    }

    public void  Die()
    {
        Destroy(this.gameObject);
    }
    // the git push worked!
}
