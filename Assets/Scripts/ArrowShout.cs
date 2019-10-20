using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowShout : MonoBehaviour
{
    bool m_bStartCheck = false;

    public float Angle = 45.0f; // ?? 앵글이 45도인데 왜 45도로 셋팅해서 하는지는 모르겠다.
    public float Power = 0.01f;// 기본 파워값 

    float Timedir; //시간값 (시간흐름)
    float Gravity;//중력값

    Vector3 v1;
    public bool bArrowShout=false;//화살이 발사됬는지 true/false로 확인하는거
   public float arrowSpeed = 20;//화살 속도 기본값 10
    public void SetArrowCheck(bool check, Vector3 pos, Quaternion q)// check는 boll 형태 vector3는 pos 로 표기 Quaternion(회전값)은 q로 표기
    { //화살을 불러오는 함수
        m_bStartCheck = check;// 시작지점 체크
        transform.position = pos;//position은 pos 
        transform.rotation = q;// rotation은 q
    }
    public Animator test;
    public void start()
    {
       // Gravity = -(1.0f * Timedir * Timedir / 2.0f);

    }
    bool etste = true;
    void Update()
    {
       // test.SetBool("New Bool", false);
        //test.SetInteger("New Bool", 1);
        if(bArrowShout)//bArrowShout 가 false 일때 
        {
            if (etste)
            {
             //   transform.eulerAngles = new Vector3(transform.eulerAngles.x, 0, 0);
                etste = false;
            }
            transform.Translate(Vector3.up * Time.deltaTime * arrowSpeed);
            //매프레임마다(vector3의 down방향으로 프레임마다 arrowSpeed만큼움직인다 )
            // Timedir += Time.deltaTime;
            // v1.z = Power = Mathf.Cos(Angle * Mathf.PI / 180.0f) * Timedir;//코사인 계산값 0.785 z축
            // v1.y = Power = Mathf.Cos(Angle * Mathf.PI / 180.0f) * Timedir * Gravity;//코사인 계산값 0.785 y축*중력값
            //transform.Translate(v1);//매프레임마다 V1좌표만큼 이동시킨다


            transform.Rotate(new Vector3(/*Mathf.Cos(Angle *Mathf.PI/ 180.0f)*/0.7071068f, 0, 0), Space.World);

            ///Debug.Log(Mathf.Cos(Angle * Mathf.PI / 180.0f));
            
        }
    }
    public void SetArrowShoutSpeed(float speed)
    {
        arrowSpeed = speed*5;
            
        
        bArrowShout = true;//bArrowShout 가 true 가되어 화살이발사된다
        

    }
}
