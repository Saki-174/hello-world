using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public Transform pos;//�ƶ���
    public float moveSpeed;//ƽ̨�ƶ��ٶ�
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //��ƽ̨ͨ�����������һ�����ٶȴ�һ��λ���ƶ�����һ��λ��
        transform.position = Vector2.MoveTowards(transform.position, pos.position, moveSpeed * Time.deltaTime);
    }
}
