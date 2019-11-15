using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicLevel : MonoBehaviour {

    private int childCounter=4;
    public int LEVELCOMPLETEAFTER=15;
    public bool levelComplete=false;
    public int score=0;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        deleteChildren();
        levelCompleteMessage();
	}

    void deleteChildren()
    {

       // Debug.Log(transform.childCount);
        if (transform.childCount > 4)
        {
            Transform firstChild = gameObject.transform.GetChild(0);
            //Debug.Log("1."+firstChild.gameObject.name+" wurde gelöscht");
            Destroy(firstChild.gameObject);

            childCounter++;
        }

    }

    void levelCompleteMessage()
    {
        if (childCounter >= LEVELCOMPLETEAFTER)
        {
            Debug.Log("Level vorbei, weil >="+childCounter+" Pixel erzeugt wurden!!!");
            levelComplete = true;
        }
    }

    public void inkrementScore()
    {
        ++score;
    }




}
