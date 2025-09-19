using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChooseManager : MonoBehaviour
{
    public List<Button> buttons = new List<Button>();//选关按钮列表
    [System.Serializable]//声明一个可序列的类来生成一个可编辑的二维表
    public class Raw
    {
        public List<GameObject> images = new List<GameObject>();
    }
    //public List<List<GameObject>> gameObjects = new List<List<GameObject>>();//这样没办法在unity检查器里面直接编辑
    public List<Raw> raw = new List<Raw>();
    public PlayerData playerData;//获取存档

    private void Start()
    {      
        playerData.Load();
        ButtonAddListener();
        Level();
        Star();
    }
    //关卡解锁
    private void Level()
    {
        for (int i = 1; i < playerData.list.Count; i++)
        {
            if (playerData.list[i])
            {                
                buttons[i].GetComponent<Button>().interactable = true;
            }
            else
            {               
                buttons[i].GetComponent<Button>().interactable = false;
            }
        }
    }
    //星星个数
    private void Star()
    {
        for(int i = 0;i < playerData.ints.Count;i++)
        {
            switch (playerData.ints[i])
            {
                case 0:
                    break;
                case 1:
                    raw[i].images[0].SetActive(true);
                    break;
                case 2:
                    raw[i].images[0].SetActive(true);
                    raw[i].images[1].SetActive(true);
                    break;
                case 3:
                    raw[i].images[0].SetActive(true);
                    raw[i].images[1].SetActive(true);
                    raw[i].images[2].SetActive(true);
                    break;
                default:
                    break;
            }
        }
    }
    //按钮跳转
    private void ButtonAddListener()
    {
        foreach (var button in buttons)
        {
            int index = buttons.IndexOf(button);//返回索引
            button.onClick.AddListener(() => Click(index));//使用=>将函数包进去
        }
    }
    public void Click(int index)
    {
        SceneManager.LoadScene(index + 2);
    }
}
