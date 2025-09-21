using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
    [SerializeField]private Image image;//��ȡͼƬ��ȴ
    [SerializeField]private float time = 0f;//��ʱ��

    private void Start()
    {
        if (image != null)
        {
            image.type = Image.Type.Filled;//ȷ��Image������Filled
            image.fillAmount = 0f;
        }     
        audioSource = GetComponent<AudioSource>();
        sceneIndex = SceneManager.GetActiveScene().buildIndex;//��ȡ��ǰ�������
    }
    private void Update()
    {   
        
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
       
        if (sceneIndex <= 2)
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
        rb.velocity = new Vector2(-transform.localScale.x * dashingPower, 0f);//���
        audioSource.clip = clip;//��������
        audioSource.Play();
        trailRenderer.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        time = 0f;//��ʱ������
        image.fillAmount = 1f;
        trailRenderer.emitting = false;
        rb.gravityScale = originalGravity;//�������ظ�������
        isDashing = false;
        while(time < dashingCooldown)
        {
            time += Time.deltaTime;
            image.fillAmount = Mathf.Lerp(1f, 0f, time / dashingCooldown);//�ò�ֵ��ʵ�ֶ���Ч��
            yield return null;//����ÿִ֡��һ�Σ�������˲����ɵ���
        }
        image.fillAmount = 0f;
        //yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }
    public void FillImage(Image image)
    {

    }
}
