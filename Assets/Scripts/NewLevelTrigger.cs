using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;


public class Respawn : MonoBehaviour
{

    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            gameManager.LoadLevel();
        }
    }



}
