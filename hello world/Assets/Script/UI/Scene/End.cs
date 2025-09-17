using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{
    public Score s;//��ȡ����
    public float fullScore;//����
    public List<GameObject> gameObjects = new List<GameObject>();//���ǽ���
    public static bool isVectory;//ʤ��
    public GameObject victoryPanel;//ʤ�����㶯��
    private Animator animator;//��ȡ�������
    private int index;//��ǰ�������
    public GameObject player;
    private AudioSource audioSource;
    public List<AudioClip> clipList = new List<AudioClip>();
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
            player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;//��̬���������Ҷ�
            player.GetComponent<Animator>().SetBool("IsVictory", true); 
            audioSource.clip = clipList[0];
            audioSource.Play();
            isVectory = true;
            StartCoroutine(Good());//ʹ��Э�̣�ʤ����һ�����ʤ�����           
            
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
            audioSource.clip = clipList[1];
            audioSource.Play();
        }
        yield return new WaitForSeconds(1f); 
        if (s.score > (fullScore / 3) * 2)
        {
            gameObjects[1].SetActive(true);
            gameObjects[1].GetComponent<Animator>().SetBool("Second", true);
            audioSource.clip = clipList[1];
            audioSource.Play();
        }
        yield return new WaitForSeconds(1f);
        if (s.score == fullScore)
        {
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
        index = SceneManager.GetActiveScene().buildIndex;//��ȡ��ǰ�������       
        SceneManager.LoadScene(index + 1);
        Time.timeScale = 1f;
        isVectory = false;
        player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
    }
    public void RePlay()
    {
        audioSource.Stop();
        index = SceneManager.GetActiveScene().buildIndex;//��ȡ��ǰ�������
        SceneManager.LoadScene(index);
        Time.timeScale = 1f;
        isVectory = false;
        player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
    }
    public void Exit()
    {
        Application.Quit();
    }
}
