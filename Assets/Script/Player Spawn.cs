using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    public GameObject[] spawnablePrefabs; // ��ȯ ������ ������ ���
    public int cost = 500;
    public Transform spawnArea; // ���� ��ġ
    public int numberOfFollowers = 3;


    public void TrySpawnRandomObjects()
    {
        int currentMoney = MoneyManager.LoadMoney();
        if (currentMoney < cost)
        {
            Debug.Log("���� �����մϴ�.");
            return;
        }

        MoneyManager.SpendMoney(cost);


        int randomIndex = Random.Range(0, spawnablePrefabs.Length);
        Vector3 spawnPos = spawnArea.position + new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0);
        GameObject spawned = Instantiate(spawnablePrefabs[randomIndex], spawnPos, Quaternion.identity);

        Debug.Log($"���� ������Ʈ 1�� ��ȯ��: {spawnablePrefabs[randomIndex].name}");

        // BulletFire ������Ʈ�� ������, �÷��̾� ���� ����
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
