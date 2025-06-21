using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{

    float score;
    public GameObject projectilePrefab;
    public float fireRate = 0.5f; // �ʴ� �߻� Ƚ��
    private float timer = 0f;

    private void Awake()
    {
        score = 5000f;
    }

    private void Updata()
    {
        score -= Time.deltaTime;
    }

    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // �Է� �ޱ� (WASD)
        movement.x = Input.GetAxisRaw("Horizontal"); // A, D �Ǵ� �� ��
        movement.y = Input.GetAxisRaw("Vertical");   // W, S �Ǵ� �� ��
        
        timer += Time.deltaTime;

        if (timer >= fireRate)
        {
            Fire();
            timer = 0f;
        }
    }

    void FixedUpdate()
    {
        // ���� ������ ����
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void Fire()
    {
        Instantiate(projectilePrefab, transform.position, Quaternion.identity);
    }
}
    