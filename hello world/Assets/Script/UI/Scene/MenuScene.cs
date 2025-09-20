using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScene : MonoBehaviour
{
    public PlayerData playerData;
    public GameObject gameButton;
    public GameObject panel_1;
    public GameObject panel_2;
    private void Start()
    {
        panel_2.SetActive(true);
        panel_1.SetActive(false);
        
    }
    //开始游戏
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
    //退出游戏
    public void ExitGame()
    {
        Application.Quit();
    }
    public void Single()
    {
        panel_2.SetActive(false);
        panel_1.SetActive(true);
        playerData.Load();
        if(playerData.haveData == false)
        {
            gameButton.SetActive(false);
        }
        else
        {
            gameButton.SetActive(true);
        }
    }
    public void Many()
    {
        SceneManager.LoadScene(5);
    }
    public void Back()
    {
        panel_1.SetActive(false);
        panel_2.SetActive(true);
    }
}
