using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class NetworkLauncher : MonoBehaviourPunCallbacks
{
    public Transform spawnPoint; // 玩家复活点
    public GameObject uiPanel; // UI面板
    public Text statusText; // 状态文本
    public Text playerListText; // 玩家列表文本

    //private List<string> playerNames = new List<string>();

    void Start()
    {
        // 初始化UI
        uiPanel.SetActive(true);
        UpdateStatusText("连接到服务器...");

        // 连接到Photon服务器
        PhotonNetwork.ConnectUsingSettings();
        // 设置玩家名称（可以从输入框获取，这里用默认值）
        PhotonNetwork.NickName = "Player" + Random.Range(1000, 9999);
    }

    // 连接到主服务器回调
    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        UpdateStatusText("已连接到服务器，正在加入或创建房间...");
        // 加入或创建房间
        PhotonNetwork.JoinOrCreateRoom("MainRoom",
            new RoomOptions() { MaxPlayers = 4, PublishUserId = true },
            TypedLobby.Default);
    }

    // 加入房间回调
    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        UpdateStatusText($"已加入房间: {PhotonNetwork.CurrentRoom.Name}");

        // 实例化玩家
        PhotonNetwork.Instantiate("Player", spawnPoint.position, Quaternion.identity);

        // 更新玩家列表
        UpdatePlayerList();

        // 通知所有玩家有新玩家加入
        photonView.RPC("RPC_PlayerJoined", RpcTarget.All, PhotonNetwork.NickName);
    }

    // 玩家加入房间回调
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        base.OnPlayerEnteredRoom(newPlayer);
        UpdatePlayerList();
    }

    // 玩家离开房间回调
    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        base.OnPlayerLeftRoom(otherPlayer);
        UpdatePlayerList();
        // 通知所有玩家有玩家离开
        photonView.RPC("RPC_PlayerLeft", RpcTarget.All, otherPlayer.NickName);
    }

    // 断开连接回调
    public override void OnDisconnected(DisconnectCause cause)
    {
        base.OnDisconnected(cause);
        UpdateStatusText($"已断开连接: {cause}");
    }

    // 更新玩家列表
    private void UpdatePlayerList()
    {
        playerListText.text = "玩家列表:\n";
        foreach (var player in PhotonNetwork.PlayerList)
        {
            playerListText.text += $"- {player.NickName}\n";
        }
    }

    // 更新状态文本
    private void UpdateStatusText(string message)
    {
        statusText.text = message;
        Debug.Log(message);
    }

    // 离开房间
    public void LeaveRoom()
    {
        if (PhotonNetwork.InRoom)
        {
            PhotonNetwork.LeaveRoom();
            UpdateStatusText("正在离开房间...");
        }
        else
        {
            PhotonNetwork.Disconnect();
            UpdateStatusText("正在断开连接...");
        }
    }

    // 重新连接
    public void Reconnect()
    {
        UpdateStatusText("重新连接到服务器...");
        PhotonNetwork.ConnectUsingSettings();
    }

    // RPC：通知玩家加入
    [PunRPC]
    private void RPC_PlayerJoined(string playerName)
    {
        UpdateStatusText($"{playerName} 加入了游戏!");
    }

    // RPC：通知玩家离开
    [PunRPC]
    private void RPC_PlayerLeft(string playerName)
    {
        UpdateStatusText($"{playerName} 离开了游戏!");
    }
}