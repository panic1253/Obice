using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ControllerControl : MonoBehaviour
{

	SteamVR_TrackedObject trackedObj;
	 GameObject arraw;
	 GameObject String;
    public GameObject bf;
	public bool donGrapString = true;
	public bool donGrap = true;//bool 함수 donGrap이 true면 물체와 충돌한것
	public bool test = false;
    bool bIsBowFrame=true;
	bool bGetBowString = false;
	bool bowString;
    void Awake()
	{
		trackedObj = GetComponent<SteamVR_TrackedObject>();
	}

	void Update()
	{
		var device = SteamVR_Controller.Input((int)trackedObj.index);//디바이스(컨트롤러를 인식받아오는코드)
		if (device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))// 조건:트리거 버튼을 눌럿을때
		{
            
            if (arraw != null)//if조건 : arraw의 값이 없지 않을때
			{
				if (test != true)//test가 true가 아닐때
				{
					test = true;//test는 true
					donGrap = false;//dongrap은false
					arraw.transform.parent = transform;// arraw의 부모를 transform 으로바꿔줌
					arraw.GetComponent<BoxCollider>().enabled = false;//arraw에 boxcollider추가 ,콜ㄹ라이더 체크풀음
					arraw.GetComponent<Rigidbody>().isKinematic = true;//arraw에 rigidbody추가후iskinematic체크
					arraw.transform.localPosition = Vector3.zero;// arraw의 localPosition을 zero로바꿈(localPosition 은 기본적인 포지션이아닌 따로 부모가 잡혀져있는 포지션)
					arraw.transform.localEulerAngles = Vector3.zero;// arraw의 localEulerAngles을 zero로바꿈
				}
				else// test가 true일때
				{
					test = false;//test는 false
					donGrap = true;//물건을잡음
					arraw.GetComponent<BoxCollider>().enabled = true;//arraw에 boxccollider 추가 체크
					arraw.GetComponent<Rigidbody>().velocity = device.velocity;//arraw의 Rigibody라는 컴포넌트추가 컴포넌트의vector의속력과 device 의속력과같다
					arraw.GetComponent<Rigidbody>().angularVelocity = device.angularVelocity;//	arraw의 Rigibody라는 컴포넌트추가 컴포넌트의angular의 속력과 device의 angular속력이같다
					arraw.GetComponent<Rigidbody>().isKinematic = false;//arraw에 rigidbody추가후iskinematic체크풀음
                    arraw.transform.parent = transform;//arraw의 부모를 null로 바꿈		
				}
			}
		}
		if (String != null)// string의 값이 없지않을때
		{//bowStringCenter.GetComponent<BoxCollider>().enabled	
           
			if (device.GetPress(SteamVR_Controller.ButtonMask.Trigger))// 조건:트리거 버튼을 눌럿을때
			{
                
                
				String.GetComponent<BoxCollider>().enabled = false;// string에 boxcollider추가후 체크풀음
				donGrapString = false;// donGrapString 은 false
            }
			else// 트리거를 누르지않았을때
			{
				String.GetComponent<BoxCollider>().enabled = true;// string에 boxcollider추가후 체크
                donGrapString = true;//donGrapString 은 true
            }
			if (!donGrapString)//donGrapString은 false
            {
				String.transform.position = transform.position;//string의 transform.position은 transform.position이다
            }
		}

	}
	private void OnTriggerEnter(Collider col)//OnTriggerEnter 는 트리거와 오브젝트가 충돌했을때 실행(collider은 col)
	{
		if (col.tag == "BowFrame" && arraw != col.gameObject)// col의 태그는BowFrame그리고 arraw와 col의 gameobject와같지않다
        {
            if (donGrap)//조건: 물건을잡았을때
            {Debug.Log("sa");
                //Debug.Log("asda");
                arraw = col.gameObject;// arraw의 값은 col.gameobject이다
            }
		}
        else if (col.tag == "BowString" && arraw != col.gameObject)// col의 tag는 BowString이다 그리고 arraw와 col의 gameobject와같지않다
        {
            if (donGrapString)//조건: 활시위을잡았을때
            {
				String = col.gameObject;// string의 값은 col.gameobject이다
            }
        }
    }
	private void OnTriggerExit(Collider col)//OnTriggerExit 는 오브젝트와 트리거의 충돌이 끝났을때실행
	{
		if (col.tag == "BowFrame" && donGrap)//col 의tag는 BowFrame 이다 그리고 물체와컨트롤러가 충돌한다
        {
			arraw = null;//arraw 의 값을 null로 바꿔준다.
		}
        else if (col.tag == "BowString" && donGrapString)//col 의tag는 BowString 이다 그리고 활의 시위를 잡음
        {
			String = null;//string 의 값을 null로 바꿔준다.
        }
    }
} 
