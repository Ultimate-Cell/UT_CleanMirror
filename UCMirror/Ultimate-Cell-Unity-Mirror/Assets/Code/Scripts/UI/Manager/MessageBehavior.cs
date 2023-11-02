using Mirror;
using UnityEngine;

public class MessageBehavior : NetworkBehaviour 
{
    public GameObject BattleLoading;

    [Command(requiresAuthority = false)]
    public void CmdSendMessage(string message, NetworkConnectionToClient sender = null)
    {
        Debug.Log("Received message: " + message);

        RpcReceiveMessage(message);
    }

    [ClientRpc]
    public void RpcReceiveMessage(string message)
    {
        Debug.Log("Received message: " + message);
    }

    [ClientRpc]
    public void StartGame(string message)
    {
        Debug.Log("StartGame message: " + message);

        GameObject.Find("MainPage")?.gameObject.SetActive(false);

        BattleLoading.gameObject.SetActive(true);

    }
}