using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
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
