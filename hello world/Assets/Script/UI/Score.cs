using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public int score = 0;//记录分数
    [SerializeField]private TextMeshProUGUI playerScore;//获取文本
    private void Update()
    {
        playerScore.text = score.ToString();//字符串化
    }
}
