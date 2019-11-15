using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCube : MonoBehaviour {

    public Transform spawnPos;      //pixel wird relativ zu spawnPos positioniert
    public GameObject pixel;        //wird neu erzeugt
    public GameObject dynamicLevel; //neu erzeugtes Pixel wird dem dynmaicLevel hinzugefügt
    public GameObject MateItem;        //wird zufällig erstellt

    public GameObject cubeOnCollision;         //zum Manipulieres des Cubes (Farbe;Größe etc.)
    private GameObject newCubeOnCollision;       //zum Manipulieres des neuen Cubes (Farbe;Größe etc.)

    private int counter=0;
    private bool hasCreated=false;



    // Use this for initialization
    void Start()
    {
        spawnPos = this.transform;          //Position zu der neuer Cube sich relativ positioniert (x,y zufällig)
        showMate();
    }

   

    private void OnTriggerEnter(Collider other)         //bei Berühren wird neuer Cube erstellt und Farbe des kolldierten Cubes wird verändert
    {
        //Debug.Log("Kollision mit " + other.name + " erkannt");
        createNewPixelCube();
        setColor(cubeOnCollision);
        
    }

    void createNewPixelCube()
    {
        if (hasCreated == false)
        {
            GameObject newCube = Instantiate(pixel, spawnPos.position, spawnPos.rotation);          //neuer Cube an identische Stelle wie alter Cube
            newCube.transform.parent = dynamicLevel.transform; //hinzufügen in Dynamic Level
            newCube.name = "new Pixel";

            //Positionieren des Cubes
            float x = setRandomX();
            float y = setRandomY();
            float z = setRandomZ();
            newCube.transform.Translate(x, y, z);          //neuen Cube verschieben
            counter++;                                      //zählt wieviele Cube erstellt wurden im Spieleverlauf
            hasCreated = true;
            setColorNewCube(newCube);
        }

    }

    void setColor(GameObject cube)          //ausgeführt auf Cube der berührt wird vom Charackter
    {
        Material cube_material;
        cube_material = cube.GetComponent<Renderer>().material;
        cube_material.color = Color.black;
    }

    void setColorNewCube(GameObject cube)
    {
        Material cube_material;
        cube_material = cube.GetComponent<Renderer>().material;
        cube_material.color = Color.black;
    }

    float setRandomX()
    {
        return Random.Range(-5, 5);
    }

    float setRandomY()
    {
        return Random.Range(-2, 5);
    }

    float setRandomZ()
    {
        return Random.Range(8, 10);
    }

    void placeMateBottle()
    {
        //setzt ggf ein Item/Mateflasche auf Cube
        //->bottleObject enable!!
    }

    void setCubeSkill()
    {
        //verschwinden im Takt oder BEwegung
    }

    //erstellt zufällig MateItem
    private void showMate()
    {
        int random = Random.Range(1, 4);
        if (random == 1)
        {   MateItem.SetActive(true);        //1:3 Chance dass Mate erstellt wird

        } 
        else
        {
            MateItem.SetActive(false);

        }
    }


}