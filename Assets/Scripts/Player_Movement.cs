using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{

    public float moveSpeed = 5f;
    public float sprintSpeed = 20f;

    public Rigidbody2D rb;
    public Animator animator;

    Vector2 movement;

    void Start()
    {
      moveSpeed = 5f;
      sprintSpeed = 8f;
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        
        if(Input.GetKey(KeyCode.LeftShift))
        {
           moveSpeed = sprintSpeed;
        }
        else
        {
            moveSpeed = moveSpeed;
        }

        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            moveSpeed = 5f;
        }

    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    private void AnimateMovement()
    {
        if(movement.y > 0f)
        {
            animator.Play("Little_Blondie 1");
        }else if(movement.y < 0)
        {
            animator.Play("Little_Blondie 2");
        }else if(movement.x > 0)
        {
            animator.Play("Little_Blondie 2");
        }else if(movement.x < 0)
        {
            animator.Play("Little_Blondie 2");
        }
    }
}
