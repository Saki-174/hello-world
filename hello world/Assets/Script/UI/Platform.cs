using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public Transform posa;//�ƶ���
    public Transform posb;//�ƶ���
    public float moveSpeed;//ƽ̨�ƶ��ٶ�
    private Transform movePos;//��ʱ����
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        movePos = posa;
    }

    // Update is called once per frame
    void Update()
    {
        PlatformMove();
    }

    private void PlatformMove()
    {
        //��ʱ��������
        if (Vector2.Distance(transform.position, posa.position) <= 0.1f)
        {
            movePos = posb;
        }
        if (Vector2.Distance(transform.position, posb.position) <= 0.1f)
        {
            movePos = posa;
        }
        //��ƽ̨ͨ�����������һ�����ٶȴ�һ��λ���ƶ�����һ��λ��
        transform.position = Vector2.MoveTowards(transform.position, movePos.position, moveSpeed * Time.deltaTime);
    }
    //��ҵ�ƽ̨��
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {   
            collision.transform.parent = this.transform;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.parent = null;         
        }
    }
}
