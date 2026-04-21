using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour

{
    public GameObject prefabsMonster;

    float nowTime;
    float minTime = 1f;
    float maxTime = 5f;

    public float createTime = 1f;

    private void Start()
    {
        createTime = Random.Range(minTime, maxTime);
    }

    void Update()
    {
        nowTime = nowTime + Time.deltaTime;

        if (nowTime > createTime)
        {
            GameObject monster = Instantiate(prefabsMonster);

            Vector3 spawnPos = transform.position;
            spawnPos.z = 0f; // z ∞Ì¡§

            monster.transform.position = spawnPos;

            nowTime = 0f;
            createTime = Random.Range(minTime, maxTime);
        }
    }
}
