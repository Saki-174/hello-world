using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Bomb : MonoBehaviour
{
    public Transform player;//��ȡ��ɫ��transform
    public float startSpeed_x;//ը����ʼ�ٶ�
    public float startSpeed_y;//ը����ʼ�ٶ� 
    private Rigidbody2D rb;//��ȡ����
    private bool IsStuck = false;//�Ƿ��ס
    private AudioSource audioSource;
    


    // Start is called before the first frame update
    void Start()
    {   
        
        audioSource = GetComponent<AudioSource>();
        player = GameObject.Find("Player").GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-player.localScale.x * startSpeed_x, startSpeed_y);  
        audioSource.Play();
        
    }
    private void Update()
    {
        if (!IsStuck)
        {
            transform.Rotate(0, 0, Time.deltaTime * 90f, Space.Self);//��ת
        }
    }
   
    //�����ס
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
        {            
            Destroy(rb);//ȥ������ĸ���
            IsStuck = true;
        }
    }

}
