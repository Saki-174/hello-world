using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public Transform player;//��ȡ��ɫ��transform
    public float startSpeed;//ը����ʼ�ٶ�
    private float delayExplodeTime = 3f;//ը����ըʱ��
    private BoxCollider2D BoxCollider2D;//��ȡ��ײ��
    private Rigidbody2D rb;//��ȡ����
    private Animator anim;//����

    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        rb.velocity = new Vector2(player.localScale.x * startSpeed, startSpeed);
        StartCoroutine(Bang());//����Э�̿�ը
    }   
    //��Э�̿��ƶ�ʱ��ը
    IEnumerator Bang()
    {
        yield return new WaitForSeconds(delayExplodeTime);
        Explode();
    }
    private void Explode()
    {

    }

    //���������󲥷�
    public void DestroyThisBomb()
    {
        Destroy(gameObject);
    }


}
