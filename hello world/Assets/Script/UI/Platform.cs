using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public Transform pos;//移动点
    public float moveSpeed;//平台移动速度
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //让平台通过这个方法以一定的速度从一个位置移动到另一个位置
        transform.position = Vector2.MoveTowards(transform.position, pos.position, moveSpeed * Time.deltaTime);
    }
}
