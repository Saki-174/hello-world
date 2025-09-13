using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//磁吸炸弹投出！！
public class PlayerBomb : MonoBehaviour
{    
    public GameObject bomb;
    private float bombTime = 0;//计时器
    private float bombCooldown = 5f;//冷却
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
        //按下G键丢炸弹
        if (Input.GetKeyDown(KeyCode.G))
        {
            playerThrowSound.clip = playerThrowSoundClip;
            playerThrowSound.Play();
            Instantiate(bomb,playerThrowPoint.transform.position, Quaternion.identity);
            bombTime = bombCooldown;
        }
    }
}    
