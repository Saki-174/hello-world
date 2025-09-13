using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDash : MonoBehaviour
{
    public bool canDash = true;//�Ƿ���Գ��
    public bool isDashing;//���ڳ��
    private float dashingPower = 24f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 3f;//��ȴ
    private int sceneIndex;//��ǰ�������
    private TrailRenderer trailRenderer;//��ȡ����Ĺ켣ģ����
    private Rigidbody2D rb;//��ȡ�������
    private AudioSource audioSource;
    public AudioClip clip;
    
    private void Update()
    {   
        audioSource = GetComponent<AudioSource>();
        //�����������Ƿ�������ȡ
        if(trailRenderer == null)
        {
            trailRenderer = GetComponent<TrailRenderer>();
            if(trailRenderer == null)return;
        }
        if(rb == null)
        {
            rb = GetComponent<Rigidbody2D>();
            if(rb == null)return ;
        }
        sceneIndex = SceneManager.GetActiveScene().buildIndex;//��ȡ��ǰ�������
        if (sceneIndex <= 1)
        {
            canDash = false;//��û����������ʱ������
        }
    }
    //Э��������public��PlayerMove�����
    public IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;//Ԥ�ȴ洢�����ʼ����
        rb.gravityScale = 0f;//���ʱ��������Ӱ��
        rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);//���
        audioSource.clip = clip;//��������
        audioSource.Play();
        trailRenderer.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        trailRenderer.emitting = false;
        rb.gravityScale = originalGravity;//�������ظ�������
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }
}
