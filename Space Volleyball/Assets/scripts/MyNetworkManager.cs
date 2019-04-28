using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MyNetworkManager : NetworkManager
{
    public GameObject ballPrefab;
    private GameObject ball;
    private short firstPlayerId = 0;
    void Start()
    {
    }

    //[Command]
    //[System.Obsolete]
    //public void CmdSpawnBall()
    //{
    //    ball = Instantiate(ballPrefab, new Vector3(2, 3, 0), Quaternion.identity) as GameObject;
    //}
    public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId)
    {
        //base.OnServerAddPlayer(conn, playerControllerId);
        GameObject player;
        if (firstPlayerId != 0)
        {
            player = Instantiate(playerPrefab, new Vector3(2, 0, 0), Quaternion.identity) as GameObject;
          //  CmdSpawnBall();
        }
        else
        {
            player = Instantiate(playerPrefab, new Vector3(-2, 0, 0), Quaternion.identity) as GameObject;
        }
    //    print("playerControllerId " + playerControllerId);
        NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
        firstPlayerId++;
    }

  
    // Update is called once per frame
    void Update()
    {
        
    }
}
