using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//磁吸炸弹投出！！
public class PlayerBomb : MonoBehaviour
{    
    public GameObject bomb;
    private float bombTime = 5f;//计时器
    private float bombCooldown = 5f;//冷却
    public GameObject playerThrowPoint;
    private AudioSource playerThrowSound;
    public AudioClip playerThrowSoundClip;
    
    [SerializeField] private Image image;//获取图片冷却
    
    private void Start()
    {
        playerThrowSound = GetComponent<AudioSource>();
        image.type = Image.Type.Filled;//确保Image类型是Filled
        image.fillAmount = 0f;
    }
    private void Update()
    {
       
        if (bombTime >= bombCooldown)
        {
            StartCoroutine(ThrowBomb());
        }
        
    }
    IEnumerator ThrowBomb()
    {
        //按下G键丢炸弹
        if (Input.GetKeyDown(KeyCode.G))
        {
            playerThrowSound.clip = playerThrowSoundClip;
            playerThrowSound.Play();
            Instantiate(bomb,playerThrowPoint.transform.position, Quaternion.identity);
            image.fillAmount = 1f;
            bombTime = 0;
            while (bombTime < bombCooldown)
            {
                bombTime += Time.deltaTime;
                image.fillAmount = Mathf.Lerp(1f, 0f, bombTime / bombCooldown);//用插值来实现动画效果
                yield return null;
            }
            image.fillAmount = 0f;
        }
    }
}    
