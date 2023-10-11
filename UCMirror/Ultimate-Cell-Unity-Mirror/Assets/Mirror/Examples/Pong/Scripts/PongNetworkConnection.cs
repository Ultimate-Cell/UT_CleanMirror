using Mirror;
using Mirror.Examples.Pong;
using UnityEngine;

public class PongNetworkConnection : NetworkBehaviour
{
    NetworkManager manager;

    public NetWorkType typeInfo;

    public string Host = "192.168.1.18";

    public enum NetWorkType 
    {
        Client,
        Server,
    }
    void Awake()
    {
        manager = GetComponent<NetworkManager>();
    }

    private void Start()
    {
        if (typeInfo == NetWorkType.Client)
        {
            manager.networkAddress = Host;

            manager.StartClient();
        }
        else if (typeInfo == NetWorkType.Server) 
        {
            manager.StartServer();
        }
    }
}