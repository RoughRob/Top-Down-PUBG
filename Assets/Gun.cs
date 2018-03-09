using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

    public bool isFiring;

    public Bullet bullet;
    public float bulletSpeed;
    public static float range;

    public float timeBetweenShots;
    private float shotCounter;

    public Transform fireFrom;

	// Use this for initialization
	void Start () {
        range = 20;
	}
	
	// Update is called once per frame
	void Update () {
        if (isFiring)
        {
            shotCounter -=  Time.deltaTime;
            if(shotCounter <= 0)
            {
                shotCounter = timeBetweenShots;
                Bullet newBullet = Instantiate(bullet, fireFrom.position, fireFrom.rotation) as Bullet;
                newBullet.fireSpeed = bulletSpeed;
            }
        }
        else
        {
            shotCounter = 0;
        }


	}
}
