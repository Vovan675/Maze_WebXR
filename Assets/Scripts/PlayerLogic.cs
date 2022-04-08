using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using ExitGames.Client.Photon;

public class PlayerLogic : MonoBehaviour, IPunInstantiateMagicCallback
{
    public TMPro.TMP_Text nicknameText;

    private void OnEnable()
    {
        PhotonNetwork.NetworkingClient.EventReceived += OnEvent;
    }

    private void OnDisable()
    {
        PhotonNetwork.NetworkingClient.EventReceived -= OnEvent;
    }

    void OnEvent(EventData data)
    {
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void OnPhotonInstantiate(PhotonMessageInfo info)
    {
        //print("Instantiated " + GetComponent<PhotonView>().Owner.ActorNumber + "  " + info.Sender.ActorNumber);
        info.Sender.TagObject = gameObject;
        nicknameText.text = info.Sender.NickName;
    }


    [PunRPC]
    void TeleportTo(Vector3 targetPos)
    {
        transform.position = targetPos;
    }

    [PunRPC]
    void Stop()
    {
        print(GetComponent<PhotonView>().Owner.ActorNumber);
        StartCoroutine(StopRoutine());
    }

    IEnumerator StopRoutine()
    {
        GetComponent<SimpleMove>().Movable = false;
        yield return new WaitForSeconds(5);
        GetComponent<SimpleMove>().Movable = true;
    }

}
