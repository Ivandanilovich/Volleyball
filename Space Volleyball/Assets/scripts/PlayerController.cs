using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Range(0, 100)] public float jumpForce = 9;
    [Range(0, 100)] public float stepForce = 50;
    [Range(0, 10)] public float maxVel = 5;
    public float minY = 0.18f;
    public GameObject player;
    private Rigidbody rBody;

    void FixedUpdate()
    {

    }

    void Start()
    {
        rBody = player.GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S) && rBody.transform.position.y <= minY)
            rBody.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
        if (Input.GetKey(KeyCode.A) && rBody.velocity.x > -maxVel)
            rBody.AddForce(new Vector3(-stepForce, 0, 0), ForceMode.Acceleration);
        if (Input.GetKey(KeyCode.D) && rBody.velocity.x < maxVel)
            rBody.AddForce(new Vector3(stepForce, 0, 0), ForceMode.Acceleration);
        var vel = rBody.velocity;
    }
}