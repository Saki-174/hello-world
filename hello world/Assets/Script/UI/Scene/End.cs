using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{
    public Score s;//获取分数
    public float fullScore;//满分
    public List<GameObject> gameObjects = new List<GameObject>();//星星结算
    public static bool isVectory;//胜利
    public GameObject victoryPanel;//胜利结算动画
    private Animator animator;//获取动画组件
    private int index;//当前场景序号
    public GameObject player;
    private AudioSource audioSource;
    public List<AudioClip> clipList = new List<AudioClip>();
    public PlayerData playerData; 
    // Start is called before the first frame update
    void Start()
    {       
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        index = SceneManager.GetActiveScene().buildIndex;//获取当前场景序号
        Debug.Log(index);
    }

    // Update is called once per frame
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            animator.SetBool("Victory", true);
            player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;//静态，不让他乱动
            player.GetComponent<Animator>().SetBool("IsVictory", true); 
            audioSource.clip = clipList[0];
            audioSource.Play();
            isVectory = true;
            if (index < 4)
            {
                playerData.list[index - 1] = true;//存入数据已经通关
            }
            StartCoroutine(Good());//使用协程，胜利后一秒呼出胜利面板           
            
        }   
    }
    IEnumerator Good()
    {
        yield return new WaitForSeconds(1.5f);
        Victory();
        if (s.score > fullScore / 3)
        {
            playerData.ints[index - 2] = 1;
            gameObjects[0].SetActive(true);
            gameObjects[0].GetComponent<Animator>().SetBool("First",true);
            audioSource.clip = clipList[1];
            audioSource.Play();
        }
        yield return new WaitForSeconds(1f); 
        if (s.score > (fullScore / 3) * 2)
        {
            playerData.ints[index - 2] = 2;
            gameObjects[1].SetActive(true);
            gameObjects[1].GetComponent<Animator>().SetBool("Second", true);
            audioSource.clip = clipList[1];
            audioSource.Play();
        }
        yield return new WaitForSeconds(1f);
        if (s.score == fullScore)
        {
            playerData.ints[index - 2] = 3;
            gameObjects[2].SetActive(true);
            gameObjects[2].GetComponent<Animator>().SetBool("Third", true);
            audioSource.clip = clipList[1];
            audioSource.Play();
        }       
        yield return new WaitForSeconds(2f);
        Time.timeScale = 0f;
    }
    
    public void Victory()
    {        
        victoryPanel.SetActive(true);
    }
    public void Next()
    {
        audioSource.Stop();       
        SceneManager.LoadScene(index + 1);
        Time.timeScale = 1f;
        isVectory = false;
        player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        playerData.Save();
    }
    public void RePlay()
    {
        audioSource.Stop();        
        SceneManager.LoadScene(index);
        Time.timeScale = 1f;
        isVectory = false;
        player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        playerData.Save();
    }
    public void Exit()
    {
        Application.Quit();
        playerData.Save();
    }
    public void BackToMenu()
    {
        audioSource.Stop();
        Time.timeScale = 1f;
        isVectory = false;
        player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        playerData.Save();
        SceneManager.LoadScene(0);
    }
}
