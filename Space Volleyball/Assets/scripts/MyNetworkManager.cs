
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class MyNetworkManager : NetworkManager
{
    public List<PlayerController> players = new List<PlayerController>();
    public static MyNetworkManager Instance { get; private set; }

    public UnityEngine.UI.InputField addressInput;

    private short firstPlayerId = 0;
    private System.Random rand = new System.Random();
    private int[] scores = new int[] { 0, 0 };

    public static string winner = "nobody";

    //public void StartUpHost()
    //{
    //    //print(NetworkManager.toString());
    //    NetworkManager.singleton.networkPort = 7777;
    //    MyNetworkManager.singleton.StartHost();
    //}

    //public void JoinGame()
    //{
    //    MyNetworkManager.singleton.networkAddress = addressInput.text;
    //    MyNetworkManager.singleton.networkPort = 7777;
    //    MyNetworkManager.singleton.StartClient();
    //}

    private void Awake()
    {
        Instance = this;
    }

    private void InstantiateBall()
    {
        var ball = Instantiate(spawnPrefabs[0] , new Vector3(0,2,0), Quaternion.identity);
        ball.GetComponent<Rigidbody>().AddForce((float)rand.NextDouble() * 10, 40, 0);
        NetworkServer.Spawn(ball);
    }

    private Vector3[] starts = new Vector3[]
    {
        new Vector3(-2,0.5f,0),
        new Vector3(2,0.5f,0)
    };

    public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId)
    {
        GameObject player;
        if (firstPlayerId != 0)
            player = Instantiate(playerPrefab, new Vector3(2, 0, 0), Quaternion.identity) as GameObject;
        else
            player = Instantiate(playerPrefab, new Vector3(-2, 0, 0), Quaternion.identity) as GameObject;
        NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
        players.Add(player.GetComponent<PlayerController>());
        firstPlayerId++;

        if (NetworkServer.connections.Count == 2)
        {
            InstantiateBall();
        }

        //var playerCount = NetworkServer.connections.Count;
        //if (playerCount <= starts.Length)
        //{
        //    if (playerCount == 2)
        //    {
        //        InstantiateBall();
        //    }
        //    var player = Instantiate(playerPrefab, starts[playerCount-1], Quaternion.identity) as GameObject;
        //    NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
        //    players.Add(player.GetComponent<PlayerController>());
        //}
        //else
        //{
        //    conn.Disconnect();
        //}
    }

    
}
