using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class NetWorkLauncher : MonoBehaviourPunCallbacks
{
    public Transform trans;//�����
    // Start is called before the first frame update
    void Start()
    {
        //ʹ��Setting�����ӷ�����
        PhotonNetwork.ConnectUsingSettings();
    }
    //���ӵ���Ϸ����Ҫ������
    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        //������ߴ���һ������(������������������)
        PhotonNetwork.JoinOrCreateRoom("Room", new Photon.Realtime.RoomOptions() { MaxPlayers = 4 }, default);
    }
    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        PhotonNetwork.Instantiate("Player",trans.position, Quaternion.identity);
    }
}
