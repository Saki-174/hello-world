using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
public class NetPlayerBomb : MonoBehaviourPun
{
    public GameObject bomb;
    private float bombTime = 5f;//��ʱ��
    private float bombCooldown = 5f;//��ȴ
    public GameObject playerThrowPoint;
    private AudioSource playerThrowSound;
    public AudioClip playerThrowSoundClip;

    //[SerializeField] private Image image;//��ȡͼƬ��ȴ

    private void Start()
    {
        playerThrowSound = GetComponent<AudioSource>();
        //image.type = Image.Type.Filled;//ȷ��Image������Filled
        //image.fillAmount = 0f;
    }
    private void Update()
    {
        if (!photonView.IsMine && PhotonNetwork.IsConnected) 
            return;
        if (bombTime >= bombCooldown)
        {
            StartCoroutine(ThrowBomb());
        }

    }
    IEnumerator ThrowBomb()
    {
        //����G����ը��
        if (Input.GetKeyDown(KeyCode.G))
        {
            playerThrowSound.clip = playerThrowSoundClip;
            playerThrowSound.Play();
            PhotonNetwork.Instantiate("bomb", playerThrowPoint.transform.position, Quaternion.identity);
            //image.fillAmount = 1f;
            bombTime = 0;
            while (bombTime < bombCooldown)
            {
                bombTime += Time.deltaTime;
                //image.fillAmount = Mathf.Lerp(1f, 0f, bombTime / bombCooldown);//�ò�ֵ��ʵ�ֶ���Ч��
                yield return null;
            }
            //image.fillAmount = 0f;
        }
    }
}
