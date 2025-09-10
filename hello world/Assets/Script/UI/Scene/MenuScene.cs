using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScene : MonoBehaviour
{
    
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
}
