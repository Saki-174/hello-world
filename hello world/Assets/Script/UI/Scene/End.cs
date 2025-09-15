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
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            animator.SetBool("Victory", true);
            player.GetComponent<Animator>().SetBool("IsVictory", true);
            isVectory = true;
            StartCoroutine(Good());//使用协程，胜利后一秒呼出胜利面板           
            
        }   
    }
    IEnumerator Good()
    {
        yield return new WaitForSeconds(1.5f);
        Victory();
        if (s.score > fullScore / 3)
        {
            gameObjects[0].SetActive(true);
            gameObjects[0].GetComponent<Animator>().SetBool("First",true);
        }
        yield return new WaitForSeconds(1f); 
        if (s.score > (fullScore / 3) * 2)
        {
            gameObjects[1].SetActive(true);
            gameObjects[1].GetComponent<Animator>().SetBool("Second", true);
        }
        yield return new WaitForSeconds(1f);
        if (s.score == fullScore)
        {
            gameObjects[2].SetActive(true);
            gameObjects[2].GetComponent<Animator>().SetBool("Third", true);
        }       
        yield return new WaitForSeconds(2f);
        Time.timeScale = 0f;
    }
    
    public void Victory()
    {
        audioSource.Play();
        victoryPanel.SetActive(true);
    }
    public void Next()
    {
        audioSource.Stop();
        index = SceneManager.GetActiveScene().buildIndex;//获取当前场景序号       
        SceneManager.LoadScene(index + 1);
        Time.timeScale = 1f;
        isVectory = false;
    }
    public void RePlay()
    {
        audioSource.Stop();
        index = SceneManager.GetActiveScene().buildIndex;//获取当前场景序号
        SceneManager.LoadScene(index);
        Time.timeScale = 1f;
        isVectory = false;
    }
    public void Exit()
    {
        Application.Quit();
    }
}
