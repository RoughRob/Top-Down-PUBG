﻿
using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class Player : NetworkBehaviour {

    [SyncVar]
    private bool _isDead = false;
    public bool isDead
    {
        get { return _isDead; }
        protected set { _isDead = value; }
    }

    [SerializeField]
    private int maxHealth = 100;

    [SyncVar]
    private int currentHealth;

    [SerializeField]
    private Behaviour[] disableOnDeath;
    private bool[] wasEnabled;

    public Interactable focus;
    public Transform playerTransform;

    public void Setup()
    {
        wasEnabled = new bool[disableOnDeath.Length];
        for (int i = 0; i < wasEnabled.Length; i++)
        {
            wasEnabled[i] = disableOnDeath[i].enabled;
        }

        SetDefaults();
    }

    //void Update()
    //{
    //    if (!isLocalPlayer)
    //        return;

    //    if (Input.GetKeyDown(KeyCode.K))
    //    {
    //        RpcTakeDamage(9999);
    //    }
    //}

    [ClientRpc]
    public void RpcTakeDamage(int _amount)
    {
        if (isDead)
            return;

        currentHealth -= _amount;

        Debug.Log(transform.name + " now has " + currentHealth + "Health.");

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        isDead = true;

        //Diable components
        for (int i = 0; i < disableOnDeath.Length; i++)
        {
            disableOnDeath[i].enabled = false;
        }

        Collider _col = GetComponent<Collider>();
        if (_col != null)
            _col.enabled = false;

        Debug.Log(transform.name + " is DEAD@");

        //call respawn method
        StartCoroutine(Respawn());                

    }

    private IEnumerator Respawn()
    {
        yield return new WaitForSeconds(GameManage.instance.matchSettings.respawnTime);

        SetDefaults();
        Transform _spawnPoint = NetworkManager.singleton.GetStartPosition();

        transform.position = _spawnPoint.position;
        transform.rotation = _spawnPoint.rotation;

        Debug.Log(transform.name + " Respawned");
    }

    public void SetDefaults()
    {
        isDead = false;
       
       currentHealth  = maxHealth;

        for (int i = 0; i < disableOnDeath.Length; i++)
        {
            disableOnDeath[i].enabled = wasEnabled[i];
        }

        Collider _col = GetComponent<Collider>();
        if (_col != null)
            _col.enabled = true;
    }

    private void OnTriggerStay(Collider other)
    {
        // for (int i = 0; i < items.Length; i++)
        //{
        //Debug.Log("collision");

            //Debug.Log("press F to pick up "+ other.gameObject.name);
       // if (Input.GetKeyDown("f"))
       // {
            Interactable interactable = other.GetComponent<Interactable>();
            if(interactable != null)
            {
                if (focus == null)
                {
                    SetFocus(interactable);
                }
            }
       // }

            //Inside = false;

        // }
    }

    private void OnTriggerExit(Collider other)
    {
        RemoveFocus();
    }

    void SetFocus(Interactable newFocus)
    {
        if(newFocus != focus)
        {
            if(focus != null)
            focus.OnDeFocus();

            focus = newFocus;
        }


        newFocus.OnFocused(playerTransform);
    }

    void RemoveFocus()
    {
        if (focus != null)
            focus.OnDeFocus();
        focus = null;
    }

}