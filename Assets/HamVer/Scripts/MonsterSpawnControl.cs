using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawnControl : MonoBehaviour
{
    public GameObject[] monsterType;
    public Transform[] spawnPoint = new Transform[4];
    public int generationRange = 5;

    float roundClearTime = 180;
    float[] roundLevelTime = { 0, 60, 120 };
    float[,] roundLevelMonsterCount = { { 5, 10, 15 }, { 6, 12, 18 }, { 7, 14, 21 }, { 8, 16, 24 } };
    
    List<GameObject> monster = new List<GameObject>();
    float roundTimer = 0;

    bool bGameStart = false;
    bool bGameClear = false;

    public bool GameClear
    {
        get
        {
            return bGameClear;
        }
    }
    private void Awake()
    {
        StartCoroutine(MonsterSpawn(0));
    }
    private void Update()
    {
        if(bGameStart)
            roundTimer += Time.deltaTime;

        
    }
    IEnumerator MonsterSpawn(int gameLevel)
    {
        int roundTimeLevel = 0;
        bGameStart = true;
        while (true)
        {
            if (roundTimeLevel < roundLevelTime.Length)
            {
                if (roundTimer > roundLevelTime[roundTimeLevel])
                {
                    float monsterCount = roundLevelMonsterCount[gameLevel, roundTimeLevel] - monster.Count;

                    for (int i = 0; i < monsterCount; i++)
                    {
                        Vector3 randomPoint = spawnPoint[Random.Range(0, spawnPoint.Length)].transform.position;
                        Vector3 boxRange = new Vector3(1, 0, 1) * Random.Range(-generationRange, generationRange + 1);

                        monster.Add(Instantiate(monsterType[0], randomPoint + boxRange, Quaternion.identity));
                    }
                    roundTimeLevel++;
                }
            }
            for (int i = 0; i < monster.Count; i++)
            {
                if (!monster[i])
                {
                    Vector3 randomPoint = spawnPoint[Random.Range(0, spawnPoint.Length)].transform.position;
                    Vector3 boxRange = new Vector3(1, 0, 1) * Random.Range(-generationRange, generationRange + 1);

                    monster[i] = (Instantiate(monsterType[0], randomPoint + boxRange, Quaternion.identity));
                }
            }
            if (roundTimer > roundClearTime)
            {
                bGameClear = true;
                break;
            }
            yield return null;
        }
    }
}
