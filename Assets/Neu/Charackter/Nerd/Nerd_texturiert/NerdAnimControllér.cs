using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NerdAnimControllér : NetworkBehaviour
{
    static Animator animator;
    public float speed = 10f;
    public float rotationSpeed = 100f;
    public float jumpForce = 10f;




    // Start is called before the first frame update
    void Start()
    {
        if (!isLocalPlayer)
            return;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isLocalPlayer)
            return;
        run();
        jump();



        //fürs testen_____________
        stumple();
        jostle();
        
    }

    void run()
    {
        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        /*
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;
        transform.Rotate(0, rotation, 0);
        transform.Translate(0, 0, translation);
        */
        if (translation != 0 || rotation !=0)
        {

            
            float speedMultiplier = Input.GetAxis("Vertical");
            if (speedMultiplier < 0)
            {
                speedMultiplier = speedMultiplier * -1;
            }

           // animator.SetFloat("rueckwaertsParam", speedMultiplier+0.7f);
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }




    }

    void jump()
    {
        if (Input.GetButton("Jump"))
        {
            animator.SetBool("isJumping", true);
            //Debug.Log("Springen");

        }



    }

    public void stumple()
    {
        
        if (Input.GetKeyDown(KeyCode.F))
        {
            animator.SetTrigger("FallenTrigger");
        }


    }

    public void jostle()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            animator.SetTrigger("SchubsenRechtsTrigger");
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            animator.SetTrigger("SchubsenLinksTrigger");
        }


    }
}
