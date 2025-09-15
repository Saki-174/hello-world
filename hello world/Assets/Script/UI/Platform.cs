using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public Transform posa;//移动点
    public Transform posb;//移动点
    public float moveSpeed;//平台移动速度
    private Transform movePos;//临时变量
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
        //临时变量更换
        if (Vector2.Distance(transform.position, posa.position) <= 0.1f)
        {
            movePos = posb;
        }
        if (Vector2.Distance(transform.position, posb.position) <= 0.1f)
        {
            movePos = posa;
        }
        //让平台通过这个方法以一定的速度从一个位置移动到另一个位置
        transform.position = Vector2.MoveTowards(transform.position, movePos.position, moveSpeed * Time.deltaTime);
    }
    //玩家到平台上
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
