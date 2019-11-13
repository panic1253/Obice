using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Lazerof : MonoBehaviour
{
    SteamVR_TrackedObject trackedObject;
    public GameObject[] Lazer = new GameObject[2];
    public bool test;
    public bool test2;
    float MaxDistance = 200f;
    [SerializeField]
    public LayerMask uI;

    public AudioSource button;
    private void Awake()
    {
        trackedObject = GetComponent<SteamVR_TrackedObject>();
    }

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        var device = SteamVR_Controller.Input((int)trackedObject.index);
        if (device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            Lazer[0].SetActive(true);
            Lazer[1].SetActive(false);

            test = true;
        }

      

        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.forward * MaxDistance, Color.red, 0.3f);
        if (Physics.Raycast(transform.position, transform.forward * MaxDistance, out hit, 100))
        {
            if (hit.transform.tag == "UI"&& test2)
            {
                button.Play();
                test2 = false;
            }

            if (test)
            {
                test = false;
                if (hit.transform.GetComponent<Button>())
                {
                    hit.transform.GetComponent<Button>().onClick.Invoke();
                }
            }
        }
        else
        {

            test2 = true;
            test = false;
        }
    }
}
