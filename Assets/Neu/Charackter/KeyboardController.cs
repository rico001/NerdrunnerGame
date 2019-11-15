
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class KeyboardController : NetworkBehaviour {

    private OwnCharackterController ownCharackterController;
    public Camera thirdPersonCam;

	void Start () {
        if (!isLocalPlayer)
            return;
        ownCharackterController = this.GetComponent<OwnCharackterController>();
    }
	

	void Update () {
        if (!isLocalPlayer)
            return;
        keyboardListener();
	}

    private void keyboardListener()
    {

        //jump chrackter
        if (Input.GetButtonDown("Jump"))
        {
            ownCharackterController.springen();
        }

        //forward charackter
        if (Input.GetAxis("Vertical")>0)
        {
            ownCharackterController.vorwaertsBewegen();
        }
        
        //stops charackter
        if (Input.GetAxis("Vertical")==0)
        {
            ownCharackterController.stehen();
        }

        //turn Charackter
        if (Input.GetAxis("Horizontal")!=0)
        {
            ownCharackterController.drehen();
        }

        //change Cam
        if (Input.GetKeyDown(KeyCode.C))
        {
            thirdPersonCam.enabled = !thirdPersonCam.enabled;
        }
    }
    
}
