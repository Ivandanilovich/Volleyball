using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class BallController : NetworkBehaviour
{
   // public GameObject ball;
    private Rigidbody rBall;
    private System.Random rand = new System.Random();

    void Start()
    {
        rBall = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (rBall.transform.position.y <= 0.25)
        {
            if (isServer)
            {
                if (rBall.transform.position.x > 0)
                {
                    MyNetworkManager.Instance.players[0].Points++;
                }
                else
                {
                    MyNetworkManager.Instance.players[1].Points++;
                }
            }
            rBall.velocity = new Vector3(0, 0, 0);
            rBall.transform.position = new Vector3(0, 3, 0);
            rBall.AddForce((float)rand.NextDouble() * 20 * rand.Next(2)-1.5f, 15, 0);

        }
    }
}












//public GameObject ball;
//public Text text;
//[SyncVar]
//int score = -1;
//private Rigidbody rBall;
//private bool isOnGround = true;
//// Start is called before the first frame update
//void Start()
//{
//    rBall = ball.GetComponent<Rigidbody>();
//}

//// Update is called once per frame
//void Update()
//{
//    //  print(isLocalPlayer);
//    // if (isLocalPlayer)
//    //{
//    text.text = score.ToString();
//    if (rBall.transform.position.y <= 0.25)
//    {
//        //respawn
//        rBall.useGravity = false;
//        rBall.velocity = new Vector3(0, 0, 0);
//        rBall.transform.position = new Vector3(-2, 3, 0);
//        isOnGround = true;
//        //  CmdIncreaseScore();
//        score--;
//    }
//    //  print("here");
//    if (Input.GetKeyDown(KeyCode.F) && isOnGround)
//    {
//        rBall.useGravity = true;
//        isOnGround = false;
//    }
//    //}
//}

//[Command]
//void CmdIncreaseScore()
//{
//    print("555555");
//    RpcInc();
//}

//[ClientRpc]
//void RpcInc()
//{
//    print("hete111");
//    score++;
//}
//}
