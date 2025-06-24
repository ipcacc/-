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
            // �÷��̾��� �Է� ����
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
            movement = movement.normalized;
        }

        // �ڵ� �߻� Ÿ�̸�
        timer += Time.deltaTime;
        if (timer >= fireRate)
        {
            Fire();
            timer = 0f;
        }
    }

    void FixedUpdate()
    {
        // �÷��̾�� ���� �������� �̵�
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void Fire()
    {
        Instantiate(projectilePrefab, transform.position, Quaternion.identity);
    }
}
