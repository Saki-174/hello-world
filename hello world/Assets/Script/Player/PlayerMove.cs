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
    [SerializeField] private float jumpTimeController;//控制跳跃加速最大时间
    [SerializeField] private float upPower;//控制跳跃加速最大时间
    [SerializeField] private float downPower;//控制跳跃加速最大时间
    private float jumpTime;//跳跃加速时间                                             
    private float moveController;//设置unity提供预设方式移动
    private bool isOnGround;//人物是否在地面上，用于跳跃判断
    private bool isJumping;//人物是否正在跳跃，用于跳跃重力控制和二段跳
    
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
        Jump();
    }
    //控制玩家的移动函数（AD）
    public void Move()
    {
        moveController = Input.GetAxisRaw("Horizontal");//水平输入移速
        rb.velocity = new Vector2(moveSpeed * moveController, rb.velocity.y);
    }
    //控制玩家的跳跃
    private void Jump()
    {
        //按住space
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround == true)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
            isJumping = true;//正在跳跃
            jumpTime = 0;
        }
        //松开space
        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;//跳跃结束 
        }
        //上升
        if (isJumping)
        {
            if(jumpTime <= jumpTimeController)
                rb.velocity -= new Vector2(0, Physics2D.gravity.y * Time.deltaTime * upPower);
            else
                isJumping = false ;
            jumpTime += Time.deltaTime;
        }
        
        //下落
        if (!isJumping)
        {
            rb.velocity += new Vector2(0, Physics2D.gravity.y * Time.deltaTime * downPower);
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
