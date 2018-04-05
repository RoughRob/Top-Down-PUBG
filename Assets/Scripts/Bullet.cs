using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float fireSpeed = 10.0f;
    private float rangeCount = 0;
    
    Vector3 prevPos;

	// Use this for initialization
	void Start () {

        prevPos = transform.position;


	}
	
	// Update is called once per frame
	void Update () {

        prevPos = transform.position;

        transform.Translate(Vector3.forward * fireSpeed * Time.deltaTime);

        RaycastHit[] hits = Physics.RaycastAll(new Ray(prevPos, (transform.position - prevPos).normalized), (transform.position - prevPos).magnitude);

        for(int i = 0; i < hits.Length; i++)
        {
            Debug.Log(hits[i].collider.gameObject.name);
            if (hits[i].collider.gameObject.name == "Enemy")
            {
                Destroy(hits[i].collider.gameObject);
            }
            Destroy(gameObject);
            
        }

        Debug.DrawLine(transform.position, prevPos);

        Debug.Log(rangeCount);
        if (rangeCount >= Gun.range)
        {
            rangeCount = 0;
            Destroy(gameObject);
            
        }

        rangeCount++;

    }   


}
