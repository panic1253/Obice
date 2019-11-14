using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class VolvoAI : MonoBehaviour
{

    [Header("몬스터 스테이터스 설정")]
    public float physicalStrength = 140;//체력
    public float attack = 2;//공격력
    public float movingDistance = 3;//속도
    public float attackRange = 10;//공격 범위
    public float recognitionRange = 15;//인식 범위
    public float score = 25;//점수
    [Header("몬스터 AI 설정")]
    public GameObject obice;
    public GameObject player;
    NavMeshAgent nvAgent;
    Animator anim;
    GameObject target;
    public GameObject attackPoint;
    public GameObject bullet;
    public AudioSource footstep;
    public AudioSource howlingAudio;
    public AudioSource gunAudio;
    public AudioClip[] sounds;
    bool damege = false;
    float time = 0;
    bool gameEnd = false;
    void Awake()
    {
        nvAgent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        player = GameObject.Find("PlayerStatus");
        obice = GameObject.Find("Obice_");
        target = obice;
        nvAgent.destination = target.transform.position;
    }

    void Update()
    {
        if (player.GetComponent<PlayerStatusManager>().physicalStrength <= 0 || physicalStrength <= 0)
        {
            if (physicalStrength <= 0 && !gameEnd)
            {
                gameEnd = true;
                anim.SetTrigger("Dead");
            }
            anim.SetBool("Attack", false);
            nvAgent.destination = transform.position;
            footstep.Stop();
            return;
        }
        if (!damege)
        {
            float playerDis = Vector3.Distance(transform.position, player.transform.position);
            float obiceDis = Vector3.Distance(transform.position, obice.transform.position);
            float targetDis = Vector3.Distance(transform.position, target.transform.position);
            if (playerDis < recognitionRange)
            {
                if (playerDis < obiceDis)
                {
                    if (target != player)
                    {
                        howlingAudio.clip = sounds[2];
                        howlingAudio.Play();
                    }
                    target = player;
                }
                else
                {
                    if (target != obice)
                    {
                        howlingAudio.clip = sounds[2];
                        howlingAudio.Play();
                    }
                    target = obice;
                }
            }
            else
            {
                target = obice;
            }

            if (targetDis < attackRange)
            {
                nvAgent.destination = transform.position;
                transform.LookAt(target.transform);
                attackPoint.transform.LookAt(target.transform);
                anim.SetBool("Attack", true);

                if (footstep.isPlaying)
                {
                    footstep.Stop();
                }
            }
            else
            {
                anim.SetBool("Attack", false);
                if (!footstep.isPlaying)
                {
                    footstep.Play();
                }
                nvAgent.destination = target.transform.position;
            }
        }
        else
        {
            nvAgent.destination = target.transform.position;
            footstep.Stop();
        }
    }
    public void Anim_Attack()
    {
        Instantiate(bullet, attackPoint.transform.position, attackPoint.transform.rotation).GetComponent<VolvoBullet>().attackDam = attack;
        gunAudio.Play();
    }

    public void Anim_DamegeStart()
    {
        damege = true;
        howlingAudio.clip = sounds[0];
        howlingAudio.Play();
    }

    public void Anim_DamegeEnd()
    {
        damege = false;
    }
    public void Anim_DeadStart()
    {
        GetComponent<Collider>().enabled = false;
        howlingAudio.clip = sounds[1];
        howlingAudio.Play();
    }
    public void Anim_DeadEnd()
    {
        Destroy(gameObject,3);
    }

    public void Damage(float dam)
    {
        physicalStrength -= dam;
    }
}
