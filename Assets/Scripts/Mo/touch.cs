using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touch : MonoBehaviour
{
	GameObject Con;
	SteamVR_TrackedObject trackedObj;
	bool grap = true;


	// Use this for initialization
	void Awake()
	{
		trackedObj = GetComponent<SteamVR_TrackedObject>();


	}

	// Update is called once per frame
	void FixedUpdate()
	{
		var device = SteamVR_Controller.Input((int)trackedObj.index);
		if (device.GetTouchDown(SteamVR_Controller.ButtonMask.Touchpad))
		{
			grap = false;
			Con.transform.parent = transform;
			Con.transform.localPosition = Vector3.zero;
			Con.transform.localEulerAngles = Vector3.zero;
		}



		else if (device.GetTouchUp(SteamVR_Controller.ButtonMask.Touchpad))
		{
			if (!grap)
			{
				grap = true;
				Debug.Log("ㅁㄴㅇ");
				Con.transform.parent = null;
				Con.AddComponent<Rigidbody>().velocity = device.velocity;
				Con.GetComponent<Rigidbody>().angularVelocity = device.angularVelocity;
			}


		}
	}
	private void OnTriggerEnter(Collider cun)
	{
		if (cun.tag == "cun" && Con != cun.gameObject)
		{
			if (grap)
				Con = Con.gameObject;

		}

	}
	private void OnTriggerExit(Collider cun)
	{
		if(cun.tag == "cun"&& grap)
		{
			if (!grap)
				Con = null;
		}
		
	}
	void Update()
	{
		if (grap)
		{

		}
		if (!grap)
		{

		}
	}

}
