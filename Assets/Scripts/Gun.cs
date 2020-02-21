
using UnityEngine;
using UnityEngine.Networking;

public class Gun : NetworkBehaviour {

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

    public Bullet bullet;
    public static float bulletSpeed;
    public static float range;


    private float shotCounter;

    public Transform fireFrom;
    public Transform Right;
    public Transform Left;

    //Gun type bools
    public static bool assault;
    public static bool pistol;
    public static bool shotgun;


    /// //////////////////////
    public static float damage = 10f;
    public float assaultDmg = 15;
    public float pistolDmg = 10;
    public float shotGunDmg = 30;
    public ParticleSystem muzzleFlash;
    public static float fireRate = 15f;
    public float nextTimeToFire = 0f;

    //public PlayerWeapon weapon;
    public Item weapon;

    [SerializeField]
    private LayerMask mask;

    private const string PLAYER_TAG = "Player";
    /// //////////////////////


    // Use this for initialization
    void Start() {
        range = 20;
        bulletSpeed = 100;

        GunSounds = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update() {

        WeponType();

        //Fire();

    }

    void WeponType()
    {
        isFiring = false;
        wideFire = false;
        if (assault == true)
        {
            fireRate = 10f;
            bulletSpeed = 100;
            damage = assaultDmg;
            GunSounds.clip = AssualtSound;
            if (Input.GetMouseButton(0) && Time.time >= nextTimeToFire)
            {
                isFiring = true;
                nextTimeToFire = Time.time + 1f / fireRate;
                Fire();
                //GunSounds.Play();

            }
            else
            {
                isFiring = false;
                Fire();
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
            fireRate = 5f;
            bulletSpeed = 100;
            damage = pistolDmg;
            GunSounds.clip = PistolSound;
            if (Input.GetMouseButtonDown(0) && Time.time >= nextTimeToFire)
            {
                isFiring = true;
                nextTimeToFire = Time.time + 1f / fireRate;
                Fire();
            }
            else
            {
                isFiring = false;
                Fire();
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
            fireRate = 1f;
            GunSounds.clip = ShotGunSound;
            damage = shotGunDmg;
            if (Input.GetMouseButtonDown(0) && Time.time >= nextTimeToFire)
            {
                wideFire = true;
                nextTimeToFire = Time.time + 1f / fireRate;
                Fire();
            }
            else
            {
                wideFire = false;
                Fire();
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
                GunSounds.Play();
                muzzleFlash.Play();
                shotCounter = fireRate;
                Shoot();
                //Bullet newBullet = Instantiate(bullet, fireFrom.position, fireFrom.rotation);
                //Debug.Log("bullet");
                //newBullet.fireSpeed = bulletSpeed;

            }
        }
        else if (wideFire)
        {
            muzzleFlash.Play();
            shotCounter -= Time.deltaTime;
            if (shotCounter <= 0)
            {
                GunSounds.Play();
                shotCounter = fireRate;

                Shoot();
                // Bullet newBullet2 = Instantiate(bullet, fireFrom.position, Right.rotation);
                //Bullet newBullet5 = Instantiate(bullet, fireFrom.position, fireFrom.rotation);
                // Bullet newBullet4 = Instantiate(bullet, fireFrom.position, Left.rotation);

                // newBullet1.fireSpeed = bulletSpeed;
                //newBullet2.fireSpeed = bulletSpeed;
                //newBullet5.fireSpeed = bulletSpeed;
                //newBullet3.fireSpeed = bulletSpeed;
                //newBullet4.fireSpeed = bulletSpeed;
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

    [Client]
    void Shoot()
    {
        RaycastHit _hit;
            if(Physics.Raycast(fireFrom.transform.position,fireFrom.transform.forward, out _hit, weapon.range, mask))
            {
            // Debug.Log("We hit " + _hit.collider.name);
            // if(_hit.collider.tag == PLAYER_TAG)
            // {

            Debug.Log("We hit " + _hit.collider.name);
                CmdPlayerhit("a");
           // }
            }
    }

    //[Command]
    void CmdPlayerhit(string _ID)
    {
        Debug.Log(_ID + " Has been shot");
    }

}
                                                                                                                         