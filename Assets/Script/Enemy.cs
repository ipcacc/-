using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 1f; //적 움직임의 속도
    public float maxHealth = 100f;
    private float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        // 죽었을 때 처리 (이펙트, 점수, 등)
        Destroy(gameObject);
    }

    void Update()
    {
        //적이 가는 방향
        transform.Translate(Vector3.right * -moveSpeed * Time.deltaTime);
    }
}
