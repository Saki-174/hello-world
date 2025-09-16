using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public Score s;
    private bool beDestoryed = false;
    public AudioSource audioSource;
    //�����Ե�����һ��   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (beDestoryed) { return; }
            audioSource.Play();
            Destroy(gameObject);              
            //�ݻ�������ټ�һ��
            s.score += 1;
            beDestoryed = true;           
        }
    }
}
