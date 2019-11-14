using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandControl : MonoBehaviour
{
    SteamVR_TrackedObject trackedObj;
    public PredictPath script_PredictPath;
    public Animator anim;
    public bool grip = false;
    public GameObject bowPoint;
    public GameObject item;
    public PlayerHandControl hand;
    bool getItem = false;
    public bool getItemCheck = false;
    public bool getString = false;

    public bool bTouchpad = false;

    public bool bTouchpadCheck = false;
    void Start()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }
    void Update()
    {
        /* var device = SteamVR_Controller.Input((int)trackedObj.index);
         if (device.GetTouch(SteamVR_Controller.ButtonMask.Trigger))
         {
             grip = true;

             Debug.Log("그립");
         }
         else
         {
             Debug.Log("그립2");
             grip = false;
         }*/
        if (grip)
        {
            if (getItem && !getItemCheck && !hand.getItemCheck)
            {
                getItemCheck = true;
                item.transform.parent = bowPoint.transform;
                item.transform.localPosition = Vector3.zero;
                item.transform.localRotation = Quaternion.Euler(0, 0, 0);
                item.transform.GetComponent<Rigidbody>().isKinematic = true;
                item.transform.GetChild(0).transform.GetComponent<Collider>().enabled = false;
                anim.gameObject.SetActive(false);
            }
            else if (hand.getItemCheck && getString)
            {
                Debug.Log("asdqqqqqf");
                item.GetComponent<StringControl>().bowStringCenterRig.enabled = false;
                item.GetComponent<StringControl>().bowStringPos = transform.position;
                anim.gameObject.SetActive(false);
            }
        }
        else
        {
            if (getItemCheck)
            {
                getItemCheck = false;
                item.transform.GetComponent<Rigidbody>().isKinematic = false;
                item.transform.GetChild(0).transform.GetComponent<Collider>().enabled = true;
                item.transform.parent = null;
                anim.gameObject.SetActive(true);
            }
            else if (getString)
            {
                getString = false;
                item.GetComponent<StringControl>().bowStringCenterRig.enabled = true;
                anim.gameObject.SetActive(true);
            }
        }
        if (bTouchpadCheck)
        {
            hand.bTouchpad = false;
        }
        if (bTouchpad && !hand.bTouchpad)
        {
            bTouchpadCheck = true;
            script_PredictPath.mIsActive = true;
        }
        else
        {
            bTouchpadCheck = false;
            script_PredictPath.mIsActive = false;
        }
        anim.SetBool("Grip", grip);
        /* if (device.GetTouch(SteamVR_Controller.ButtonMask.Touchpad))
         {
             Debug.Log("패드");
         }
         else
         {
             Debug.Log("2222");
         }*/
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.transform.tag == "BowFrame" && !grip)
        {
            getItem = true;

            Debug.Log("asdf");
        }
        else if (col.transform.tag == "BowString")
        {
            Debug.Log("asdf222");
            getString = true;
        }
    }
    void OnTriggerExit(Collider col)
    {
        if (col.transform.tag == "BowFrame"&& grip)
        {
            getItem = false;
        }
        else if (col.transform.tag == "BowString")
        {
            getString = false;
        }
    }
}