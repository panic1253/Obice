﻿using UnityEngine;
public class StringControl : MonoBehaviour
{
    public GameObject[] arrowPrefab;
    public GameObject arrowLoaded;
    public GameObject bowStringCenter;//bowStringCenter이라는 gameobject를 공개
    public GameObject bowHandle;
    public LineRenderer bowString;//bowString의LineRenderer 가져옴
    Vector3[] currentBowStringPos = new Vector3[3];//bowString 의 3개의 위치설정 

    
    bool bBowGrip = true;
    bool bArrowLoading = false;

    float bowSkillTime = 0;
    void Start()
    {
        bowStringCenter.transform.localPosition = new Vector3(0, 0, -0.202f);//활시위의 중심의 로컬포지션을 (0,292,0)으로 좌표지정
        currentBowStringPos[0] = new Vector3(0.6f, 0, -0.202f);// pos0번의 새로운vector좌표를 설정
        currentBowStringPos[1] = bowStringCenter.transform.localPosition;//bowstring의 중심의좌표의 로컬표지션을 트렌스폼한다
        currentBowStringPos[2] = new Vector3(-0.6f, 0, -0.202f);//pos1번의 새로운 vector좌표를 설정

    }
    void Update()
    {
        if (!bowHandle.GetComponent<BoxCollider>().enabled)
        {
            if (bBowGrip)
            {
                bBowGrip = false;
                bowStringCenter.GetComponent<BoxCollider>().enabled = true;
            }
            else
            {
                if (bowStringCenter.GetComponent<BoxCollider>().enabled)
                {                   
                    arrowLoaded.SetActive(false);
                    

                  
                    if (bArrowLoading)
                    {
                        if (bowStringCenter.transform.localPosition.z >= -0.3)
                        {
                            Instantiate(arrowPrefab[0], bowStringCenter.transform.position, bowStringCenter.transform.rotation);
                            bArrowLoading = false;
                        }

                        bowStringCenter.transform.localPosition = new Vector3(0, 0, -0.202f);
                        if (bArrowLoading)
                        {
                            if (bowSkillTime < 4)
                            {
                                Instantiate(arrowPrefab[1], bowStringCenter.transform.position, bowStringCenter.transform.rotation);
                            }
                            else
                            {
                                Instantiate(arrowPrefab[2], bowStringCenter.transform.position, bowStringCenter.transform.rotation);
                            }
                        }
                        bArrowLoading = false;
                    }
                    bowSkillTime = 0;
                }
                else
                {
                    arrowLoaded.SetActive(true);

                    bArrowLoading = true;

                    if (currentBowStringPos[1].z < -0.3)//화살 스킬 경계
                    {
                        bowSkillTime += Time.deltaTime;
                    }
                    else
                    {
                        bowSkillTime = 0;
                    }
                    Debug.Log(bowSkillTime);
                }
            }
        }
        else
        {
            arrowLoaded.SetActive(false);
            bowStringCenter.transform.localPosition = new Vector3(0, 0, -0.202f);
            bBowGrip = true;
            bowStringCenter.GetComponent<BoxCollider>().enabled = false;
            bArrowLoading = false;
            bowSkillTime = 0;
        }



        bowStringCenter.transform.localPosition = new Vector3(0, 0, Mathf.Clamp(bowStringCenter.transform.localPosition.z, -0.6f, -0.202f));
        currentBowStringPos[1] = bowStringCenter.transform.localPosition;
        bowString.SetPositions(currentBowStringPos);
    }
}



    
        
