using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firectrl : MonoBehaviour {

    public GameObject bullet;
    public Transform firePos;
    
	// Use this for initialization
	void Start () {
        firePos = GetComponent<Transform>();
		
	}

	
	// Update is called once per frame
	
    public  void  Fire()
    {
        Instantiate(bullet, firePos.position, firePos.rotation);
    }
   
}
