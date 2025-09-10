using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausePanelManager : MonoBehaviour
{
    private bool isPause;//�Ƿ���ͣ
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

}
