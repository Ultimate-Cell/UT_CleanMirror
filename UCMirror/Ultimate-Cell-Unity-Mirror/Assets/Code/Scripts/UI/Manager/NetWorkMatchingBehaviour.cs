using Mirror;
using UnityEngine;
using UnityEngine.UI;

public class NetWorkMatchingBehaviour : MonoBehaviour
{
    public NetworkManager manager;

    public MessageBehavior message;

    public string NetWorkAddress = "localhost";

    public GameObject LoadingPage;

    public ConnType connInfo;

    public enum ConnType 
    {
        Server,
        Client,
    }

    private void Start()
    {
        if (connInfo == ConnType.Server)
        {
            LoadingPage.SetActive(false);

            manager.StartServer();
        }
    }

    /// <summary>
    /// 开始连接服务器
    /// </summary>
    /// <param name="info"></param>
    public void OnJoinServer()
    {
        manager.networkAddress = NetWorkAddress;

        Debug.Log("Start jion the Server: " + manager.networkAddress);

        manager.StartClient();
    }

}