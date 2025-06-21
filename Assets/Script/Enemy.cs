using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 1f; //�� �������� �ӵ�
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
        Destroy(gameObject);
    }

    void Update()
    {
        //���� ���� ����
        transform.Translate(Vector3.right * -moveSpeed * Time.deltaTime);
    }
}
