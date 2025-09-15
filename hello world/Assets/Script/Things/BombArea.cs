using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombArea : MonoBehaviour
{
    /*
    private float delayExplodeTime = 3f;//ը����ըʱ��
    private CircleCollider2D circleCollider;//��ȡ��ը��Χ
    // Start is called before the first frame update
    void Start()
    {
        circleCollider = GetComponent<CircleCollider2D>();
        circleCollider.enabled = false;
        StartCoroutine(Area());
    }
    //����֮�����ײ�伤��
    IEnumerator Area()
    {
        yield return new WaitForSeconds(delayExplodeTime);
        circleCollider.enabled = true;
    }
    //�пɴݻ������ڱ�ը��Χ��ʱ
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Destoryed"))
        {
            collision.gameObject.SetActive(false);
        }
    }
    */
    [Header("����ʱ")]
    [SerializeField] float fuseTime = 3f;

    [Header("��ը�뾶")]
    [SerializeField] float radius = 2.5f;

    [Header("Ҫ���ٵ�tag")]
    [SerializeField] string targetTag = "Destoryed";

    [Header("Ҫ���ٵ�tag")]
    [SerializeField] string myTag = "BombArea";

    [Header("��ը��ЧԤ���壨��ѡ��")]
    [SerializeField] GameObject explosionFX;

    void Start()
    {
        StartCoroutine(ExplodeAfterFuse());
    }

    IEnumerator ExplodeAfterFuse()
    {
        yield return new WaitForSeconds(fuseTime);

        // 1. ����һ������ը�����������
        GameObject detector = new GameObject("ExplosionDetector");
        detector.transform.position = transform.position;
        detector.tag = myTag;
        // 2. ����һ��Բ�δ���������С���⣬ֻҪ�뾶����
        CircleCollider2D c = detector.AddComponent<CircleCollider2D>();
        c.radius = radius;
        c.isTrigger = true;

        // 3. �����ֶ�ɨ��һ�Σ��������һ֡
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, radius);

        foreach (var hit in hits)
        {
            if (hit.CompareTag(targetTag))
            {
                Destroy(hit.gameObject);   //ը��Ŀ��
            }
           
        }

        // 4. ��ը��Ч����ѡ��
        if (explosionFX != null)
            Instantiate(explosionFX, transform.position, Quaternion.identity);

        // 5. ���ټ����
        Destroy(detector, 0.3f); //��֡����Ч
        Destroy(gameObject);
    }

    /* ���ӻ��뾶�����ڱ༭����Ч */
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
