using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombArea : MonoBehaviour
{
    /*
    private float delayExplodeTime = 3f;//炸弹爆炸时间
    private CircleCollider2D circleCollider;//获取爆炸范围
    // Start is called before the first frame update
    void Start()
    {
        circleCollider = GetComponent<CircleCollider2D>();
        circleCollider.enabled = false;
        StartCoroutine(Area());
    }
    //三秒之后把碰撞箱激活
    IEnumerator Area()
    {
        yield return new WaitForSeconds(delayExplodeTime);
        circleCollider.enabled = true;
    }
    //有可摧毁物体在爆炸范围内时
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Destoryed"))
        {
            collision.gameObject.SetActive(false);
        }
    }
    */
    [Header("倒计时")]
    [SerializeField] float fuseTime = 3f;

    [Header("爆炸半径")]
    [SerializeField] float radius = 2.5f;

    [Header("要销毁的tag")]
    [SerializeField] string targetTag = "Destoryed";

    [Header("要销毁的tag")]
    [SerializeField] string myTag = "BombArea";

    [Header("爆炸特效预制体（可选）")]
    [SerializeField] GameObject explosionFX;

    void Start()
    {
        StartCoroutine(ExplodeAfterFuse());
    }

    IEnumerator ExplodeAfterFuse()
    {
        yield return new WaitForSeconds(fuseTime);

        // 1. 生成一个“爆炸检测器”物体
        GameObject detector = new GameObject("ExplosionDetector");
        detector.transform.position = transform.position;
        detector.tag = myTag;
        // 2. 给它一个圆形触发器（大小随意，只要半径够）
        CircleCollider2D c = detector.AddComponent<CircleCollider2D>();
        c.radius = radius;
        c.isTrigger = true;

        // 3. 立即手动扫描一次，避免等下一帧
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, radius);

        foreach (var hit in hits)
        {
            if (hit.CompareTag(targetTag))
            {
                Destroy(hit.gameObject);   //炸掉目标
            }
           
        }

        // 4. 爆炸特效（可选）
        if (explosionFX != null)
            Instantiate(explosionFX, transform.position, Quaternion.identity);

        // 5. 销毁检测器
        Destroy(detector, 0.3f); //留帧给特效
        Destroy(gameObject);
    }

    /* 可视化半径，仅在编辑器有效 */
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
