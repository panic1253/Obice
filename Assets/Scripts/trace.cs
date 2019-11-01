using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trace : MonoBehaviour {
    private Transform target;

    private float dist;

    private string[] tags = { "PLAYER", "Obice" };

    GameObject[] taggedWalls = { };

    // Use this for initialization

    void Start()
    {

        Debug.Log("start haptic");

    }



    // Update is called once per frame

    void Update()
    {

        if (target != null)

        {

            Debug.DrawLine(transform.position, target.position, Color.yellow);

        }



        float closestDistSqr = Mathf.Infinity;

        Transform closestWall = null;



        foreach (string tag in tags)

        {

            GameObject[] taggedWalls = GameObject.FindGameObjectsWithTag(tag);



            foreach (GameObject taggedWall in taggedWalls)

            {

                Vector3 objectPos = taggedWall.transform.position;

                dist = (objectPos - transform.position).sqrMagnitude;



                if (dist < closestDistSqr)

                {

                    closestDistSqr = dist;

                    closestWall = taggedWall.transform;
                    Debug.Log(tags);

                }



            }

            target = closestWall;

        }



    }



}



