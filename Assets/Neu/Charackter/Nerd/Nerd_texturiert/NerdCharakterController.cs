using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NerdCharakterController : NetworkBehaviour
{
    public float turnSpeed = 0.1f;
    public float speed;
    public float jumpSpeed = 25f;
    public float gravity = 20.0f;
    private float angle;
    public int score = 0;

    public GameObject handRechts;
    public GameObject handLinks;

    public GameObject kopf;
    private bool isPlatt = false;
    float nextUpdate = 1f;


    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;

    void Start()
    {
        if (!isLocalPlayer)
            return;
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (!isLocalPlayer)
            return;

        if (controller.isGrounded)
        {
            // We are grounded, so recalculate
            // move direction directly from axes

            moveDirection = new Vector3(0, 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection = moveDirection * speed;

            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;

            }
        }

        // Apply gravity
        moveDirection.y = moveDirection.y - (gravity * Time.deltaTime);

        // Move the controller
        controller.Move(moveDirection * Time.deltaTime);

        if (!controller.isGrounded)
        {
            drehen(turnSpeed / 10);
        }
        else
        {
            drehen(turnSpeed);
        }


        regenriereKopf();   
    }

    public void drehen(float speed)
    {
        if (!isLocalPlayer)
            return;
        angle += speed * Input.GetAxis("Horizontal");
        Vector3 vecRot = new Vector3(Mathf.Sin(angle), 0, Mathf.Cos(angle));
        Quaternion rotation = Quaternion.LookRotation(vecRot, Vector3.up);
        transform.rotation = rotation;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag=="Falle"){

            float y = kopf.transform.localScale.y;
            y -= 0.1f;

            if (y > 0.01)
            {
                kopf.transform.localScale = new Vector3(1, y, 1);
                Debug.Log("AUA");
                isPlatt = true;
            }

        }
    }

    private void regenriereKopf()
    {
        if (Time.time >= nextUpdate)
        {
            nextUpdate = Time.time + 1f;

            if (isPlatt == true) {

                if (kopf.transform.localScale.y <= 1)
                {
                    float newY = kopf.transform.localScale.y;
                    newY += 0.05f;
                    kopf.transform.localScale = new Vector3(1, newY, 1);
                }
                else
                {
                    isPlatt = false;
                }

            }
        }

    }



}
