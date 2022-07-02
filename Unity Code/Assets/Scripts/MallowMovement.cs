using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MallowMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public float speed;

    private float horizontalMove = 0.0f;
    private bool jump = false;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        GameManager.S.SetRespawn(transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * speed;

        if (Input.GetButtonDown("Jump") && GameManager.S.gameState == GameState.playing)
        {
            jump = true;
        }

        animator.SetBool("isGrounded", controller.m_Grounded);
        animator.SetBool("isMoving", Input.GetAxis("Horizontal") != 0.0f);
        animator.SetBool("isDying", GameManager.S.gameState == GameState.oops);
    }

    void FixedUpdate()
    {
        if (GameManager.S.gameState == GameState.playing)
        {
            controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        }
        jump = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Token")
        {
            // Increase score
            GameManager.S.AddScore(100);

            // Delete token
            Destroy(collision.gameObject);

            // Play token clip
            SoundManager.S.TokenSound();
        }

        if (collision.gameObject.tag == "Life")
        {
            // Increase life count
            if (GameManager.S.GetDeaths() > 0)
            {
                GameManager.S.AddDeath(-1);
            }

            // Increase score
            GameManager.S.AddScore(500);

            // Delete life
            Destroy(collision.gameObject);

            // Play life clip
            SoundManager.S.LifeSound();
        }

        if (collision.gameObject.tag == "FallArea")
        {
            // Decrease life count
            GameManager.S.AddDeath(1);

            // Play life clip
            SoundManager.S.MallowDeathSound();

            // Return to respawn point
            GameManager.S.Respawn();

            // Destroy player
            Destroy(this.gameObject, 2.0f);
        }

        if (collision.gameObject.tag == "CheckpointFlag")
        {
            // Set respawn point
            GameManager.S.SetRespawn(collision.gameObject.transform.position);
        }

        if (collision.gameObject.tag == "EndFlag")
        {
            // Play life clip
            SoundManager.S.LifeSound();
            
            // Move to next level
            LevelManager.S.NextLevel();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            // Decrease life count
            GameManager.S.AddDeath(1);

            // Play life clip
            SoundManager.S.MallowDeathSound();

            // Return to respawn point
            GameManager.S.Respawn();

            // Destroy player
            Destroy(this.gameObject, 2.0f);
        }
    }
}
