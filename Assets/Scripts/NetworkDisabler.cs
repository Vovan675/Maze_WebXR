using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class NetworkDisabler : MonoBehaviour
{
    public PhotonView view;
    public List<Object> LocalOnly;
    public List<Object> RemoteOnly;

    void Start()
    {
        if (view.IsMine)
        {
            RemoteOnly.ForEach((obj) => Destroy(obj));
        }
        else
        {
            LocalOnly.ForEach((obj) => Destroy(obj));
        }
    }
}
