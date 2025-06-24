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
        // �׾��� �� ó�� (����Ʈ, ����, ��)
        ScoreManager.AddScore(10000); // ���� �߰�
        Debug.Log("���� ����");
        MoneyManager.AddMoney(500); // �� �߰�
        Destroy(gameObject);
    }

    void Update()
    {
        //���� ���� ����
        transform.Translate(Vector3.right * -moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall"))
        {
            Debug.Log("���� ���� �� ��");
            Destroy(gameObject);
        }
        else
            Debug.Log("ü�� ����");
    }
}
