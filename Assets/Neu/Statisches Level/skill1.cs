using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skill1 : MonoBehaviour
{
    public float moveSpeed=2f;
    private float positionX;
    public float delta=5;
    bool zielRechts=false;
    //bool zielLinks=true;


    // Start is called before the first frame update
    void Start()
    {
        positionX = this.gameObject.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (zielRechts==false)
        {
            transform.Translate(moveSpeed * Time.deltaTime,0,0);

            if (transform.position.x >= positionX+delta)
            {
                zielRechts = true;
            }

        }

        if (zielRechts == true)
        {
            transform.Translate(moveSpeed * Time.deltaTime * -1, 0, 0);
            if (transform.position.x <= positionX - delta)
            {
                zielRechts = false;
            }
        }


    }
}
