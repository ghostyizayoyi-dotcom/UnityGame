using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 10f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // 核心：强制唤醒，防止物体进入睡眠状态无法移动
        rb.WakeUp();

        float moveInput = Input.GetAxis("Horizontal");

        // 这一步改变速度
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        // 跳跃
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
}