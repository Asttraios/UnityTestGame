using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(AudioSource))]

public class TimePowerUp : MonoBehaviour
{

    private GameManager gameManager;
    private SoundManager soundManager;
    [SerializeField] private GameObject powerUpParticle;

    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        soundManager = GameObject.FindGameObjectWithTag("SoundControl").GetComponent<SoundManager>();
        //soundManager.GetComponent<AudioSource>();
    }

    void Update()
    {
   
    }

    private void OnTriggerEnter(Collider powercoin)
    {
        if (powercoin.gameObject.CompareTag("Player"))
        {
            soundManager.PowerUpSoundRandomAndPlay();
            gameManager.AddTimePowerUp();
            Instantiate(powerUpParticle, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
