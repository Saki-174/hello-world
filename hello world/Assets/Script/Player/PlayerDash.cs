using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    
    private void Update()
    {   
        audioSource = GetComponent<AudioSource>();
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
        sceneIndex = SceneManager.GetActiveScene().buildIndex;//获取当前场景序号
        if (sceneIndex <= 1)
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
        rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);//冲刺
        audioSource.clip = clip;//喷气音乐
        audioSource.Play();
        trailRenderer.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        trailRenderer.emitting = false;
        rb.gravityScale = originalGravity;//给人物重赋予重力
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }
}
