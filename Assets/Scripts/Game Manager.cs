using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject PlayerBall;

    [SerializeField]
    private Transform playerPos;

    [SerializeField] private float timeLimit;
    [SerializeField] private float timeScale;
    [SerializeField] private TextMeshProUGUI timeLimitText;
    //[SerializeField] private TextMeshProUGUI slowMoLimittext;

    private SoundManager soundManager;
    [SerializeField] private AudioClip levelFinish;



    private void Awake()
    {
        Instantiate(PlayerBall, playerPos.position, Quaternion.identity);
    }

    private void Start()
    {
        soundManager = GameObject.FindGameObjectWithTag("SoundControl").GetComponent<SoundManager>();
        
    }

    private void Update()
    {
        GoToMenu();
        
        timeLimit = Mathf.Clamp(timeLimit, 0f, int.MaxValue);       //musi byæ w update zeby statle sprawdzalo
        timeLimit-=Time.deltaTime;
        timeLimitText.text = "Time: " + Mathf.CeilToInt(timeLimit).ToString();
    
        
        if (timeLimit>3)
        {
            timeLimitText.color = Color.white;
        }

        if(timeLimit<=3)
        {
            timeLimitText.color = new Color(1f, 0, 0);              //na razie nie mozna uzywac dwoch funkcji do manipulowania skalowaniem czasu, zbyt soebie przeszkadzaj¹
            //Time.timeScale = 0.5f;
        }
       
        if(timeLimit<=0)
        {
            LevelRestart();
            //Time.timeScale = 1f;
        }
        
    }

    public void LevelRestart()
    {
        soundManager.FinishTheme(levelFinish);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadLevel()
    {
        if(PlayerPrefs.GetInt("map", 1) < SceneManager.GetActiveScene().buildIndex+1)
        {
            PlayerPrefs.SetInt("map", SceneManager.GetActiveScene().buildIndex + 1);
        }
       
        
        if (SceneManager.sceneCountInBuildSettings > SceneManager.GetActiveScene().buildIndex + 1)
        {
            
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        }
        else
            SceneManager.LoadScene(0);
    }

   public void AddTimePowerUp()
    {
        timeLimit += 5f;
    }

    private void GoToMenu()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }

    public void LoadMenuButton()
    {
        SceneManager.LoadScene(0);
    }
}
