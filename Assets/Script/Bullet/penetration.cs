using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class penetration : MonoBehaviour
{
    public float speed = 10f;
    public float damage = 30f;
    public float lifetime = 5f; // �� �� �� �ڵ� ����

    private Rigidbody2D rb;
    private HashSet<GameObject> hitEnemies = new HashSet<GameObject>();

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        //������ �������� �߻�
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
            hitEnemies.Add(collision.gameObject); // �ߺ� �ǰ� ����
        }
    }
}
