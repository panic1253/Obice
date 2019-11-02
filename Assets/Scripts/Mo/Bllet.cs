using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bllet : MonoBehaviour {

    public float damage = 10.0f;
    public float speed = 1000.0f;

	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * speed);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter(Collider col)
    {
        if(col.transform.tag == "Bullet")
        {
            Destroy(col.gameObject);
        }
    }
}
