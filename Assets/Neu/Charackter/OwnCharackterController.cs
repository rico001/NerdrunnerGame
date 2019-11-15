using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class OwnCharackterController : NetworkBehaviour
{

    public float moveSpeed;
    public float jumpForce;
    public float turnForce;

    private float angle;
    private Vector3 moveDirection;
    private bool isJumping=false;

    private Rigidbody charRigidbody;
    private CharacterController charController;
    private Animator animator;
    public GameObject movementParticles;

    private void Start()
    {
        if (!isLocalPlayer)
            return;
        charRigidbody = this.GetComponent<Rigidbody>();
        charController = this.GetComponent<CharacterController>();
        animator = this.GetComponent<Animator>();
    }

    private void Update()
    {
        
    }

    public void vorwaertsBewegen()
    {

        movementParticles.SetActive(true);
       // Debug.Log("rennen");
            animator.SetBool("isRunning", true);
            transform.Translate(0, 0, moveSpeed * Time.deltaTime);


    }

    public void drehen()
    {
        animator.SetBool("isGroundet", true);
       // Debug.Log("drehen");
        animator.SetBool("isRunning", true);
        angle += turnForce* Input.GetAxis("Horizontal");
        Vector3 vecRot = new Vector3(Mathf.Sin(angle), 0, Mathf.Cos(angle));
        Quaternion rotation = Quaternion.LookRotation(vecRot, Vector3.up);
        transform.rotation = rotation;

    }

    
    public void springen()
    {
        movementParticles.SetActive(false);
        //Debug.Log("jump");
        animator.SetTrigger("isJumping");
        animator.SetBool("isGroundet",false);
        charRigidbody.velocity = Vector3.up * jumpForce;
    }

    public void stehen()

    {
        animator.SetBool("isGroundet", true);
        movementParticles.SetActive(false);
        animator.SetBool("isRunning", false);
    }

}