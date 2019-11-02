using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerStatusManager script_PlayerStatusManager;
    MonsterSpawnControl script_MonsterSpawnControl;

    private void Awake()
    {
        script_MonsterSpawnControl = GetComponent<MonsterSpawnControl>();
    }

    void Update ()
    {
       
	}
}
