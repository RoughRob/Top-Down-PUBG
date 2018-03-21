using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    void onCollisionEnter()
    {
        Destroy(gameObject);
    }

    // the git push worked!
}
