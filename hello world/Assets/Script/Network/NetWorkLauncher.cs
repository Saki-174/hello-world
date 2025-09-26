using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class NetworkLauncher : MonoBehaviourPunCallbacks
{
    public Transform spawnPoint; // ��Ҹ����
    public GameObject uiPanel; // UI���
    public Text statusText; // ״̬�ı�
    public Text playerListText; // ����б��ı�

    //private List<string> playerNames = new List<string>();

    void Start()
    {
        // ��ʼ��UI
        uiPanel.SetActive(true);
        UpdateStatusText("���ӵ�������...");

        // ���ӵ�Photon������
        PhotonNetwork.ConnectUsingSettings();
        // ����������ƣ����Դ�������ȡ��������Ĭ��ֵ��
        PhotonNetwork.NickName = "Player" + Random.Range(1000, 9999);
    }

    // ���ӵ����������ص�
    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        UpdateStatusText("�����ӵ������������ڼ���򴴽�����...");
        // ����򴴽�����
        PhotonNetwork.JoinOrCreateRoom("MainRoom",
            new RoomOptions() { MaxPlayers = 4, PublishUserId = true },
            TypedLobby.Default);
    }

    // ���뷿��ص�
    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        UpdateStatusText($"�Ѽ��뷿��: {PhotonNetwork.CurrentRoom.Name}");

        // ʵ�������
        PhotonNetwork.Instantiate("Player", spawnPoint.position, Quaternion.identity);

        // ��������б�
        UpdatePlayerList();

        // ֪ͨ�������������Ҽ���
        photonView.RPC("RPC_PlayerJoined", RpcTarget.All, PhotonNetwork.NickName);
    }

    // ��Ҽ��뷿��ص�
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        base.OnPlayerEnteredRoom(newPlayer);
        UpdatePlayerList();
    }

    // ����뿪����ص�
    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        base.OnPlayerLeftRoom(otherPlayer);
        UpdatePlayerList();
        // ֪ͨ�������������뿪
        photonView.RPC("RPC_PlayerLeft", RpcTarget.All, otherPlayer.NickName);
    }

    // �Ͽ����ӻص�
    public override void OnDisconnected(DisconnectCause cause)
    {
        base.OnDisconnected(cause);
        UpdateStatusText($"�ѶϿ�����: {cause}");
    }

    // ��������б�
    private void UpdatePlayerList()
    {
        playerListText.text = "����б�:\n";
        foreach (var player in PhotonNetwork.PlayerList)
        {
            playerListText.text += $"- {player.NickName}\n";
        }
    }

    // ����״̬�ı�
    private void UpdateStatusText(string message)
    {
        statusText.text = message;
        Debug.Log(message);
    }

    // �뿪����
    public void LeaveRoom()
    {
        if (PhotonNetwork.InRoom)
        {
            PhotonNetwork.LeaveRoom();
            UpdateStatusText("�����뿪����...");
        }
        else
        {
            PhotonNetwork.Disconnect();
            UpdateStatusText("���ڶϿ�����...");
        }
    }

    // ��������
    public void Reconnect()
    {
        UpdateStatusText("�������ӵ�������...");
        PhotonNetwork.ConnectUsingSettings();
    }

    // RPC��֪ͨ��Ҽ���
    [PunRPC]
    private void RPC_PlayerJoined(string playerName)
    {
        UpdateStatusText($"{playerName} ��������Ϸ!");
    }

    // RPC��֪ͨ����뿪
    [PunRPC]
    private void RPC_PlayerLeft(string playerName)
    {
        UpdateStatusText($"{playerName} �뿪����Ϸ!");
    }
}