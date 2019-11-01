using UnityEngine;
public class StringControl : MonoBehaviour
{
    public GameObject arrowPrefab;
    GameObject arrow;
    public GameObject bowframe;
    public GameObject bowStringCenter;//bowStringCenter이라는 gameobject를 공개
    public LineRenderer bowString;//bowString의LineRenderer 가져옴
    Vector3[] currentBowStringPos = new Vector3[3];//bowString 의 3개의 위치설정 
    Vector3[] freezeBowStringPos = new Vector3[3];//bowString 의 3개의 위치설정 
    
    bool bowf = true;
    bool Arrow = true;
    bool bPreparedArrow = false;
    void Start()
    {
        bowStringCenter.transform.localPosition = new Vector3(0, 0.44f, 0);//활시위의 중심의 로컬포지션을 (0,292,0)으로 좌표지정
        currentBowStringPos[0] = new Vector3(0, 0.44f, -0.849f);// pos0번의 새로운vector좌표를 설정
        currentBowStringPos[1] = bowStringCenter.transform.localPosition;//bowstring의 중심의좌표의 로컬표지션을 트렌스폼한다
        currentBowStringPos[2] = new Vector3(0, 0.44f, 0.849f);//pos1번의 새로운 vector좌표를 설정
        freezeBowStringPos = currentBowStringPos;
       
    }
    void Update()
    {

        //Instantiate(생성할 오브젝트,위치,회전갑);

        if (!GetComponent<BoxCollider>().enabled)
        {//boxcollider추가후체크풀음
            if (bowf)
            {
                bowf = false;
                bowStringCenter.GetComponent<BoxCollider>().enabled = true;
                //활을잡았을때 bowstringcenter의boxcollider를킴
            }
            else
            {
                if (bowStringCenter.GetComponent<BoxCollider>().enabled)
                {
                    if(bPreparedArrow)
                    {
                       
                        float bowStringCenterPosX = bowStringCenter.transform.localPosition.x;//bowStringCenter의 y좌표는bowStringCenter의 t로로컬포지션이다.
                        bPreparedArrow = false;
                        bowStringCenter.transform.localPosition = new Vector3(0, 0.292f, 0);
                        arrow.transform.parent = null;
                        //
                        
                        //최소- 0.292f   최대- 1.292f  <  bowStringCenter.transform.localPosition.y-0.292f
                        Debug.Log(bowStringCenter.transform.localPosition.x );
                        arrow.GetComponent<ArrowShout>().SetArrowShoutSpeed(10 * (bowStringCenterPosX - 0.44f));
                        
                        //
                        

                      
                        arrow =null;
                        

                    }
                }
                else
                {
                    if (!bPreparedArrow)
                    {
                        arrow= Instantiate(arrowPrefab, bowStringCenter.transform.position, bowStringCenter.transform.rotation);
                        arrow.transform.parent = bowStringCenter.transform;
                       
                    }
                    bPreparedArrow = true;
                    
                }
            }
        }
        else
        {
            bowf = true;
            bowStringCenter.GetComponent<BoxCollider>().enabled = false;
            Arrow = true;
            
            bPreparedArrow = false;
            
            //활을잡지않았을때 bowStringCenter의 BoxCollider를끔
        }
        if (bowStringCenter.GetComponent<BoxCollider>().enabled)
        {
            bowStringCenter.transform.localPosition = new Vector3(0, 0.44f, 0);
                //. arrow.GetComponent<Arrow>();



        }
        bowStringCenter.transform.localPosition = new Vector3(0, Mathf.Clamp(bowStringCenter.transform.localPosition.y, 0.44f, 1.267f), 0);
        currentBowStringPos[1] = bowStringCenter.transform.localPosition;
        bowString.SetPositions(currentBowStringPos);
                    



      /* if (bowStringCenter.GetComponent<BoxCollider>().enabled)
        {
            bowStringCenter.GetComponent<BoxCollider>().enabled = false;
            Arrow = false;


        }

        else if (bowStringCenter.GetComponent<BoxCollider>().enabled)
        {
            bowStringCenter.GetComponent<BoxCollider>().enabled = true;
            Arrow = true;
            Instantiate(AArrow, transform.position, transform.rotation);

        }*/
    }
}



    
        
