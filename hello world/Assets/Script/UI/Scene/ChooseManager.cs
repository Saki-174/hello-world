using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChooseManager : MonoBehaviour
{
    public List<Button> buttons = new List<Button>();//ѡ�ذ�ť�б�
    [System.Serializable]//����һ�������е���������һ���ɱ༭�Ķ�ά��
    public class Raw
    {
        public List<GameObject> images = new List<GameObject>();
    }
    //public List<List<GameObject>> gameObjects = new List<List<GameObject>>();//����û�취��unity���������ֱ�ӱ༭
    public List<Raw> raw = new List<Raw>();
    public PlayerData playerData;//��ȡ�浵

    private void Start()
    {      
        playerData.Load();
        ButtonAddListener();
        Level();
        Star();
    }
    //�ؿ�����
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
    //���Ǹ���
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
    //��ť��ת
    private void ButtonAddListener()
    {
        foreach (var button in buttons)
        {
            int index = buttons.IndexOf(button);//��������
            button.onClick.AddListener(() => Click(index));//ʹ��=>����������ȥ
        }
    }
    public void Click(int index)
    {
        SceneManager.LoadScene(index + 2);
    }
}
