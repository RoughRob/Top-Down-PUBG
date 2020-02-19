
using UnityEngine;
using UnityEngine.Networking;

public class PlayerShoot : NetworkBehaviour {

    public PlayerWeapon weapon;

    public Transform fireFrom;

    [SerializeField]
    private LayerMask mask;

    private const string PLAYER_TAG = "Player";



    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    [Client]
    void Shoot()
    {
    RaycastHit _hit;
        if (Physics.Raycast(fireFrom.transform.position, fireFrom.transform.forward, out _hit, weapon.range, mask))
        {
            if (_hit.collider.tag == PLAYER_TAG)
            {
                //Debug.Log("We hit " + _hit.collider.name);
                CmdPlayerhit(_hit.collider.name, weapon.damage);
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
}
