using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//����ը��Ͷ������
public class PlayerBomb : MonoBehaviour
{    
    public GameObject bomb;
    private float bombTime = 0;//��ʱ��
    private float bombCooldown = 5f;//��ȴ
    public GameObject playerThrowPoint;
    private AudioSource playerThrowSound;
    public AudioClip playerThrowSoundClip;

    private void Start()
    {
        playerThrowSound = GetComponent<AudioSource>();       
    }
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
            playerThrowSound.clip = playerThrowSoundClip;
            playerThrowSound.Play();
            Instantiate(bomb,playerThrowPoint.transform.position, Quaternion.identity);
            bombTime = bombCooldown;
        }
    }
}    
