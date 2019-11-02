 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour {

    public Transform[] points;
    public GameObject monster;
    public float createTime  = 2.0f;
	// Use this for initialization
	void Start () {

        points = GameObject.Find("SpawnPoint").GetComponentsInChildren<Transform>();
        StartCoroutine(this.CreateMonster());
    }

    IEnumerator CreateMonster()
    {
        // 계속해서 createTime동안 monster생성
        while (true)
        {
            int idx = Random.Range(1, points.Length);
            Instantiate(monster, points[idx].position, Quaternion.identity);

            yield return new WaitForSeconds(createTime);
        }
    }



   
	// Update is called once per frame
	void Update () {
		
	}
}

