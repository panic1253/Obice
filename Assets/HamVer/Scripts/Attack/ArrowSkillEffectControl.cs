using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowSkillEffectControl : MonoBehaviour
{
    public GameObject effectOBJ;
    public float speed = 5;
    private void Awake()
    {
        GameObject effect = Instantiate(effectOBJ, transform.position,transform.rotation);
        //Destroy(effect, 1);
    }
    void Update ()
    {
        transform.Translate(Vector3.forward * Time.deltaTime* speed);
	}
}
