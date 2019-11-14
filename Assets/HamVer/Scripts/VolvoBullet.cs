using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolvoBullet : MonoBehaviour
{
    public float speed = 5;
    public GameObject effctPrefabs;
    public GameObject effctObj;
    public float attackDam = 2;
    void Start()
    {
        Destroy(gameObject, 100);
    }

    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
    void OnTriggerEnter(Collider col)
    {
        effctObj = Instantiate(effctPrefabs, transform.position, Quaternion.identity);
        effctObj.GetComponent<ParticleSystem>().Play();
        Destroy(effctObj, 1);
        Destroy(gameObject);
        if (col.GetComponent<PlayerStatusManager>())
        {
            col.GetComponent<PlayerStatusManager>().Damage(2);
        }
    }
}
