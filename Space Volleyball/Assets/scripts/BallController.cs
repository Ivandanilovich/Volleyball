using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class BallController : NetworkBehaviour
{

    public GameObject ball;
    private Rigidbody rBall;
    // Start is called before the first frame update
    void Start()
    {
        rBall = ball.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rBall.transform.position.y <= 0.25)
        {
            //respawn
        }
      //  print("here");
        if (Input.GetKeyDown(KeyCode.F))
        {
            print("inF");
            rBall.useGravity = true;
            rBall.transform.position = new Vector3(-2, 3, 0);
        }
    }
}
