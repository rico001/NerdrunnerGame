using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : NetworkBehaviour
{
    int healthCounter = 5;
    int mateCounter = 0;

    Text healthCounterText;
    Text mateCountertext;
    Canvas overlayEnde;
    Text overlayEnde_sieger;
    Text time;

    private Rigidbody rigidbody;

    private bool nameSet = false;

    private float delta = -30; //respawn height
    Vector3 spawnPoint;
    
    public string winnerNot = "";

    private Time starttime;

    [SyncVar] public bool finish = false;

    NetworkManager nm;

    public GameController gameController;
    TimeSpan span;

    bool timeBerechnet = false;



    bool gestorben = false;

    private void Awake()
    {
        name = "Client";
        spawnPoint = GameObject.Find("SpawnPoint").transform.position;
        nm = FindObjectOfType<NetworkManager>();
    }

    private void Start()
    {
        if (isLocalPlayer)
        {
            GameObject.Find("Main Camera").gameObject.transform.parent = this.transform;
        }

        transform.position = spawnPoint;
        gameController = GetComponent<GameController>();
        healthCounterText = GameObject.Find("HealthCounterText").GetComponent<Text>();
        mateCountertext = GameObject.Find("Mate").GetComponent<Text>();
        time = GameObject.Find("Time").GetComponent<Text>();
        time.enabled = false;
        //time.text = Time.timeSinceLevelLoad.ToString();

        overlayEnde = GameObject.Find("OverlayEnde").GetComponent<Canvas>();
        overlayEnde_sieger = GameObject.Find("GewinnerText").GetComponent<Text>();

        overlayEnde.enabled = false;

        rigidbody = this.GetComponent<Rigidbody>();
    }

    public int getHealthCounter()
    {
        return healthCounter;
    }

    public int getMateCounter()
    {
        return mateCounter;
    }

    public void incMateCounter()
    {
        mateCounter++;
    }

    private void Update()
    {
        if (!isLocalPlayer)
            return;


        if (gameController.player < 1 && gameController.gameStartet)
        {
            finish = true;
            if (name == "Host")
            {
                winnerNot = "Client";
            }
            else
            {
                winnerNot = "Host";
            }
        }

        healthCounterText.text = generateHearth(healthCounter);
        mateCountertext.text = "Mate: " + mateCounter.ToString();

        if (isServer && !nameSet)
        {
            name = "Host";
            nameSet = true;
        }

        if (transform.position.y < delta)
        {
            healthCounter = 0;
        }

        if (healthCounter == 0)
        {
            finish = true;
            if (!isClient)
            {
                CmdSyncFinishWithServer(finish);
            }
            winnerNot = name;

            gameController.player--;

            CmdSyncWinnerWithServer(winnerNot);
            gestorben = true;
        }
        
        if (finish)
        {
            finish = true;
            CmdSyncFinishWithServer(finish);
            overlayEnde.enabled = true;
            string winner;
            if (winnerNot == "Host")
            {
                winner = "Client";
            }
            else
            {
                winner = "Host";
            }

         //   Debug.Log(timeBerechnet);
            if (!timeBerechnet)
            {
                DateTime endTime = DateTime.Now;
               // Debug.Log(endTime);
                endTime = endTime.AddSeconds((-mateCounter) * 10);
               // Debug.Log(endTime);
                span = endTime.Subtract(gameController.startTime);
              //  Debug.Log(span);

              //  Debug.Log(span.Minutes);

               // Debug.Log(span.Seconds);
                timeBerechnet = true;

              

            }


            overlayEnde_sieger.text = "Spieler " + winner + " hat gewonnen! \n Gesammelte Mate Flaschen: " + mateCounter + "\n Zeitbonus " + (mateCounter * 10) + " Sekunden \n Zeit: " + span.Minutes + ":" + span.Seconds;

            if (gestorben)
            {
                overlayEnde_sieger.text = "Du bist gestorben!";
            }
        }
    }



    [Command]
    void CmdSyncFinishWithServer(bool finish)
    {
        this.finish = finish;
    }



    [Command]
    void CmdSyncWinnerWithServer(string winnerNot)
    {
        this.winnerNot = winnerNot;
    }


    public void OnTriggerEnter(Collider other)
    {
        if(other.name == "Enter")
        {
            finish = true;
            CmdSyncFinishWithServer(finish);
            if (name == "Host")
            {
                winnerNot = "Client";
                CmdSyncWinnerWithServer(winnerNot);
            } else
            {
                winnerNot = "Host";
                CmdSyncWinnerWithServer(winnerNot);
            }
        }

        if (other.name == "Oberteil")
        {
            healthCounter--;
        }

        if (other.name == "mate Final mit Label")
        {
            incMateCounter();
        }

        if (other.name == "Hand")
        {
            //healthCounter--;
        }
    }

    public override void OnStartLocalPlayer()
    {
        //GetComponent<MeshRenderer>().material.color = Color.red;
    }

    private string generateHearth(int healthCounter)
    {
        string h = "";

        for (int i = 1; i <= healthCounter; i++)
        {
            h = h + "❤";
        }

        return h;
    }
}