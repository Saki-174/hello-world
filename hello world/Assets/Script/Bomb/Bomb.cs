using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Bomb : MonoBehaviour
{
    public Transform player;//获取角色的transform
    public float startSpeed_x;//炸弹初始速度
    public float startSpeed_y;//炸弹初始速度 
    private Rigidbody2D rb;//获取刚体
    private bool IsStuck = false;//是否黏住
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
            transform.Rotate(0, 0, Time.deltaTime * 90f, Space.Self);//自转
        }
    }
   
    //碰到黏住
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
        {            
            Destroy(rb);//去掉物体的刚体
            IsStuck = true;
        }
    }

}
