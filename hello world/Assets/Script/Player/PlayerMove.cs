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
    [SerializeField] private float jumpSpeed;//��Ծ�ٶ�    
    private float moveController;//����unity�ṩԤ�跽ʽ�ƶ�
    private bool isOnGround;//�����ڵ�����
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
    //������ҵ��ƶ�������AD��
    public void Move()
    {
        moveController = Input.GetAxisRaw("Horizontal");//ˮƽ��������
        rb.velocity = new Vector2(moveSpeed * moveController, rb.velocity.y);
        if (Input.GetKey(KeyCode.Space) && isOnGround == true )
        {
            rb.velocity = new Vector2(rb.velocity.x,jumpSpeed);
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
