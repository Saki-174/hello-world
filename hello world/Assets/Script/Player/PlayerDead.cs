using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class PlayerDead : MonoBehaviour
{    
    private Rigidbody2D rb;//��ȡ������������ڿ�������״̬
    private Animator animator;
    private AudioSource audioSource;
    public AudioClip audioClip;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
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
        audioSource.clip = audioClip;
        if (!audioSource.isPlaying)
        {
            
            audioSource.Play();
        }
        rb.bodyType = RigidbodyType2D.Static;//�ѽ�ɫת��Ϊ��̬
        animator.SetBool("IsDead",true);
    }
    //��ҵĸ����
    public void Revive()
    {
        audioSource.Stop();
        animator.SetBool("IsDead", false);
        gameObject.transform.position = PlayerSaveFlie.trans;       
        rb.bodyType = RigidbodyType2D.Dynamic;//�ѽ�ɫת��Ϊ��̬
    }
}
