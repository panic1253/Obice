using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grip : MonoBehaviour
{
	GameObject gr=null;
	SteamVR_TrackedObject trackedObj;
	bool grap = true;//grap 이 true면 


	// Use this for initialization
	void Awake()
	{
		trackedObj = GetComponent<SteamVR_TrackedObject>();


	}
	void Update()
	{
		var device = SteamVR_Controller.Input((int)trackedObj.index);
		if (device.GetPress(SteamVR_Controller.ButtonMask.Grip))
		{
			if (gr != null)
			{
				grap = false;
				gr.transform.parent = transform;
				gr.transform.localPosition = Vector3.zero;
				gr.transform.localEulerAngles = Vector3.zero;
			}
		}
		else if (device.GetPressUp(SteamVR_Controller.ButtonMask.Grip))
		{
			if (!grap)
			{
				grap = true;
				Debug.Log("ㅁㄴㅇ");
				gr.AddComponent<Rigidbody>().velocity = device.velocity;
				gr.GetComponent<Rigidbody>().angularVelocity = device.angularVelocity;
				gr.transform.parent = null;
			}
		}
		//Debug.Log(grap);
		//Debug.Log(device.GetPress(SteamVR_Controller.ButtonMask.Grip));//GetTouch(SteamVR_Controller.ButtonMask.Grip));
	}
	private void OnTriggerEnter(Collider cun)
	{
		if (cun.tag == "cun" && grap)
		{
			if (gr == null)
			{
				gr = cun.gameObject;
			}
		}

	}
	private void OnTriggerExit(Collider cun)
	{
		if (cun.tag == "cun" && grap)
		{
			if (gr == cun.gameObject)
			{
				Debug.Log("sdf2");
				gr = null;
			}
		}

	}

}

