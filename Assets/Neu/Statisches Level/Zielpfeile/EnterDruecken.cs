using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterDruecken : MonoBehaviour
{
    private float delta =0.5f;
    public bool isClicked = false;
    private float startPositionY;

    public GameObject ende;

    private void Start()
    {
        startPositionY = transform.position.y;
    }

    private void Update()
    {
        if (isClicked== true){
            transform.Translate(0, -0.5f*Time.deltaTime, 0);
        }

        if (transform.position.y < startPositionY - delta)
        {
            ende.SetActive(true);

        }
    }

    private void OnTriggerStay(Collider other)
    {
        isClicked = true;
    }


}
