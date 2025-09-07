using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMove : MonoBehaviour
{
    /// <summary>
    /// 玩家的基本移动
    /// </summary>
    private Rigidbody2D rb;//通过刚体控制玩家移动
    [SerializeField] private float moveSpeed;//左右移动速度
    [SerializeField] private float jumpSpeed;//跳跃速度    
    private float moveController;//设置unity提供预设方式移动
    private bool isOnGround;//人物在地面上
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Turn();
    }
    //控制玩家的移动函数（AD）
    public void Move()
    {
        moveController = Input.GetAxisRaw("Horizontal");//水平输入移速
        rb.velocity = new Vector2(moveSpeed * moveController, rb.velocity.y);
        if (Input.GetKey(KeyCode.Space) && isOnGround == true )
        {
            rb.velocity = new Vector2(rb.velocity.x,jumpSpeed);
        }

    }
    //控制玩家图层转向
    public void Turn()
    {
        if(rb.velocity.x > 0)
        {
            transform.localScale = new Vector2(1, 1);
        }
        if(rb.velocity.x < 0)
        {
            transform.localScale = new Vector2(-1, 1);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            isOnGround = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            isOnGround = false;
        }
    }
}
