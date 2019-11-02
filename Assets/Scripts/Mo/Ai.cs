using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ai : MonoBehaviour
{

    //몬스터의 상태정보 있는 eNUMERABLE 변수 선언
    public enum MonsterState { idle, trace, attack, die };
    public MonsterState monsterState = MonsterState.idle;

    //각종 컴포넌트 미리 저장
    private Transform monsterTr;
    public Transform[] ooobj = new Transform[2];
    public Transform ObiceTr;
    public Transform PlayerTr;
    public NavMeshAgent nvAgent;
    Animator animator;


    //추적 거리.
    public float traceDist = 10f;
    //공격 거리.
    public float attackDist = 2f;
    //몬스터 사망 여부
    private bool isDie = false;
    Transform target ;

    // Use this for initialization
    void Start()
    {
        monsterTr = GetComponent<Transform>();
        PlayerTr = GameObject.FindWithTag("PLAYER").GetComponent<Transform>();
        Debug.Log("sda");
        ObiceTr = GameObject.FindWithTag("Obice").GetComponent<Transform>();
        nvAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
       
        StartCoroutine(test());
        //일정한 간격으로 몬스터의 행동상태를 체크
        //  StartCoroutine(CheckMonsterState());
        //몬스터의 상태에 따른 동작
        // StartCoroutine(MonsterAction());
    }
    bool shoot = true;
    bool fire = false;
    bool obis = false;

    // Update is called once per frame
    
    void Update()
    {
        if (fire)
        {
            nvAgent.destination = ObiceTr.position;
           
        }
        else if (!fire && obis)
        {
            nvAgent.destination = ObiceTr.position;
            monsterState = MonsterState.attack;
            animator.SetBool("isAttack", true);
            Debug.Log(monsterState);
            nvAgent.Stop();
           /*if (obis)
            {
                shoot = true;
                monsterState = MonsterState.trace;
                Debug.Log(monsterState);
                nvAgent.Stop();

            }*/
        }
        else
        {
            nvAgent.destination = PlayerTr.position;
            monsterState = MonsterState.trace;
            Debug.Log(monsterState);
            nvAgent.Resume();
            
        }

    }
    IEnumerator test()
    {


        Transform[] obj = new Transform[2];
        obj[0] = ooobj[0];
        obj[1] = ooobj[1];
        float[] disValue = new float[2];
        float traceDist = 10.0f;
        float attackDist2 = 5.0f;
        while (!isDie)
        {
            for (int i = 0; i < obj.Length; i++)
            {
                disValue[i] = Vector3.Distance(obj[i].position, transform.position);
            }
            float testttt;

            if (disValue[0] < disValue[1])
            {
                target = obj[0];
                testttt = disValue[0];
            }
            else
            {
                target = obj[1];
                testttt = disValue[1];
            }

            if (testttt < traceDist)
            {
                fire = true;
                obis = false;
                if (testttt < attackDist2)
                {
                    fire = false;
                    monsterState = MonsterState.attack;
                    Debug.Log(monsterState);
                    Debug.Log(target);
                    animator.SetBool("isAttack", true);
                    nvAgent.Stop();
                   
                    
                    /*if (traceDist <= attackDist2)
                    {
                        shoot = true;
                        monsterState = MonsterState.attack;
                        animator.SetBool("isAttack", true);
                        nvAgent.Stop();
                    }
                    if (traceDist >= attackDist2)
                    {
                        shoot = false;
                        Debug.Log("2");
                        monsterState = MonsterState.trace;
                        animator.SetBool("isAttack", false);
                        nvAgent.destination = obj[0].position;
                    }*/



                }
                else
                {
                    fire = false;
                    obis = true;
                    monsterState = MonsterState.trace;
                    Debug.Log(monsterState);
                    animator.SetBool("isAttack", false);
                    nvAgent.Resume();
                    
                    /*  Debug.Log("asdfasd2");
                      if (traceDist <= attackDist2)
                      {
                          shoot = true;
                          monsterState = MonsterState.attack;
                          animator.SetBool("isAttack", true);
                          nvAgent.Stop();
                      }
                      /*if (traceDist >= attackDist2)
                      {
                          shoot = false;
                          Debug.Log("2");
                          monsterState = MonsterState.trace;
                          animator.SetBool("isAttack", true);
                          nvAgent.destination = obj[1].position;
                      }*/


                }

                /*if (testttt < 3)
                {
                    shoot = true;
                }
            }
            else
            {
                shoot = false;
            }*/
            }
            yield return null;
        }

        /*IEnumerator CheckMonsterState()
        {
            while (!isDie)
            {
                Transform[] obj = new Transform[2];
                obj[0] = ooobj[0];
                obj[1] = ooobj[1];
                float[] disValue = new float[2];
                float traceDist = 10;
                float attackDist2 = 5;
                yield return new WaitForSeconds(0.2f);

                //몬스터와 플레이어 거리측정.
                float dist1, dist2;
                dist1 = Vector3.Distance(playerTr.position, monsterTr.position); 
                dist2 = Vector3.Distance(ObiceTr.position, monsterTr.position);
                Debug.Log(dist1);
                for (int i = 0; i < obj.Length; i++)
                {
                    disValue[i] = Vector3.Distance(obj[i].position, transform.position);
                }
                float testttt;

                if (disValue[0] < disValue[1])
                {
                    target = obj[0];
                    testttt = disValue[0];
                }
                else
                {
                    target = obj[1];
                    testttt = disValue[1];
                }

                if (testttt < traceDist)
                {
                    fire = true;
                    if (testttt < attackDist2)
                    {
                        Debug.Log("asdfasd");
                        if (dist1 <= attackDist)   //공격 범위 이내에 들어왔는가?
                        {
                            fire = true;
                            monsterState = MonsterState.attack;
                            animator.SetBool("isAttack", true);
                            Debug.Log("asdf");
                            nvAgent.Stop();
                        }
                        if (dist1 >= attackDist)
                        {
                            fire = false;
                            Debug.Log("2");
                            monsterState = MonsterState.trace;
                            animator.SetBool("isAttack", false);
                            nvAgent.destination = playerTr.position;


                              else
                               {
                                   Debug.Log("3");
                                   monsterState = MonsterState.idle;
                               }
                        }
                        else
                        {
                            Debug.Log("1");
                            monsterState = MonsterState.attack;
                            animator.SetBool("isAttack", true);
                        }

                    }
                    else
                    {
                        Debug.Log("asdfasd2");
                        if (dist2 <= attackDist)   //공격 범위 이내에 들어왔는가?
                        {
                            fire = true;
                            Debug.Log("asdf");
                            nvAgent.Stop();
                        }
                        if (dist2 >= attackDist)
                        {
                            fire = false;
                            Debug.Log("2");
                            monsterState = MonsterState.trace;
                            animator.SetBool("isAttack", false);
                            nvAgent.destination = playerTr.position;

                            nvAgent.Resume();

                               else
                               {
                                   Debug.Log("3");
                                   monsterState = MonsterState.idle;
                               }
                        }
                        else
                        {
                            Debug.Log("1");
                            monsterState = MonsterState.attack;
                            animator.SetBool("isAttack", true);
                        }
                    }

                }

                    if (testttt < 3)
                    {
                        fire = false;
                    }

                else
                {
                    fire = false;
                }


                yield return null;
            


                }*/


    }
}

    

    
    

 





