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
    [SerializeField] private float jumpSpeed_1;//跳跃速度
    [SerializeField] private float jumpSpeed_2;//二段跳跃速度
    [SerializeField] private float jumpTimeController;//控制跳跃加速最大时间
    [SerializeField] private float upPower;//控制跳跃加速最大时间
    [SerializeField] private float downPower;//控制跳跃加速最大时间
    [SerializeField] private float wallJumpSpeed;//在墙上跳的速度
    [SerializeField] private bool wallJumping = false;//在墙上跳的情况
    private float jumpTime;//跳跃加速时间                                             
    private float moveController;//存储设置unity提供的预设方式移动    
    private bool isJumping;//人物是否正在跳跃，用于跳跃重力控制和二段跳
    private bool doubleJump;//二段跳
    private bool airJump;//空跳
    private PlayerDash dash;//获取喷气脚本
    private AudioSource audioSource;
    public List<AudioClip> audioClips = new List<AudioClip>();//音乐列表
    private Animator animator;//动画
    public static bool isOnGround;//判断角色是否在地面
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        dash = GetComponent<PlayerDash>();
    }

    // Update is called once per frame
    void Update()
    {
        if (dash.isDashing)
        {
            return;//喷气的时候啥也干不了
        }
        else
        {
            if (!wallJumping)
            {
                Move();
            }
            Turn();
            Jump();
            WallJump();
        }
        IsDashing();
        
    }
    //控制玩家的移动函数（AD）
    public void Move()
    {
        moveController = Input.GetAxisRaw("Horizontal");//水平输入移速
        if (moveController != 0f)
        {
            animator.SetBool("IsWalk", true);             
            if(!audioSource.isPlaying)
            {
                audioSource.clip = audioClips[0];
                audioSource.Play();//播放跑步音效
            }
        }
        else 
        {
            animator.SetBool("IsWalk", false);           
        }
       
        rb.velocity = new Vector2(moveSpeed * moveController, rb.velocity.y);        
    }
    //协程控制短暂的玩家不可控制状态
    IEnumerator WallJumping()
    {
        wallJumping = true;
        yield return new WaitForSeconds(0.15f);//等待0.15秒后可以控制玩家移动（蹬墙跳结束）
        wallJumping = false;
    }
    //控制玩家在墙上的跳跃
    private void WallJump()
    {
        if (PlayerIsOnWall.isOnWall && ! isOnGround)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.8f);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //wallJumping = true;//设置为正在蹬墙跳
                rb.velocity = new Vector2(wallJumpSpeed * transform.localScale.x, wallJumpSpeed);
                doubleJump = true;//二段跳成立
                
                StartCoroutine(WallJumping());//启动协程
            }
        }
        //if (PlayerIsOnGround.isOnGround)
        //{
        //    wallJumping = false;//到地上时蹬墙跳状态结束
        //}
        
    }
    private void IsDashing()//冲刺
    {
        if(dash.canDash && Input.GetKeyDown(KeyCode.LeftShift))//按下左shift冲刺
        {
            dash.StartCoroutine(dash.Dash());
        }
        
    }
    //控制玩家的跳跃
    private void Jump()
    {
        //按住space
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround == true)
        {
            audioSource.clip = audioClips[1];
            audioSource.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed_1);
            isJumping = true;//正在跳跃
            jumpTime = 0;
            doubleJump = true;
        }
        //松开space
        if (Input.GetKeyUp(KeyCode.Space))
        {           
            isJumping = false;//跳跃结束 
            if (isOnGround)
            {
                doubleJump = false;//落地时取消可二段跳状
            }
        }
        if (isOnGround)
        {
            airJump = true;
        }
        //空跳
        if (airJump && Input.GetKeyDown(KeyCode.Space) && !isOnGround)
        {
            audioSource.clip = audioClips[2];
            audioSource.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed_2);
            isJumping = true;//正在跳跃
            jumpTime = 0;
            doubleJump = false;
            airJump = false;
        }
        //二段跳
        if (doubleJump &&!isOnGround && Input.GetKeyDown(KeyCode.Space))
        {
            audioSource.clip = audioClips[2];
            audioSource.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed_2);
            isJumping = true;//正在跳跃
            jumpTime = 0;
            doubleJump = false;
        }
        //上升
        if (isJumping)
        {
            if(jumpTime <= jumpTimeController)
            {
                rb.velocity -= new Vector2(0, Physics2D.gravity.y * Time.deltaTime * upPower);
            }
            else
            {
                isJumping = false ;
            }
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
            transform.localScale = new Vector2(-1, 1);
        }
        if(rb.velocity.x < 0)
        {
            transform.localScale = new Vector2(1, 1);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground") || collision.CompareTag("Destoryed"))
        {
            isOnGround = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground") || collision.CompareTag("Destoryed"))
        {
            isOnGround = false;
        }
    }
}
