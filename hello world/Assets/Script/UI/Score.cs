using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public int score = 0;//��¼����
    [SerializeField]private TextMeshProUGUI playerScore;//��ȡ�ı�
    private void Update()
    {
        playerScore.text = score.ToString();//�ַ�����
    }
}
