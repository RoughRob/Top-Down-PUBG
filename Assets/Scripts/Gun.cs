using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

    public bool isFiring;
    public bool wideFire;

    public bool scoped;
    public GameObject NormalView;
    public GameObject view;
    public GameObject viewX2;
    public GameObject viewX4;

    public float x2 = 30;
    public float x4 = 10;
    public float normal = 90;

    public Bullet bullet;
    public static float bulletSpeed;
    public static float range;

    public static float timeBetweenShots;
    private float shotCounter;

    public Transform fireFrom;
    public Transform Right;
    public Transform Left;

    //Gun type bools
    public static bool assault;
    public static bool pistol;
    public static bool shotgun;


    // Use this for initialization
    void Start () {
        range = 20;
        timeBetweenShots = 10;
        bulletSpeed = 100;


    }
	
	// Update is called once per frame
	void Update () {

        WeponType();

        Fire();

	}

    void WeponType()
    {
        isFiring = false;
        wideFire = false;
        if (assault == true)
        {
            timeBetweenShots = .1f;
            bulletSpeed = 100;
            if (Input.GetMouseButton(0))
            {
                isFiring = true;
            }
            else
            {
                isFiring = false;
            }
              ///Scope
            if (Input.GetMouseButton(1))
            {
                ScopeX2();
            }
            else
            {
                Unscope();
            }

        }
        else if (pistol == true)
        {
            bulletSpeed = 100;
            if (Input.GetMouseButtonDown(0))
            {
                isFiring = true;
            }
            else
            {
                isFiring = false;
            }
            if (Input.GetMouseButton(1))
            {
                ScopeX4();
            }
            else
            {
                Unscope();
            }
        }
        else if (shotgun == true)
        {
            bulletSpeed = 50;

            if (Input.GetMouseButtonDown(0))
            {
                wideFire = true;
            }
            else
            {
                wideFire = false;
            }
        }
        else
        {

        }
    }

    void Fire()
    {
        if (isFiring)
        {
            shotCounter -= Time.deltaTime;
            if (shotCounter <= 0)
            {
                shotCounter = timeBetweenShots;
                Bullet newBullet = Instantiate(bullet, fireFrom.position, fireFrom.rotation);
                newBullet.fireSpeed = bulletSpeed;
            }
        }
        else if (wideFire)
        {
            shotCounter -= Time.deltaTime;
            if (shotCounter <= 0)
            {
                shotCounter = timeBetweenShots;
                
                Bullet newBullet2 = Instantiate(bullet, fireFrom.position, Right.rotation);
                Bullet newBullet5 = Instantiate(bullet, fireFrom.position, fireFrom.rotation);
                Bullet newBullet4 = Instantiate(bullet, fireFrom.position, Left.rotation);
                
               // newBullet1.fireSpeed = bulletSpeed;
                newBullet2.fireSpeed = bulletSpeed;
                newBullet5.fireSpeed = bulletSpeed;
                //newBullet3.fireSpeed = bulletSpeed;
                newBullet4.fireSpeed = bulletSpeed;
            }
        }
        else
        {
            shotCounter = 0;
        }



    }

    void ScopeX2()
    {
        view.transform.position = viewX2.transform.position;
        FieldOfView.viewAngle = x2;
    }

    void ScopeX4()
    {
        view.transform.position = viewX4.transform.position;
        FieldOfView.viewAngle = x4;
    }

    void Unscope()
    {
        view.transform.position = NormalView.transform.position;
        FieldOfView.viewAngle = normal;
    }

}
                                                                                                                         