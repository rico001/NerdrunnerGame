using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountdownStart : MonoBehaviour
{

    public Material mat1;
    public Material mat2;

    public GameObject reihe1;
    public GameObject reihe2;
    public GameObject reihe3;

    bool isTouched = false;
    int toggleCounter = 0;
    float nextUpdate = 3f;

    private Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        if (isTouched == true)
        {

            if (Time.time >= nextUpdate)
            {
                nextUpdate = Time.time + 3f;

                toggleCounter++;
                toggle();
            }

        }
        else
        {


        }
    }

    private void toggle()
    {
        if (toggleCounter == 1)
        {
            reihe1.GetComponent<Renderer>().material = mat2;
        }
        if (toggleCounter == 2)
        {
            reihe2.GetComponent<Renderer>().material = mat2;
        }
        if (toggleCounter == 3)
        {
            reihe3.GetComponent<Renderer>().material = mat2;
        }
        if (toggleCounter > 3)
        {
            destroy();
        }

    }

    private void destroy()
    {

        rb.useGravity = true;

        if (transform.position.y < -500)
        {
            Destroy(this.gameObject);
        }


    }


    private void OnTriggerEnter(Collider other)         //bei Berühren wird neuer Cube erstellt und Farbe des kolldierten Cubes wird verändert
    {
        if (isTouched == false)
        {
            setColor();
            isTouched = true;

        }


    }

    void setColor()          //ausgeführt auf Cube der berührt wird vom Charackter
    {
        reihe1.GetComponent<Renderer>().material = mat1;
        reihe2.GetComponent<Renderer>().material = mat1;
        reihe3.GetComponent<Renderer>().material = mat1;

        isTouched = true;
    }

    void setColor(int reihe)          //ausgeführt auf Cube der berührt wird vom Charackter
    {
        Material cube_material;
        cube_material = GetComponent<Renderer>().material;
        cube_material.color = Color.black;
    }
}
