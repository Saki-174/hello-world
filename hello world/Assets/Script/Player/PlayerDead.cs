using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDead : MonoBehaviour
{    
    private Rigidbody2D rb;//��ȡ������������ڿ�������״̬
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    //��������
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Trap"))
        {           
            Dead();
            //Todo:����֮���Revive�¼�
            Revive();
        }
    }
    //��ҵ���������
    public void Dead()
    {        
        rb.bodyType = RigidbodyType2D.Static;//�ѽ�ɫת��Ϊ��̬
    }
    //��ҵĸ����
    public void Revive()
    {
        gameObject.transform.position = PlayerSaveFlie.trans;       
        rb.bodyType = RigidbodyType2D.Dynamic;//�ѽ�ɫת��Ϊ��̬
    }
}
