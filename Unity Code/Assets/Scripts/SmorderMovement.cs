using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmorderMovement : MonoBehaviour
{
    public float speed;
    private bool faceLeft = true;

    private CharacterController2D controller;

    private Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController2D>();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        float horizontalMove = speed * Time.fixedDeltaTime;

        if (faceLeft)
        {
            horizontalMove *= -1.0f;
        }
        
        controller.Move(horizontalMove, false, false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "TurnArea")
        {
            faceLeft = !faceLeft;
        }
    }
}
