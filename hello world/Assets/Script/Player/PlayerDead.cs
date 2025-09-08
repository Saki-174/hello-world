using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDead : MonoBehaviour
{
    public PlayerSaveFlie playerSaveFlie;//获取存档点
    private Rigidbody2D rb;//获取刚体组件，用于控制物体状态
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //碰到陷阱
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Trap"))
        {           
            Dead();
            //Todo:动画之后放Revive事件
            Revive();
        }
    }
    //玩家的死亡函数
    public void Dead()
    {
        PlayerState.Instance.state = PlayerState.State.dead;//状态切换
        rb.bodyType = RigidbodyType2D.Static;//把角色转换为静态
    }
    //玩家的复活函数
    public void Revive()
    {
        gameObject.transform.position = playerSaveFlie.trans;
        PlayerState.Instance.state = PlayerState.State.idle;//状态切换
        rb.bodyType = RigidbodyType2D.Dynamic;//把角色转换为动态

    }
}
