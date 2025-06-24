using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    public GameObject[] spawnablePrefabs; // 소환 가능한 프리팹 목록
    public int cost = 500;
    public Transform spawnArea; // 기준 위치
    public int numberOfFollowers = 3;


    public void TrySpawnRandomObjects()
    {
        int currentMoney = MoneyManager.LoadMoney();
        if (currentMoney < cost)
        {
            Debug.Log("돈이 부족합니다.");
            return;
        }

        MoneyManager.SpendMoney(cost);


        int randomIndex = Random.Range(0, spawnablePrefabs.Length);
        Vector3 spawnPos = spawnArea.position + new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0);
        GameObject spawned = Instantiate(spawnablePrefabs[randomIndex], spawnPos, Quaternion.identity);

        Debug.Log($"랜덤 오브젝트 1개 소환됨: {spawnablePrefabs[randomIndex].name}");

        // BulletFire 컴포넌트가 있으면, 플레이어 참조 연결
        BulletFire bulletFire = spawned.GetComponent<BulletFire>();
        if (bulletFire != null)
        {
            GameObject playerObj = GameObject.FindWithTag("Player");
            if (playerObj != null)
            {
                bulletFire.player = playerObj.transform;
            }
        }
    }
}
