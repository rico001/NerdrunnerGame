using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class thirdPersonCam : NetworkBehaviour
{

    [Range(0.1f, 1f)]
    public float offset;
    public float steps = 0.25f;

    private Vector3 camOffset;

    public Transform playerTransform;

    // Use this for initialization
    void Start()
    {
        if (!isLocalPlayer)
            return;
        transform.position = new Vector3(0, transform.position.y + playerTransform.transform.position.y, transform.position.z);
        camOffset = transform.position - playerTransform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (!isLocalPlayer)
            return;
        Vector3 offsetRoatated = playerTransform.transform.rotation * camOffset;

        transform.position = playerTransform.transform.position + offsetRoatated;

        //if (steps < 1) steps += 0.0005f;

        transform.rotation = Quaternion.Slerp(transform.rotation, playerTransform.rotation, steps);

        /*
        transform.position = playerTransform.position;
        rotation1();
        positionAkt();
        */



    }
}
