using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//����ը��Ͷ������
public class PlayerBomb : MonoBehaviour
{    
    public GameObject bomb;
    private float bombTime = 0;//��ʱ��
    private float bombCooldown = 5f;//��ȴ

    private void Update()
    {
        bombTime -= Time.deltaTime;
        if (bombTime <= 0)
        {
            ThrowBomb();
        }
        
    }
    private void ThrowBomb()
    {
        //����G����ը��
        if (Input.GetKeyDown(KeyCode.G))
        {            
            Instantiate(bomb,transform.position,Quaternion.identity);
            bombTime = bombCooldown;
        }
    }
}    
