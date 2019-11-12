using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandControl : MonoBehaviour
{
    SteamVR_TrackedObject trackedObj;
    public Animator anim;
    public bool grip = false;
    void Start()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }
    void Update()
    {
        var device = SteamVR_Controller.Input((int)trackedObj.index);
        if (device.GetTouch(SteamVR_Controller.ButtonMask.Trigger))
        {
            grip = true;

            Debug.Log("그립");
            anim.SetBool("Grip", true);
        }
        else
        {
            Debug.Log("그립2");
            grip = false;
            anim.SetBool("Grip", false);
        }

        if (device.GetTouch(SteamVR_Controller.ButtonMask.Touchpad))
        {
            Debug.Log("패드");
        }
        else
        {
            Debug.Log("2222");
        }
    }
}