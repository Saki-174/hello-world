using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class NetWorkLauncher : MonoBehaviourPunCallbacks
{
    public Transform trans;//复活点
    // Start is called before the first frame update
    void Start()
    {
        //使用Setting来连接服务器
        PhotonNetwork.ConnectUsingSettings();
    }
    //连接到游戏的主要服务器
    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        //加入或者创建一个房间(房间名，人数，属性)
        PhotonNetwork.JoinOrCreateRoom("Room", new Photon.Realtime.RoomOptions() { MaxPlayers = 4 }, default);
    }
    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        PhotonNetwork.Instantiate("Player",trans.position, Quaternion.identity);
    }
}
