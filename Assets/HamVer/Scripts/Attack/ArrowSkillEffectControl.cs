using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowSkillEffectControl : MonoBehaviour
{
    public float attackDam = 400;
    public GameObject effectOBJ;
    public float speed = 5;
    private void Awake()
    {
        GameObject effect = Instantiate(effectOBJ, transform.position,transform.rotation);
        Destroy(effect, 1);
    }
    void Update ()
    {
        transform.Translate(Vector3.forward * Time.deltaTime* speed);
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
