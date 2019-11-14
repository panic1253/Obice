using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatusManager : MonoBehaviour
{
    public float maxPhysicalStrength = 100;
    public float physicalStrength = 100;
    public float attackScore = 70;
    public float attackSkill = 400;
    public float minTravelDis = 5;
    public float maxTravelDis = 20;

    float sufferDamageTime = 4;

    public bool bSufferDamage = false;

    float sufferDamageTimer = 0;
    void Start ()
    {
        StartCoroutine(PlayerStatusControl());
	}

    IEnumerator PlayerStatusControl()
    {
        while (physicalStrength > 0)
        {

            if (bSufferDamage)
            {
                sufferDamageTimer += Time.deltaTime;
                if (sufferDamageTimer > sufferDamageTime)
                {
                    bSufferDamage = false;
                    sufferDamageTimer = 0;
                }
            }
            else
            {
                if (physicalStrength < maxPhysicalStrength)
                {
                    physicalStrength += Time.deltaTime * (maxPhysicalStrength * 0.1f);
                }
                else
                {
                    physicalStrength = maxPhysicalStrength;
                }
            }
            yield return null;
        }
        Debug.Log("end");
    }
    public void Damage(float value)
    {
        bSufferDamage = true;
        physicalStrength -= value;
        sufferDamageTimer = 0;
    }
}
