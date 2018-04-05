using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeeThrough : MonoBehaviour {

    public bool seeThrough;
    public GameObject roof;
    //public Color roof;

    void Update()
    {
        if (seeThrough)
        {
            //become clear
            roof.SetActive(false);  

        }
        else
        {
            roof.SetActive(true);
        }
    }

    void OnTriggerEnter(Collider Other)
    {
        if (Other.gameObject.name == "Main Camera")
        {
            seeThrough = true;
        }
    }

    void OnTriggerExit(Collider Other)
    {
        if (Other.gameObject.name == "Main Camera")
        {
            seeThrough = false;
        }
    }
}
