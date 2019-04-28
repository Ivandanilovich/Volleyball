using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MyNetworkManager : NetworkManager
{
    private short firstPlayerId = 0;

    private void InstantiateBall()
    {
        var ball = Instantiate(spawnPrefabs[0]);
        NetworkServer.Spawn(ball);
    }
    public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId)
    {
        GameObject player;
        if (firstPlayerId != 0)
            player = Instantiate(playerPrefab, new Vector3(2, 0, 0), Quaternion.identity) as GameObject;
        else
            player = Instantiate(playerPrefab, new Vector3(-2, 0, 0), Quaternion.identity) as GameObject;
        NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
        firstPlayerId++;

        if (NetworkServer.connections.Count == 2)
        {
            InstantiateBall();
        }
    }
}
