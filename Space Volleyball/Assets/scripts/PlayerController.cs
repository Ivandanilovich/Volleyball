using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour
{
    [Range(0, 100)] public float jumpForce = 9;
    [Range(0, 100)] public float stepForce = 50;
    [Range(0, 10)] public float maxVel = 5;
    public float minY = 0.18f;
    public GameObject player;
    private Rigidbody rBody;

    private CameraScript cameraScript;
    [SyncVar] private int playerID;

    [SyncVar (hook ="OnPointsChange")] private int points;


    private void OnPointsChange(int points)
    {
        cameraScript.UpdateUI(playerID, points);
    }

    public int Points
    {
        get { return points; }
        set { if (value > 0 && value != points) points = value; }
    }

    void FixedUpdate()
    {
        if (!isLocalPlayer) return;

        if (Input.GetKeyDown(KeyCode.S) && rBody.transform.position.y <= minY)
            rBody.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
        if (Input.GetKey(KeyCode.A) && rBody.velocity.x > -maxVel)
            rBody.AddForce(new Vector3(-stepForce, 0, 0), ForceMode.Acceleration);
        if (Input.GetKey(KeyCode.D) && rBody.velocity.x < maxVel)
            rBody.AddForce(new Vector3(stepForce, 0, 0), ForceMode.Acceleration);
    }

    public override void OnStartLocalPlayer()
    {
        rBody = player.GetComponent<Rigidbody>();
        //GetComponent<SpriteRenderer>().color = Color.red;
        base.OnStartLocalPlayer();
        if (isServer) playerID = 1;
    }

    private void Awake()
    {
        cameraScript = Camera.main.GetComponent<CameraScript>();
    }
}