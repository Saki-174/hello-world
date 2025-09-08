using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDead : MonoBehaviour
{
    public PlayerSaveFlie playerSaveFlie;//��ȡ�浵��
    private Rigidbody2D rb;//��ȡ������������ڿ�������״̬
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
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
        PlayerState.Instance.state = PlayerState.State.dead;//״̬�л�
        rb.bodyType = RigidbodyType2D.Static;//�ѽ�ɫת��Ϊ��̬
    }
    //��ҵĸ����
    public void Revive()
    {
        gameObject.transform.position = playerSaveFlie.trans;
        PlayerState.Instance.state = PlayerState.State.idle;//״̬�л�
        rb.bodyType = RigidbodyType2D.Dynamic;//�ѽ�ɫת��Ϊ��̬

    }
}
