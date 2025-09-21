using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerDash : MonoBehaviour
{
    public bool canDash = true;//是否可以冲刺
    public bool isDashing;//正在冲刺
    private float dashingPower = 24f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 3f;//冷却
    private int sceneIndex;//当前场景序号
    private TrailRenderer trailRenderer;//获取物体的轨迹模拟器
    private Rigidbody2D rb;//获取刚体组件
    private AudioSource audioSource;
    public AudioClip clip;
    [SerializeField]private Image image;//获取图片冷却
    [SerializeField]private float time = 0f;//计时器

    private void Start()
    {
        if (image != null)
        {
            image.type = Image.Type.Filled;//确保Image类型是Filled
            image.fillAmount = 0f;
        }     
        audioSource = GetComponent<AudioSource>();
        sceneIndex = SceneManager.GetActiveScene().buildIndex;//获取当前场景序号
    }
    private void Update()
    {   
        
        //检查两个组件是否被正常获取
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

            canDash = false;//还没解锁喷气的时候不能用
        }
        
    }
    //协程声明成public在PlayerMove里调用
    public IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;//预先存储人物初始重力
        rb.gravityScale = 0f;//冲刺时不受重力影响
        rb.velocity = new Vector2(-transform.localScale.x * dashingPower, 0f);//冲刺
        audioSource.clip = clip;//喷气音乐
        audioSource.Play();
        trailRenderer.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        time = 0f;//计时器归零
        image.fillAmount = 1f;
        trailRenderer.emitting = false;
        rb.gravityScale = originalGravity;//给人物重赋予重力
        isDashing = false;
        while(time < dashingCooldown)
        {
            time += Time.deltaTime;
            image.fillAmount = Mathf.Lerp(1f, 0f, time / dashingCooldown);//用插值来实现动画效果
            yield return null;//令其每帧执行一次，而不是瞬间完成迭代
        }
        image.fillAmount = 0f;
        //yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }
    public void FillImage(Image image)
    {

    }
}
