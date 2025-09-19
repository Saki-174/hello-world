using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausePanelManager : MonoBehaviour
{
    public static bool isPause;//是否暂停
    public GameObject pausePanel;//暂停界面获取
    // Update is called once per frame
    void Update()
    {
        Pause();
    }
    public void Pause()
    {
        if (Input.GetKeyDown(KeyCode.Escape)&& !End.isVectory)
        {
            //按下Escape而且没有胜利结算
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
