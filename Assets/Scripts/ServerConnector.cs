using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class ServerConnector : MonoBehaviourPunCallbacks
{
    public List<Transform> SpawnPositions;
    public static string PlayerName = "Default Name";

    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinRandomOrCreateRoom();
    }

    public override void OnJoinedRoom()
    {
        int playersCount = PhotonNetwork.PlayerList.Length - 1;
        PhotonNetwork.NickName = PlayerName;
        GameObject go = PhotonNetwork.Instantiate("Player", SpawnPositions[playersCount].position, Quaternion.identity);
        PhotonNetwork.LocalPlayer.TagObject = go;
    }

}
