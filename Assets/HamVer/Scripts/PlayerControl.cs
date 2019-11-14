using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    SteamVR_TrackedObject trackedObj;
    public Animator anim;
    public GameObject bow;
    public GameObject bowString;
    public bool grip = false;
    bool test = false;
   /* void Start ()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }
	
	void Update ()
    {
         var device = SteamVR_Controller.Input((int)trackedObj.index);

        if (device.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            grip = true;
            anim.SetBool("Grip", true);
        }
        else
        {
            grip = false;
            anim.SetBool("Grip", false);
        }
        if (grip)
        {
            if (!test)
            {
                test = true;
                if (bow != null)
                {
                    bow.transform.parent = transform;
                    bow.transform.GetChild(0).GetComponent<Collider>().enabled = false;
                }
                else if (bowString != null)
                {
                    bowString.transform.parent.GetComponent<StringControl>().test = gameObject;
                    bowString.transform.GetComponent<Collider>().enabled = false;
                }
            }
        }
        else
        {
            test = false;
            if (bow != null)
            {
                bow.transform.parent = null;
                bow.transform.GetChild(0).GetComponent<Collider>().enabled = true;
            }
            else if (bowString != null)
            {
                bowString.transform.parent.GetComponent<StringControl>().test = null;
                bowString.transform.GetComponent<Collider>().enabled = true;
            }
        }
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.transform.tag == "BowFrame"&& bowString == null)
        {
            if (bow == null)
            {
                bow = col.transform.parent.gameObject;
            }
        }
        else if (col.transform.tag == "BowString"&& bow==null)
        {
            if (bowString == null)
            {
                bowString = col.transform.gameObject;
            }
        }
    }
    private void OnTriggerExit(Collider col)
    {
        if (col.transform.parent.gameObject == bow)
        {
            if(bow!=null&& !grip)
                bow = null;
        }
        else if (col.transform.gameObject == bowString)
        {
            if (!grip)
            {
                bowString = null;
            }
        }
    }*/
}
