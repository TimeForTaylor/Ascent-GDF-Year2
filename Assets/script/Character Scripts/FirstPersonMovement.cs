using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonMovement : MonoBehaviour
{
    bool isWalkingX, isWalkingY;
    public AudioSource walkSFX;

    public float speed = 4;
    public float speedTrue = 0;
    Vector2 velocity;
    private bool isGrounded = false;
    public float jumpSpeed = 5;
    public Rigidbody rb;

    private bool onLadder = false;
    public float speedUpDown = 1.1f;

    public GameObject glowStick;

    public Transform hand;

    // Start is called before the first frame update
    void Start()
    {
        Physics.IgnoreLayerCollision(9,11);
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            //speedTrue = speed+2;
        }
        else
        {
            speedTrue = speed;
        }
        //Movement
        velocity.y = Input.GetAxis("Vertical") * speedTrue * Time.deltaTime;
        velocity.x = Input.GetAxis("Horizontal") * speedTrue * Time.deltaTime;
        transform.Translate(velocity.x, 0, velocity.y);
    }


    void Update()
    {
        //Jumping
        if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded)
            {
                //Jump();
                //Debug.Log("Jumped");
            }
            
        }

        //climbing
        if (onLadder == true && Input.GetKey("w"))
        {
            transform.position += Vector3.up / speedUpDown;
        }
        
        //Walking SFX
        if (velocity.y != 0)
        {
            isWalkingY = true;
            Sfx();
            //Debug.Log("Y True");
        }

        if (velocity.x != 0)
        {
            isWalkingX = true;
            Sfx();
            //Debug.Log("X True");
        }

        if (velocity.y == 0)
        {
            isWalkingY = false;
            Sfx();
            //Debug.Log("Y False");
        }

        if (velocity.x == 0)
        {
            isWalkingX = false;
            Sfx();
            //Debug.Log("Y False");
        }

        if (Input.GetButtonDown("Fire2"))
        {

            Instantiate(glowStick, hand.position, hand.rotation);
        }
        
    }

    void Sfx()
    {
        if (isWalkingX || isWalkingY && isGrounded == false)
        {
            if (!walkSFX.isPlaying)
            {
                walkSFX.Play();
            }

        }
        else if (isWalkingX == false && isWalkingY == false)
        {
            walkSFX.Stop();
        }
    }

    void Jump()
    {
        Vector3 jumpVelocityToAdd = new Vector3(0f, jumpSpeed, 0f);
        rb.velocity += jumpVelocityToAdd;
    }

    //is touching ladder
    private void OnTriggerEnter(Collider climb)
    {
        if (climb.gameObject.CompareTag("Ladder"))
        {
            onLadder = true;
        }
    }
    
    //not touching ladder
    private void OnTriggerExit(Collider climb)
    {
        if (climb.gameObject.CompareTag("Ladder"))
        {
            onLadder = false;
        }
    }

    //Is Grounded
    void OnCollisionEnter(Collision hit)
    {
        if (hit.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
    //Not Grounded
    void OnCollisionExit(Collision hit)
    {
        if (hit.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
