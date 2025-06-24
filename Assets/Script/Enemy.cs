using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 1f;
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
        ScoreManager.AddScore(10000); // 점수 추가
        Debug.Log("점수 증가");
        MoneyManager.AddMoney(500); // 돈 추가
        Destroy(gameObject);
    }

    void Update()
    {
        //적이 가는 방향
        transform.Translate(Vector3.right * -moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall"))
        {
            Debug.Log("적을 막지 못 함");
            Destroy(gameObject);
        }
        else
            Debug.Log("체력 감소");
    }
}
