using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class EndZone : MonoBehaviour
{
    public List<Transform> EndTeleports;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(gameObject);
            var players = PhotonNetwork.PlayerListOthers;
            foreach (var player in players)
            {
                PhotonView view = (player.TagObject as GameObject).GetComponent<PhotonView>();
                view.RPC("TeleportTo", RpcTarget.Others, EndTeleports[view.Owner.ActorNumber - 1].position);
            }
        }
    }
}
