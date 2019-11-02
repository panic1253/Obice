using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Lazerof : MonoBehaviour {
   SteamVR_TrackedObject trackedObject;
    public GameObject[] Lazer=new GameObject[2];
    public bool test;
    public Collider coll;
    float MaxDistance = 200f;
    [SerializeField]
    private Image cursor;
    [SerializeField]
    private LayerMask uI;

    private void Awake()
    {
        trackedObject = GetComponent<SteamVR_TrackedObject>();
    }

    // Use this for initialization
    void Start () {
        coll = GetComponent<BoxCollider>();
	}
	
	// Update is called once per frame
	void Update () {
        var device = SteamVR_Controller.Input((int)trackedObject.index);
        //Debug.Log(SteamVR_Controller.Input((int)trackedObject.index));
        if ( device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            //test = true;
            Debug.Log("sssds");
            Lazer[0].SetActive(true); 
            Lazer[1].SetActive(false);
            Ray ray = Camera.main.ScreenPointToRay(new Vector3(200,200,0));
            RaycastHit Hit;
            Debug.DrawRay(transform.position, transform.forward * MaxDistance, Color.red, 0.3f);
            if(Physics.Raycast(ray,out Hit, 100, uI))
            {
                Debug.Log(Hit.collider);
            }
            
            //if (Physics.Raycast(transform.position, transform.forward, out Hit, MaxDistance)) { 
              //   UnityEngine.SceneManagement.SceneManager.LoadScene("InGame");

                
          //}
                //if (coll.Raycast(ray, out Hit, 100.0F))
                
            Debug.Log("hufghf");


        }
        /*else if (device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            Lazer = false;

    
        }*/

    }
}
