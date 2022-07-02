using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointFlag : MonoBehaviour
{
    private bool touched;
    
    private Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        touched = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // Play life clip
            if (!touched)
            {
                SoundManager.S.LifeSound();
            }
            
            touched = true;
            animator.SetBool("isActive", touched);
        }
    }
}
