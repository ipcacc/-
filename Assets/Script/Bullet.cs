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
        // 일정 시간 후 자동 파괴
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        // 오른쪽 방향으로 이동
        GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            // 데미지 처리
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }

            // 발사체 파괴
            Destroy(gameObject);
        }
    }
}
