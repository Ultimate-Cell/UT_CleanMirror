using System.Collections.Generic;
using UnityEngine;

/*
	Documentation: https://mirror-networking.gitbook.io/docs/components/network-manager
	API Reference: https://mirror-networking.com/docs/api/Mirror.NetworkManager.html
*/

namespace Mirror.Examples.Pong
{
    // Custom NetworkManager that simply assigns the correct racket positions when
    // spawning players. The built in RoundRobin spawn method wouldn't work after
    // someone reconnects (both players would be on the same side).
    [AddComponentMenu("")]
    public class NetworkManagerPong : NetworkManager
    {
        public Transform leftRacketSpawn;
        public Transform rightRacketSpawn;
        GameObject ball;

        // 玩家暂存区
        // 当玩家人数满足两人时将其他玩家加入观战区
        private List<NetworkConnectionToClient> players = new List<NetworkConnectionToClient>();

        /// <summary>
        /// Player 进入房间
        /// 在Player进入房间时先进行等待操作
        /// 在两个player都进入房间时再开始游戏
        /// </summary>
        /// <param name="conn"></param>
        public override void OnServerAddPlayer(NetworkConnectionToClient conn)
        {
            if (players.Count == 2) return;

            players.Add(conn);

            this.AddPlayerForConnection(conn);

            Debug.Log("player add room");
        }

        public void AddPlayerForConnection(NetworkConnectionToClient conn)
        {
            // add player at correct spawn position
            Transform start = numPlayers == 0 ? leftRacketSpawn : rightRacketSpawn;
            GameObject player = Instantiate(playerPrefab, start.position, start.rotation);
            NetworkServer.AddPlayerForConnection(conn, player);

            // spawn ball if two players
            if (numPlayers == 2)
            {
                this.StartGame();
            }
        }

        public void StartGame()
        {
            ball = Instantiate(spawnPrefabs.Find(prefab => prefab.name == "Ball"));
            NetworkServer.Spawn(ball);
        }

        public override void OnServerDisconnect(NetworkConnectionToClient conn)
        {
            // destroy ball
            if (ball != null)
                NetworkServer.Destroy(ball);

            // call base functionality (actually destroys the player)
            base.OnServerDisconnect(conn);
        }
    }
}
