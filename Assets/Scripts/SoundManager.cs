using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(AudioSource))]

public class SoundManager : MonoBehaviour
{
    private AudioSource soundSource;
   [SerializeField] private AudioClip[] PowerUpSound;



    private void Awake()
    {
        if(GameObject.FindGameObjectsWithTag("SoundControl").Length > 1)
        {
            Destroy(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        soundSource = GetComponent<AudioSource>(); 
        soundSource.loop = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void PowerUpSoundRandomAndPlay()
    {
        soundSource.clip = PowerUpSound[Random.Range(0, PowerUpSound.Length)];
        soundSource.Play();
        
    }

    public void FinishTheme(AudioClip levelFinish)
    {
        soundSource.clip = levelFinish;
        soundSource.Play();
    }

}


