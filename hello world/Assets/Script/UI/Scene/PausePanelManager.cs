using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausePanelManager : MonoBehaviour
{
    public static bool isPause;//�Ƿ���ͣ
    public GameObject pausePanel;//��ͣ�����ȡ
    // Update is called once per frame
    void Update()
    {
        Pause();
    }
    public void Pause()
    {
        if (Input.GetKeyDown(KeyCode.Escape)&& !End.isVectory)
        {
            //����Escape����û��ʤ������
            if(isPause == false)
            {
                pausePanel.SetActive(true);
                Time.timeScale = 0;
                isPause = true;
            }
            else
            {
                pausePanel.SetActive(false);
                Time.timeScale = 1;
                isPause = false;
            }
        }
        
    }
    public void Exit()
    {
        Application.Quit();
    }
    
    public void Replay()
    {
        int index = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(index);
        Time.timeScale = 1;
        isPause = false;
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
        isPause = false;
    }
}
