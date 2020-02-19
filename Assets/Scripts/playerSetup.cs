
using UnityEngine;
using UnityEngine.Networking;

[RequireComponent(typeof(Player))]

public class playerSetup : NetworkBehaviour {



    [SerializeField]
    Behaviour[] componentsToDisable;

    [SerializeField]
    string remoteLayerName = "RemotePlayer";

    [SerializeField]
    GameObject PlayerUIPrefab;
    public GameObject PlayerUIInstance;

    Camera sceneCamera;

    void Start()
    {
        if(!isLocalPlayer)
        {
            for(int i = 0; i < componentsToDisable.Length; i++)
            {
                componentsToDisable[i].enabled = false;
                
            }
            gameObject.layer = LayerMask.NameToLayer(remoteLayerName);
        }
        else
        {
            sceneCamera = Camera.main;
            if(sceneCamera != null)
            {
                Camera.main.gameObject.SetActive(false);
            }


            PlayerUIInstance = Instantiate(PlayerUIPrefab);
            PlayerUIInstance.name = PlayerUIPrefab.name;


        }

        GetComponent<Player>().Setup();



    }

    public override void OnStartClient()
    {
        base.OnStartClient();

        string _netID = GetComponent<NetworkIdentity>().netId.ToString();
        Player _player = GetComponent<Player>();

        GameManage.RegisterPlayer(_netID, _player);
    }


    void OnDisable()
    {
        Destroy(PlayerUIInstance);

        if(sceneCamera != null)
        {
            sceneCamera.gameObject.SetActive(true);
        }

        GameManage.UnRegisterPlayer(transform.name);

    }



}
