using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : NetworkBehaviour
{
    NetworkManager nm;

    public Text WaitLabel;

    private bool start;

    [SyncVar]
    public int player;

    [SyncVar]
    public bool gameStartet;
    public bool wand;
    public string playerName;

    public DateTime startTime;
    BoxCollider collider;

    private void Awake()
    {
        nm = FindObjectOfType<NetworkManager>();
        start = false;
        gameStartet = false;
    }

    private void Start()
    {
        WaitLabel = GameObject.Find("WartenLabel").GetComponent<Text>();
        wand = true;
        collider = GameObject.Find("StartWand").GetComponent<BoxCollider>();
    }

    void Update()
    {
        if (!start)
        {
            if (nm.numPlayers != 0)
            {
                player = nm.numPlayers;
            }

            if (player == 2)
            {
                start = true;
                gameStartet = true;
                StartCoroutine(PrintStartText());
            }
        }
    }

    IEnumerator PrintStartText()
    {
        WaitLabel.text = "Spiel starten in";
        yield return new WaitForSeconds(1);
        WaitLabel.text = "3";
        yield return new WaitForSeconds(1);
        WaitLabel.text = "2";
        yield return new WaitForSeconds(1);
        WaitLabel.text = "1";
        yield return new WaitForSeconds(1);
        WaitLabel.text = "Los gehts!";
        yield return new WaitForSeconds(1);
        WaitLabel.enabled = false;
        wand = false;

        startTime = DateTime.Now;

        Debug.Log(startTime);

        collider.enabled = false;
    }
}