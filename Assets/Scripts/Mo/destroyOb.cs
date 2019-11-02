using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class destroyOb : MonoBehaviour
{
    public ParticleSystem EX;

    private void OnTriggerEnter(Collider col)
    {
        if (col.transform.tag == "Enemy")
        {
            Destroy(col.gameObject);
            Debug.Log("ss");
            //Instantiate(EX, transform.position, Quaternion.identity);
        }
    }
}