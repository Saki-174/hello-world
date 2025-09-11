using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public Transform player;//获取角色的transform
    public float startSpeed;//炸弹初始速度
    private float delayExplodeTime = 3f;//炸弹爆炸时间
    private BoxCollider2D BoxCollider2D;//获取碰撞体
    private Rigidbody2D rb;//获取刚体
    private Animator anim;//动画

    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        rb.velocity = new Vector2(player.localScale.x * startSpeed, startSpeed);
        StartCoroutine(Bang());//启动协程开炸
    }   
    //用协程控制定时爆炸
    IEnumerator Bang()
    {
        yield return new WaitForSeconds(delayExplodeTime);
        Explode();
    }
    private void Explode()
    {

    }

    //动画结束后播放
    public void DestroyThisBomb()
    {
        Destroy(gameObject);
    }


}
