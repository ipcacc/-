using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{

    float score;
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        int startingMoney = InitialMoneyManager.LoadInitialMoney();
        MoneyManager.SaveMoney(startingMoney); // ���� �� ����
    }

    void Update()
    {
        // �Է� �ޱ� (WASD)
        movement.x = Input.GetAxisRaw("Horizontal"); // A, D �Ǵ� �� ��
        movement.y = Input.GetAxisRaw("Vertical");   // W, S �Ǵ� �� ��
    }

    void FixedUpdate()
    {
        // ���� ������ ����
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
    