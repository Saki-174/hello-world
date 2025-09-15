using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDead : MonoBehaviour
{    
    private Rigidbody2D rb;//��ȡ������������ڿ�������״̬
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    //��������
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Trap") || collision.CompareTag("BombArea"))
        {           
            Dead();           
        }
    }
    //��ҵ���������
    public void Dead()
    {        
        rb.bodyType = RigidbodyType2D.Static;//�ѽ�ɫת��Ϊ��̬
        animator.SetBool("IsDead",true);
    }
    //��ҵĸ����
    public void Revive()
    {
        animator.SetBool("IsDead", false);
        gameObject.transform.position = PlayerSaveFlie.trans;       
        rb.bodyType = RigidbodyType2D.Dynamic;//�ѽ�ɫת��Ϊ��̬
    }
}
