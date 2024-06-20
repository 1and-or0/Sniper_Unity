using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPlayer : MonoBehaviour
{
    public float slidePower;
    Animator animator;
    Rigidbody rb;
    public float jumpForce;
    public AudioSource jumpAudio;
    public AudioSource slideAudio;
    CapsuleCollider capsuleCollider;
    // Start is called before the first frame update
    void Start()
    {
        capsuleCollider = GetComponent<CapsuleCollider>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        SetSpeed();
    }

    void SetSpeed()
    {
        if (!animator.GetBool("isJumping"))
            animator.SetFloat("Speed", 1);
        else
            animator.SetFloat("Speed", 0);
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        SetIsJumping();
        Slide();
    }
    
    void Slide()
    {
        if(Input.GetKeyDown(KeyCode.Z) && !animator.GetBool("isSliding")) 
        {
            slideAudio.Play();
            animator.SetBool("isSliding", true);
            Invoke("SetisSlidingFalse", 0.5f);
            capsuleCollider.height = capsuleCollider.height / 6f;
            capsuleCollider.center = new Vector3(capsuleCollider.center.x, capsuleCollider.center.y + 0.3f, capsuleCollider.center.z);
        }
    }

    void SetisSlidingFalse()
    {
        animator.SetBool("isSliding", false);
        capsuleCollider.height = capsuleCollider.height * 6f;
        capsuleCollider.center = new Vector3(capsuleCollider.center.x, capsuleCollider.center.y - 0.3f, capsuleCollider.center.z);
    }

    void SetIsJumping()
    {
        animator.SetBool("isJumping", animator.GetBool("isJumping"));
       
    }

    void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && !animator.GetBool("isJumping"))
        {
            animator.SetBool("isJumping", true);
            rb.AddForce(Vector2.up * jumpForce, ForceMode.Impulse);
            jumpAudio.Play();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground") && animator.GetBool("isJumping"))
        {
            animator.SetBool("isJumping", false);
        }
    }
}
