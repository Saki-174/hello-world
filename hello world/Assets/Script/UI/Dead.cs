using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Dead : MonoBehaviour
{
    public int dead = 0;//��¼��������
    [SerializeField] private TextMeshProUGUI playerDead;//��ȡ�ı�
    private void Update()
    {
        playerDead.text = dead.ToString();//�ַ�����
    }

}
