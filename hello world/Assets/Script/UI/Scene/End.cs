using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{
    public GameObject victoryPanel;//ʤ�����㶯��
    private Animator animator;//��ȡ�������
    private int index;//��ǰ�������
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
            StartCoroutine(Good());//ʹ��Э�̣�ʤ����һ�����ʤ�����
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
        index = SceneManager.GetActiveScene().buildIndex;//��ȡ��ǰ�������
        SceneManager.LoadScene(index + 1);
    }
}
