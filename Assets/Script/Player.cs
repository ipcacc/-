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
        MoneyManager.SaveMoney(startingMoney); // 실제 돈 세팅
    }

    void Update()
    {
        // 입력 받기 (WASD)
        movement.x = Input.GetAxisRaw("Horizontal"); // A, D 또는 ← →
        movement.y = Input.GetAxisRaw("Vertical");   // W, S 또는 ↑ ↓
    }

    void FixedUpdate()
    {
        // 실제 움직임 적용
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
    