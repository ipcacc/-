using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public float damage = 10f;
    public float lifetime = 5f;

    void Start()
    {
        // ���� �ð� �� �ڵ� �ı�
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        // ������ �������� �̵�
        GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            // ������ ó��
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }

            // �߻�ü �ı�
            Destroy(gameObject);
        }
    }
}
