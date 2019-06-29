using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ServerManager : Photon.PunBehaviour
{
    bool isConnected;

    void Start() { PhotonNetwork.ConnectUsingSettings("");  }

    override public void OnConnectedToMaster() { isConnected = true; }

    void Update()
    {
        if (isConnected)
            SceneManager.LoadScene("StartMenu");
    }
}
