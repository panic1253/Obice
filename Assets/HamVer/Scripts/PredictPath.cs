using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PredictPath : MonoBehaviour
{
    public bool mIsActive;
    public GameObject player;
    public int mCount = 100;
    public float mCurveValue = 40;
    public float mGravity = -1;
    public Vector3 mVelocity;
    public Vector3 mGroundPos;
    public List<Transform> mRenderList = new List<Transform>();
    public Material matPointColor;

    void Start()
    {
        CreateRender();
    }
    void CreateRender()
    {
        for (int i = 0; i < mCount; i++)
        {
            GameObject obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
            obj.layer = LayerMask.NameToLayer("IgnoreRayCast");
            obj.transform.parent = transform;
            obj.transform.localPosition = new Vector3(0.1f, 0.1f, 0.1f);
            obj.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            obj.GetComponent<MeshRenderer>().material = matPointColor;
            Destroy(obj.GetComponent<BoxCollider>());

            mRenderList.Add(obj.transform);
            mRenderList[i].gameObject.SetActive(false);
        }
    }
    private void Update()
    {
        if (mIsActive)
        {
            ShowPath();
        }
        else
        {
            HidePath();
        }
    }
    void HidePath()
    {
        if (mGroundPos != Vector3.zero)
        {
            player.transform.position = new Vector3(mGroundPos.x, player.transform.position.y, mGroundPos.z);
        }
        for (int i = 0; i < mCount; i++)
        {
            if (mRenderList[i].gameObject.activeSelf == false)
            {
                continue;
            }
            mRenderList[i].gameObject.SetActive(false);
        }
        mGroundPos = Vector3.zero;
    }
    void ShowPath()
    {
        if (mRenderList.Count == 0)
        {
            CreateRender();
        }

        Vector3 pos = transform.position;
        Vector3 g = new Vector3(0, mGravity, 0);
        mVelocity = transform.forward * mCurveValue;

        for (int i = 0; i < mCount; i++)
        {
            float t = i * 0.001f;
            pos = pos + (mVelocity * t) + (0.5f * g * t * t);
            mVelocity += g;
            mRenderList[i].position = pos;
            mRenderList[i].gameObject.SetActive(true);
        }
        CheckGround();
    }
    void CheckGround()
    {
        int closeIdx = 0;
        float dist = 100;
        RaycastHit hit;
        mGroundPos = Vector3.zero;

        for (int i = 0; i < mCount; i++)
        {
            if (!mRenderList[i].gameObject.activeSelf)
            {
                continue;
            }
            if (Physics.Raycast(mRenderList[i].position, Vector3.down, out hit, Mathf.Infinity))
            {
                if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Ground") == false)
                {
                    continue;
                }
                float curDist = Vector3.Distance(mRenderList[i].position, hit.point);

                if (dist < curDist)
                {
                    continue;
                }
                closeIdx = i;
                mGroundPos = hit.point;
                Debug.Log(mGroundPos);
            }
        }
        for (int i = closeIdx; i < mCount; i++)
        {
            mRenderList[i].gameObject.SetActive(false);
        }
    }
}
