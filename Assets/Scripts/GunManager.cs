using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunManager : MonoBehaviour {


    public bool isFiring;
    public bool wideFire;

    public AudioClip AssualtSound;
    public AudioClip ShotGunSound;
    public AudioClip PistolSound;
    public AudioSource GunSounds;

    public bool scoped;
    public GameObject NormalView;
    public GameObject view;
    public GameObject viewX2;
    public GameObject viewX4;

    public float x2 = 30;
    public float x4 = 10;
    public float normal = 90;

    public static float damage;


    private float shotCounter;


    public ParticleSystem muzzleFlash;
    //public static float fireRate = 15f;
    public float nextTimeToFire = 0f;

    //public PlayerWeapon weapon;
    //public Item weapon;
    PlayerShoot playerShoot;

    [SerializeField]
    private LayerMask mask;

    private const string PLAYER_TAG = "Player";
    /// //////////////////////


    // Use this for initialization
    void Start()
    {
       // range = 20;
       // bulletSpeed = 100;

       // GunSounds = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {

       // WeponType();

        //Fire();

    }

    public void WeaponType(Item weapon)
    {
        isFiring = false;
        //wideFire = false;
        if (weapon != null)
        {
            Debug.Log("weapon not null");
            if (weapon.name == "Assault_Rifle")
            {
                Debug.Log("weapon assault");
                //fireRate = 10f;
                //bulletSpeed = 100;
                damage = weapon.damage;
                GunSounds.clip = AssualtSound;
                if (Input.GetMouseButtonDown(0) && Time.time >= nextTimeToFire)
                {
                    Debug.Log("weapon fired");
                    isFiring = true;
                    nextTimeToFire = Time.time + 1f / weapon.fireRate;
                    Fire(weapon);
                    GunSounds.Play();

                }
                else
                {
                    Debug.Log("weapon fired2");
                    isFiring = false;
                    Fire(weapon);
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
            else if (weapon.name == "Pistol")
            {
                //fireRate = 5f;
                //bulletSpeed = 100;
                damage = weapon.damage;
                GunSounds.clip = PistolSound;
                if (Input.GetMouseButtonDown(0) && Time.time >= nextTimeToFire)
                {
                    isFiring = true;
                    nextTimeToFire = Time.time + 1f / weapon.fireRate;
                    Fire(weapon);
                }
                else
                {
                    isFiring = false;
                    Fire(weapon);
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
            else if (weapon.name == "Assault_Rifle2")
            {
                // bulletSpeed = 50;
                // fireRate = 1f;
                GunSounds.clip = ShotGunSound;
                damage = weapon.damage;
                if (Input.GetMouseButtonDown(0) && Time.time >= nextTimeToFire)
                {
                    //wideFire = true;
                    nextTimeToFire = Time.time + 1f / weapon.fireRate;
                    Fire(weapon);
                }
                else
                {
                    wideFire = false;
                    Fire(weapon);
                }
            }
            else
            {

            }
        }
    }

    void Fire(Item weapon)
    {


        if (isFiring)
        {

            shotCounter -= Time.deltaTime;
            if (shotCounter <= 0)
            {
                GunSounds.Play();
                muzzleFlash.Play();
                shotCounter = weapon.fireRate;
                playerShoot.Shoot();
                //Bullet newBullet = Instantiate(bullet, fireFrom.position, fireFrom.rotation);
                //Debug.Log("bullet");
                //newBullet.fireSpeed = bulletSpeed;

            }
        }
        //else if (wideFire)
        //{
        //    muzzleFlash.Play();
        //    shotCounter -= Time.deltaTime;
        //    if (shotCounter <= 0)
        //    {
        //        GunSounds.Play();
        //        shotCounter = fireRate;

        //        Shoot();
        //        // Bullet newBullet2 = Instantiate(bullet, fireFrom.position, Right.rotation);
        //        //Bullet newBullet5 = Instantiate(bullet, fireFrom.position, fireFrom.rotation);
        //        // Bullet newBullet4 = Instantiate(bullet, fireFrom.position, Left.rotation);

        //        // newBullet1.fireSpeed = bulletSpeed;
        //        //newBullet2.fireSpeed = bulletSpeed;
        //        //newBullet5.fireSpeed = bulletSpeed;
        //        //newBullet3.fireSpeed = bulletSpeed;
        //        //newBullet4.fireSpeed = bulletSpeed;
        //    }
        //}
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

    //[Client]
    //void Shoot()
    //{
    //    RaycastHit _hit;
    //    if (Physics.Raycast(fireFrom.transform.position, fireFrom.transform.forward, out _hit, weapon.range, mask))
    //    {
    //        // Debug.Log("We hit " + _hit.collider.name);
    //        // if(_hit.collider.tag == PLAYER_TAG)
    //        // {

    //        Debug.Log("We hit " + _hit.collider.name);
    //        CmdPlayerhit("a");
    //        // }
    //    }
    //}

    //[Command]
    //void CmdPlayerhit(string _ID)
    //{
    //    Debug.Log(_ID + " Has been shot");
    //}


}
