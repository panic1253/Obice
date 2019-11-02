 using UnityEngine;
using System.Collections;

public class Arrow : MonoBehaviour
{
	//Transform makePos;

	bool m_bStartCheck = false;

	public float Angle = 45.0f; // ?? 앵글이 45도인데 왜 45도로 셋팅해서 하는지는 모르겠다.
	public float Power = 0.01f;// 기본 파워값 

	float Timedir; //시간값 (시간흐름)
	float Gravity;//중력값

	Vector3 v1;
	public void SetArrowCheck(bool check, Vector3 pos, Quaternion q)// check는 boll 형태 vector3는 pos 로 표기 Quaternion(회전값)은 q로 표기
    { //화살을 불러오는 함수
		m_bStartCheck = check;// 시작지점 체크
		transform.position = pos;//position은 pos 
		transform.rotation = q;// rotation은 q
	}
   // public bool GetArrowCheck() { return m_bStartCheck; }// 


	void Start()
	{
		//makePos = transform;// makePos의 위치를 transform으로 움직임
        Gravity = -(1.0f * Timedir * Timedir / 2.0f);//고정 중력값
													 //리얼한 중력값을 구하려고 이런식으로 하는 거 같다. 중력 계산값은
													 //0,98888로 하면 더 리얼한 중력값을 받게끔 할 수 있다.
	}

	void Update()
	{
		//if (m_bStartCheck == false) return;
		Timedir += Time.deltaTime;
		v1.z = Power = Mathf.Cos(Angle * Mathf.PI / 180.0f) * Timedir;//코사인 계산값 0.785 z축
		v1.y = Power = Mathf.Cos(Angle * Mathf.PI / 180.0f) * Timedir * Gravity;//코사인 계산값 0.785 y축*중력값
        transform.Translate(v1);//매프레임마다 V1좌표만큼 이동시킨다

		transform.Rotate(new Vector3(Mathf.Cos(Angle * Mathf.PI / 180.0f), 0, 0));
        //매프레임마다X좌표는(Cos(Angle * Mathf.PI / 180.0f))이계산값만큼 회전시킨다Y,Z축은 변동없음 
    }

	/*void OnTriggerEnter(Collider col)
	{
		if (col.tag == "Player")
		{
			Debug.Log("헐");
			transform.position = makePos.position;
			v1 = new Vector3(0, 0, 0);//충돌하였으니 초기화
			Power = 0.0f;//충돌하였으니 초기화
			m_bStartCheck = false;
		}
		else if (col.tag != "Enemy")
		{
			transform.position = makePos.position;
			v1 = new Vector3(0, 0, 0);//충돌하였으니 초기화
			Power = 0.0f;//충돌하였으니 초기화
			m_bStartCheck = false;
			Debug.Log(col.tag);
		}
	}*/
}