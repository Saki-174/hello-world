using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScene : MonoBehaviour
{
    public PlayerData playerData;
    public GameObject gameButton;
    private void Start()
    {
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
    //��ʼ��Ϸ
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
    //�˳���Ϸ
    public void ExitGame()
    {
        Application.Quit();
    }
}
