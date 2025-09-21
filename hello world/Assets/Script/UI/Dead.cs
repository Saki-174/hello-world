using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Dead : MonoBehaviour
{
    public int dead = 0;//记录死亡次数
    [SerializeField] private TextMeshProUGUI playerDead;//获取文本
    private void Update()
    {
        playerDead.text = dead.ToString();//字符串化
    }

}
