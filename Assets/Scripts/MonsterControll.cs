using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterControll : MonoBehaviour {

    public enum CurrentState{ idle,trace,attack,dead};
    public CurrentState curState = CurrentState.idle;
    private Transform _transform;
    private Transform playerTransform;
    private NavMeshAgent nvAgent;
    private Animator _animator;

    public float traceDist = 50.0f;//추적 사정거리
    public float attackDist = 20.0f;//공격 사정거리


    private bool isDead = false;//사망여부

	
	void Start () {
        _transform = this.gameObject.GetComponent<Transform>();
        playerTransform = GameObject.FindWithTag("PLAYER").GetComponent<Transform>();
        nvAgent = this.gameObject.GetComponent<NavMeshAgent>();


        // nvAgent.destination = playerTransform.position;
        StartCoroutine(this.CheckState());
        StartCoroutine(this.CheckStateForAction());
		
	}
    IEnumerator CheckState()
    {
        while (!isDead)
        {
            yield return new WaitForSeconds(0.2f);

            float dist = Vector3.Distance(playerTransform.position, _transform.position);
            if(dist <= attackDist)
            {
                curState = CurrentState.attack;
            }
            else if(dist <= traceDist)
            {
                curState = CurrentState.trace;
            }
            else
            {
                curState = CurrentState.idle;
            }
        }
    }

    IEnumerator CheckStateForAction()
    {

        while (!isDead)
        {
            switch (curState)
            {
                case CurrentState.idle:
                    nvAgent.Stop();
                    _animator.SetBool("isTrace", false);
                    break;
                case CurrentState.trace:
                    nvAgent.destination = playerTransform.position;
                    nvAgent. Resume();
                    _animator.SetBool("isTrace", true);
                    break;
                case CurrentState.attack:
                    break;
            }
            yield return null;
        }
    }


   
}
