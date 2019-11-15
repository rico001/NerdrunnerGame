using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class CustomNetworkManager : NetworkManager
{
    public Text ipAdress;

    public void StartHost()
    {
        SetPort();
        NetworkManager.singleton.StartHost();
    }

    public void StartClient()
    {
        //192.168.0.122
        Debug.Log("IP :" + ipAdress.text);
        NetworkManager.singleton.networkAddress = ipAdress.text;
        SetPort();
        NetworkManager.singleton.StartClient();
    }

    private void SetPort()
    {
        NetworkManager.singleton.networkPort = 8888;
    }

}
