using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChooseManager : MonoBehaviour
{
    public List<Button> buttons = new List<Button>();//ѡ�ذ�ť�б�
    public List<Image> images = new List<Image>();
    public List<List<Image>> gameObjects = new List<List<Image>>();
    private void Start()
    {
        foreach (var button in buttons) 
        {
            int index = buttons.IndexOf(button);//��������
            button.onClick.AddListener(()=>Click(index));//ʹ��=>����������ȥ
        }
    }
    
    public void Click(int index)
    {
        SceneManager.LoadScene(index + 2);
    }
}
