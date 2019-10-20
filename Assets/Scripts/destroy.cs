using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy : MonoBehaviour
{
    public float DestroyTime = 20.0f;
    void Start()
    {
        Destroy(gameObject, DestroyTime);
    }
}