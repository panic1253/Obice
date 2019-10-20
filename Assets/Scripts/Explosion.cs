using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{

    public float ObjectSize = 0.2f;
    public int ObjectsInRow = 5;
    public Object myobject;
    public GameObject gb;

    float ObjectPivotDistance;
    Vector3 cubesPivot;

    public float explosionForce = 50f;
    public float explosionRadius = 4f;
    public float explosionUpward = 0.4f;

    // Use this for initialization
    void Start()
    {


        //calculate pivot distance
        ObjectPivotDistance = ObjectSize * ObjectsInRow / 2;
        //use this value to create pivot vector)
        cubesPivot = new Vector3(ObjectPivotDistance, ObjectPivotDistance, ObjectPivotDistance);

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Plane")
        {
            explode();
        }

    }

    public void explode()
    {
        //make object disappear
        gameObject.SetActive(false);

        //loop 3 times to create 5x5x5 pieces in x,y,z coordinates
        for (int x = 0; x < ObjectsInRow; x++)
        {
            for (int y = 0; y < ObjectsInRow; y++)
            {
                for (int z = 0; z < ObjectsInRow; z++)
                {
                    createPiece(x, y, z);
                }
            }
        }

        //get explosion position
        Vector3 explosionPos = transform.position;
        //get colliders in that position and radius
        Collider[] colliders = Physics.OverlapSphere(explosionPos, explosionRadius);
        //add explosion force to all colliders in that overlap sphere
        foreach (Collider hit in colliders)
        {
            //get rigidbody from collider object
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null)
            {
                //add explosion force to this body with given parameters
                rb.AddExplosionForce(explosionForce, transform.position, explosionRadius, explosionUpward);
            }
        }

    }

    void createPiece(int x, int y, int z)
    {

        //create piece
        GameObject piece;
       //piece = GameObject.Creategb(gb);

        //set piece position and scale
       // piece.transform.position = transform.position + new Vector3(ObjectSize * x, ObjectSize * y, ObjectSize * z) - cubesPivot;
       // piece.transform.localScale = new Vector3(ObjectSize, ObjectSize, ObjectSize);

        //add rigidbody and set mass
      //  piece.AddComponent<Rigidbody>();
       // piece.GetComponent<Rigidbody>().mass = ObjectSize;
    }

}
