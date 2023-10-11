using Mirror;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.UI;

public class ClientJoinServerManager : NetworkBehaviour
{
    private NetworkManager manager;

    public string NetWorkAddress = "192.168.1.18";

    public Button startButton;

    private void Start()
    {
        manager = this.GetComponent<NetworkManager>();

        startButton.onClick.AddListener(() => { this.OnJoinServer(); });
    }

    /// <summary>
    /// 开始连接服务器
    /// </summary>
    /// <param name="info"></param>
    void OnJoinServer()
    {
        manager.networkAddress = NetWorkAddress;

        Debug.Log("Start jion the Server: " + manager.networkAddress);

        manager.StartClient();
    }

}