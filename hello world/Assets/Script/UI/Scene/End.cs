using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{
    public GameObject victoryPanel;//胜利结算动画
    private Animator animator;//获取动画组件
    private int index;//当前场景序号
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            animator.SetBool("Victory", true);
            StartCoroutine(Good());//使用协程，胜利后一秒呼出胜利面板
        }   
    }
    IEnumerator Good()
    {
        yield return new WaitForSeconds(1f);
        Victory();
    }
    public void Victory()
    {
        victoryPanel.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Next()
    {
        index = SceneManager.GetActiveScene().buildIndex;//获取当前场景序号
        SceneManager.LoadScene(index + 1);
    }
}
