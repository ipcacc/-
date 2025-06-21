using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boom : MonoBehaviour
{
    public float speed = 10f;
    public float explosionRadius = 3f;
    public float damage = 40f;
    public float lifetime = 5f;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // 오른쪽 위 방향으로 발사 (↗)
        Vector2 direction = new Vector2(0.5f, 0.7f).normalized;
        rb.velocity = direction * speed;

        Destroy(gameObject, lifetime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 이후 인식 방법 변경
        if (collision.GetComponent<Enemy>() != null)
        {
            Explode();
            Destroy(gameObject);
        }
    }

    void Explode()
    {
        //주변 모든 Collider2D 감지
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, explosionRadius);

        foreach (Collider2D hit in hits)
        {
            Enemy enemy = hit.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
