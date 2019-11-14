using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowBasic : MonoBehaviour
{
    public float attackDam = 70;
    public float speed = 5;
	void Update ()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    void OnTriggerEnter(Collider col)
    {
       // effctObj = Instantiate(effctPrefabs, transform.position, Quaternion.identity);
       // effctObj.GetComponent<ParticleSystem>().Play();
       // Destroy(effctObj, 1);
        Destroy(gameObject);
        if (col.GetComponent<VolvoAI>())
        {
            col.GetComponent<VolvoAI>().Damage(attackDam);
        }
        else
        {

        }
    }
}
