using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FalleScript : MonoBehaviour
{
    public float moveSpeed = 2f;
    private float positionY;
    public float delta;
    bool zielOben = false;

    public GameObject schrumpfObjekt;

    // Start is called before the first frame update

        void Start()
        {
            positionY = this.gameObject.transform.position.y;
            
        }

        // Update is called once per frame
        void Update()
        {
            if (zielOben == false)
            {
                transform.Translate(0, moveSpeed * Time.deltaTime, 0);

                if (transform.position.y >= positionY + delta)
                {
                zielOben = true;
                }

            }

            if (zielOben == true)
            {
                transform.Translate(0, moveSpeed * Time.deltaTime * -1, 0);
                if (transform.position.y <= positionY - delta)
                {
                zielOben = false;
                }
            }


        }


    private void OnTriggerStay(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            float y = schrumpfObjekt.transform.localScale.y;
            y -= 0.1f;

            if (y > 0.01)
            {
                schrumpfObjekt.transform.localScale = new Vector3(1, y, 1);
                Debug.Log("AUA");

            }
        }
    }





}
