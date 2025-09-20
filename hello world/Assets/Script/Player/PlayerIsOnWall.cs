using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIsOnWall : MonoBehaviour
{
    //�жϽ�ɫ�Ƿ���ǽ��
    public bool isOnWall;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall"))
        {
            isOnWall = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall"))
        {
            isOnWall = false;
        }
    }
}
