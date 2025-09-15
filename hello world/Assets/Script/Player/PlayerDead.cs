using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class PlayerDead : MonoBehaviour
{    
    private Rigidbody2D rb;//获取刚体组件，用于控制物体状态
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

    //碰到陷阱
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Trap") || collision.CompareTag("BombArea"))
        {           
            Dead();           
        }
    }
    //玩家的死亡函数
    public void Dead()
    {   
        audioSource.clip = audioClip;
        if (!audioSource.isPlaying)
        {
            
            audioSource.Play();
        }
        rb.bodyType = RigidbodyType2D.Static;//把角色转换为静态
        animator.SetBool("IsDead",true);
    }
    //玩家的复活函数
    public void Revive()
    {
        audioSource.Stop();
        animator.SetBool("IsDead", false);
        gameObject.transform.position = PlayerSaveFlie.trans;       
        rb.bodyType = RigidbodyType2D.Dynamic;//把角色转换为动态
    }
}
