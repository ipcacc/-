using UnityEngine;

public class BulletFire : MonoBehaviour
{
    public Transform player;
    public GameObject projectilePrefab;
    public float fireRate = 1f;
    public float moveSpeed = 5f;

    private float timer = 0f;
    private Rigidbody2D rb;
    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (player != null)
        {
            // 플레이어의 입력 복제
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
            movement = movement.normalized;
        }

        // 자동 발사 타이머
        timer += Time.deltaTime;
        if (timer >= fireRate)
        {
            Fire();
            timer = 0f;
        }
    }

    void FixedUpdate()
    {
        // 플레이어와 같은 방향으로 이동
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void Fire()
    {
        Instantiate(projectilePrefab, transform.position, Quaternion.identity);
    }
}
