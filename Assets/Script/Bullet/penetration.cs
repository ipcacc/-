using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class penetration : MonoBehaviour
{
    public float speed = 10f;
    public float damage = 30f;
    public float lifetime = 5f; // 몇 초 후 자동 제거

    private Rigidbody2D rb;
    private HashSet<GameObject> hitEnemies = new HashSet<GameObject>();

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        //오른쪽 방향으로 발사
        Vector2 direction = Vector2.right;
        rb.velocity = direction * speed;

        Destroy(gameObject, lifetime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        if (enemy != null && !hitEnemies.Contains(collision.gameObject))
        {
            enemy.TakeDamage(damage);   
            hitEnemies.Add(collision.gameObject); // 중복 피격 방지
        }
    }
}
