
using UnityEngine;
using UnityEngine.Networking;

public class Bullet : NetworkBehaviour {

    public float fireSpeed = 10.0f;
    private float rangeCount = 0;
    public GameObject impactEffect;


    Vector3 prevPos;

    [SerializeField]
    private LayerMask mask;

	// Use this for initialization
	void Start () {                                 

        prevPos = transform.position;

	}
	
	// Update is called once per frame
	void Update () {

        prevPos = transform.position;

        transform.Translate(Vector3.forward * fireSpeed * Time.deltaTime);

        RaycastHit[] hits = Physics.RaycastAll(new Ray(prevPos, (transform.position - prevPos).normalized), (transform.position - prevPos).magnitude , mask);

        for(int i = 0; i < hits.Length; i++)
        {
           // Debug.Log(hits[i].collider.gameObject.name);
            if (hits[i].collider.gameObject.name == "Enemy")
            {
               // Debug.Log(hits[i].collider.gameObject.name);
                //Destroy(hits[i].collider.gameObject);
                Enemy enemy = hits[i].collider.gameObject.transform.GetComponent<Enemy>();
                enemy.TakeDamage(Gun.damage);
            }
            Destroy(gameObject);
            GameObject impactGO = Instantiate(impactEffect, hits[i].point, Quaternion.LookRotation(hits[i].normal));
            Destroy(impactGO, 2.0f);


        }

       // Debug.DrawLine(transform.position, prevPos);

       // Debug.Log(rangeCount);
        if (rangeCount >= Gun.range)
        {
            rangeCount = 0;
            Destroy(gameObject);
            
        }

        rangeCount++;

    }   


}
