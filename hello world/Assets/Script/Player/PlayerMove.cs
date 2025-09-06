using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    /// <summary>
    /// ��ҵĻ����ƶ�
    /// </summary>
    private Rigidbody2D rb;//ͨ�������������ƶ�
    [SerializeField] private float moveSpeed;//�����ƶ��ٶ�
    [SerializeField] private float jumpSpeed;//��Ծ�ٶ�
    private float moveController;//����unity�ṩԤ�跽ʽ�ƶ�
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    //������ҵ��ƶ�������AD��
    public void Move()
    {
        moveController = Input.GetAxisRaw("Horizontal");//ˮƽ��������
        rb.velocity = new Vector2(moveSpeed * moveController, rb.velocity.y);
        if (Input.GetKey(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x,jumpSpeed);
        }

    }
}
