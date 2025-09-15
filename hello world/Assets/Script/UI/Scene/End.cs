using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{
    public static bool isVectory;//ʤ��
    public GameObject victoryPanel;//ʤ�����㶯��
    private Animator animator;//��ȡ�������
    private int index;//��ǰ�������
    public GameObject player;
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
            player.GetComponent<Animator>().SetBool("IsVictory", true);
            isVectory = true;
            StartCoroutine(Good());//ʹ��Э�̣�ʤ����һ�����ʤ�����
        }   
    }
    IEnumerator Good()
    {
        yield return new WaitForSeconds(1.5f);
        Victory();
    }
    public void Victory()
    {
        victoryPanel.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Next()
    {
        index = SceneManager.GetActiveScene().buildIndex;//��ȡ��ǰ�������       
        SceneManager.LoadScene(index + 1);
        Time.timeScale = 1f;
        isVectory = false;
    }
}
