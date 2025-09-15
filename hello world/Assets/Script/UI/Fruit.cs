using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    private bool beDestoryed;
    //�����Ե�����һ��
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (beDestoryed) { return; }
            Destroy(gameObject);     
            //�ݻ�������ټ�һ��
            Score.score += 1;
            beDestoryed = true;
        }
    }
}
