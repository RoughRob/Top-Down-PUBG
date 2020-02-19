
using UnityEngine;
using UnityEngine.Networking;

public class SecondSetup : NetworkBehaviour {

    [SerializeField]
    Behaviour[] componentsToDisable;

   // Camera sceneCamera;

    void Start()
    {
        if (!isLocalPlayer)
        {
            for (int i = 0; i < componentsToDisable.Length; i++)
            {
                componentsToDisable[i].enabled = false;
            }
        }
        //else
        //{
        //    sceneCamera = Camera.main;
        //    if (sceneCamera != null)
        //    {
        //        Camera.main.gameObject.SetActive(false);
        //    }

        //}
    }

}
