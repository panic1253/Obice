using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CLIC : MonoBehaviour
{
	public bool test = false;

	// Use this for initialization
	void Start()
	{


	}

	// Update is called once per frame
	void Update()
	{
		Debug.Log(test);
		if (Input.GetKeyDown(KeyCode.A))
		{
			if (test != true)
			{
				test = true;
			}
			else
			{
				test = false;
			}


		}
	}
}
