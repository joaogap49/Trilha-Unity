using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    public Rigidbody thisRigidBody;

    public float jumpForce = 5f;
    public float jumpInterval = 0.2f;
    private float jumpCooldown = 0f;

    void Start()
    {
        thisRigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Update cooldown
        jumpCooldown -= Time.deltaTime;
        bool isGameActive = GameManager.Instance.IsGameActive();
        bool canJump = jumpCooldown <= 0f && isGameActive;

        //Jump!
        if (canJump)
        {
            bool jumpInput = Input.GetKey(KeyCode.Space);
            if (jumpInput)
            {
                Jump();
            }
        }

        thisRigidBody.useGravity = isGameActive;

    }

    private void OnTriggerEnter(Collider other)
    {
        OnCustomCollisionEnter(other.gameObject);
    }

    private void OnCollisionEnter(Collision other)
    {
        OnCustomCollisionEnter(other.gameObject);
    }

     private void OnCustomCollisionEnter(GameObject other)
    {
        bool isSensor = other.CompareTag("Sensor");
        if (isSensor)
        {
            GameManager.Instance.score++;
        }
        else
        {
            GameManager.Instance.EndGame();
        }
    }

    private void Jump()
    {
        //Reset the jump cooldown and apply the jump force
        thisRigidBody.velocity = Vector3.zero;
        jumpCooldown = jumpInterval;
        thisRigidBody.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
    }
}
