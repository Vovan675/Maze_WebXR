using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (other.GetComponent<PhotonView>().IsMine)
            {
                PhotonNetwork.Destroy(gameObject);
                var players = PhotonNetwork.PlayerListOthers;
                foreach (var player in players)
                {
                    PhotonView view = (player.TagObject as GameObject).GetComponent<PhotonView>();
                    view.RPC("Stop", view.Owner);
                }
            }
        }
    }
}
