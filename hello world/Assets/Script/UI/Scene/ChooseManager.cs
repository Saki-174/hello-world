using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChooseManager : MonoBehaviour
{
    public List<Button> buttons = new List<Button>();//选关按钮列表
    public List<Image> images = new List<Image>();
    public List<List<Image>> gameObjects = new List<List<Image>>();
    private void Start()
    {
        foreach (var button in buttons) 
        {
            int index = buttons.IndexOf(button);//返回索引
            button.onClick.AddListener(()=>Click(index));//使用=>将函数包进去
        }
    }
    
    public void Click(int index)
    {
        SceneManager.LoadScene(index + 2);
    }
}
