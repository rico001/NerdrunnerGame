using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMateScript : MonoBehaviour {

    public GameObject fluessigkeit;
    public GameObject deckel;
    // DynamicLevel level;
    public PlayerController playerController;

    void Start () {

        deckel.SetActive(true);
        fluessigkeit.SetActive(true);
        randomCreate();

        playerController = GetComponent<PlayerController>();
    }

    void randomCreate()
    {
        int random =Random.Range(1, 4);
        if (random > 1)
        {
            this.gameObject.SetActive(false);
        }
    }
	

	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)     
    {
        Debug.Log("Mate hatte Kollision mit " + other.name + " erkannt");
        deckel.SetActive(false);
        fluessigkeit.SetActive(false);
        GetComponent<BoxCollider>().enabled = false;
    }

}
