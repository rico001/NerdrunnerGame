using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FolloPathSkill : MonoBehaviour {

    private Vector3 target1;
    private Vector3 target2;
    public float speed;
    private bool oben;


	// Use this for initialization
	void Start () {
        target1= this.transform.position + new Vector3(0, 8, 0);
        target2 = this.transform.position + new Vector3(0, -4, 0);
    }
	
	// Update is called once per frame
	void Update () {

        if (oben)
        {
            down();
        }
        else
        {
            up();
        }


	}

    private void up()
    {
        Vector3 pos = Vector3.MoveTowards(transform.position, target1, speed * Time.deltaTime);
        GetComponent<Rigidbody>().MovePosition(pos);
        if (target1 == this.transform.position)
        {
            oben = true;
            Debug.Log("angekommen");
        }
    }

    private void down()
    {
        Vector3 pos = Vector3.MoveTowards(transform.position, target2, speed * Time.deltaTime);
        GetComponent<Rigidbody>().MovePosition(pos);
        if (target2 == this.transform.position)
        {
            oben = false;
            Debug.Log("angekommen");
        }
    }



}

