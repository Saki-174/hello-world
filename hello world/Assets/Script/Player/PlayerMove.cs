using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMove : MonoBehaviour
{
    /// <summary>
    /// ��ҵĻ����ƶ�
    /// </summary>
    private Rigidbody2D rb;//ͨ�������������ƶ�
    [SerializeField] private float moveSpeed;//�����ƶ��ٶ�
    [SerializeField] private float jumpSpeed_1;//��Ծ�ٶ�
    [SerializeField] private float jumpSpeed_2;//������Ծ�ٶ�
    [SerializeField] private float jumpTimeController;//������Ծ�������ʱ��
    [SerializeField] private float upPower;//������Ծ�������ʱ��
    [SerializeField] private float downPower;//������Ծ�������ʱ��
    [SerializeField] private float wallJumpSpeed;//��ǽ�������ٶ�
    [SerializeField] private bool wallJumping = false;//��ǽ���������
    private float jumpTime;//��Ծ����ʱ��                                             
    private float moveController;//�洢����unity�ṩ��Ԥ�跽ʽ�ƶ�    
    private bool isJumping;//�����Ƿ�������Ծ��������Ծ�������ƺͶ�����
    private bool doubleJump;//������
    private PlayerDash dash;//��ȡ�����ű�
    private AudioSource audioSource;
    public List<AudioClip> audioClips = new List<AudioClip>();//�����б�
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        dash = GetComponent<PlayerDash>();
    }

    // Update is called once per frame
    void Update()
    {
        if (dash.isDashing)
        {
            return;//������ʱ��ɶҲ�ɲ���
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
    //������ҵ��ƶ�������AD��
    public void Move()
    {
        moveController = Input.GetAxisRaw("Horizontal");//ˮƽ��������
        
        rb.velocity = new Vector2(moveSpeed * moveController, rb.velocity.y);        
    }
    //Э�̿��ƶ��ݵ���Ҳ��ɿ���״̬
    IEnumerator WallJumping()
    {
        wallJumping = true;
        yield return new WaitForSeconds(0.15f);//�ȴ�0.15�����Կ�������ƶ�����ǽ��������
        wallJumping = false;
    }
    //���������ǽ�ϵ���Ծ
    private void WallJump()
    {
        if (PlayerIsOnWall.isOnWall && ! PlayerIsOnGround.isOnGround)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.8f);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //wallJumping = true;//����Ϊ���ڵ�ǽ��
                rb.velocity = new Vector2(-wallJumpSpeed * transform.localScale.x, wallJumpSpeed);
                doubleJump = true;//����������
                
                StartCoroutine(WallJumping());//����Э��
            }
        }
        //if (PlayerIsOnGround.isOnGround)
        //{
        //    wallJumping = false;//������ʱ��ǽ��״̬����
        //}
        
    }
    private void IsDashing()//���
    {
        if(dash.canDash && Input.GetKeyDown(KeyCode.LeftShift))//������shift���
        {
            dash.StartCoroutine(dash.Dash());
        }
        
    }
    //������ҵ���Ծ
    private void Jump()
    {
        //��סspace
        if (Input.GetKeyDown(KeyCode.Space) && PlayerIsOnGround.isOnGround == true)
        {
            
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed_1);
            isJumping = true;//������Ծ
            jumpTime = 0;
            doubleJump = true;
        }
        //�ɿ�space
        if (Input.GetKeyUp(KeyCode.Space))
        {
           
            isJumping = false;//��Ծ���� 
        }
        //������
        if(doubleJump &&!PlayerIsOnGround.isOnGround && Input.GetKeyDown(KeyCode.Space))
        {
            
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed_2);
            isJumping = true;//������Ծ
            jumpTime = 0;
            doubleJump = false;
        }
        //����
        if (isJumping)
        {
            if(jumpTime <= jumpTimeController)
                rb.velocity -= new Vector2(0, Physics2D.gravity.y * Time.deltaTime * upPower);
            else
                isJumping = false ;
            jumpTime += Time.deltaTime;
        }
        
        //����
        if (!isJumping)
        {
            rb.velocity += new Vector2(0, Physics2D.gravity.y * Time.deltaTime * downPower);
        }
    }

    //�������ͼ��ת��
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
    
}
