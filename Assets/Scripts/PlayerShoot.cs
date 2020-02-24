
using UnityEngine;
using UnityEngine.Networking;

public class PlayerShoot : NetworkBehaviour {

    //public PlayerWeapon weapon;
    public static Item weapon;

    public Transform fireFrom;

    [SerializeField]
    private LayerMask mask;

    private const string PLAYER_TAG = "Player";
    private const string TARGET_TAG = "Target";

    public bool isFiring;
    public bool wideFire;

    //public AudioClip AssualtSound;
    //public AudioClip ShotGunSound;
    //public AudioClip PistolSound;
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



    Enemy Enemy;

    //private void Start()
    //{
    //    Enemy = Enemy.EnemyInstance;
    //}

    void Update()
    {
        if (weapon != null)
        {
            if (Input.GetMouseButton(0))
            {
                if (Time.time >= nextTimeToFire)
                {
                    Debug.Log("weapon firing");
                    nextTimeToFire = Time.time + 1f / weapon.fireRate;
                    Fire();
                }
            }
            else if(Input.GetMouseButtonUp(0))
            {
                Debug.Log("weapon stopped");
                shotCounter = 0;
            }
    
            if (Input.GetMouseButtonDown(1))
            {
                scope();
            }

        }



    }

    [Client]
    public void Shoot()
    {

    RaycastHit _hit;
        Debug.DrawRay(fireFrom.transform.position, fireFrom.transform.forward * 10, Color.green);
        if (Physics.Raycast(fireFrom.transform.position, fireFrom.transform.forward, out _hit, weapon.range, mask))
        {
            if (_hit.collider.tag == PLAYER_TAG)
            {
                //Debug.Log("We hit " + _hit.collider.name);
                CmdPlayerhit(_hit.collider.name, weapon.damage);
            }
            else if (_hit.collider.tag == TARGET_TAG)
            {
                // Enemy.EnemyY = _hit.collider.gameObject;
                //Enemy.EnemyInstance = EnemyX;

                GameObject X = _hit.collider.gameObject;
                Enemy = (Enemy)X.GetComponent(typeof(Enemy));

                EnemyHit(Enemy, weapon.damage);
            }
        }
    }

    [Command]
    void CmdPlayerhit(string _playerID, int _damage)
    {
        Debug.Log(_playerID + " Has been shot");

        Player _player = GameManage.GetPlayer(_playerID);
        _player.RpcTakeDamage(_damage);
    }

    void EnemyHit(Enemy _EnemyID, int _damage)
    {
        //GameObject _Enemy = GameObject.Find("Target");
        //Enemy enemy = Enemy.instance;
        //enemy.TakeDamage(_damage);
        Enemy.TakeDamage(_damage);
    }









    void Fire()
    {
           // shotCounter -= Time.time;
        Debug.Log(shotCounter.ToString());
            //if (shotCounter <= 0)
           // {
                Debug.Log("Firing");
                GunSounds.clip = weapon.audioClip;
                GunSounds.Play();
                muzzleFlash.Play();
               // shotCounter = weapon.fireRate;
                Shoot();
            //}
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

    public void scope()
    {

    }

}
