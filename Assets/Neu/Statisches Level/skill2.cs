using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skill2 : MonoBehaviour
{
    float nextUpdate = 3f;
    Material matTransp;
    bool isTransparent = false;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Time.time >= nextUpdate)
        {
            isTransparent = !isTransparent;

            if (isTransparent)
            {
                GetComponent<Renderer>().material = matTransp;
            }


        }
    }

}
