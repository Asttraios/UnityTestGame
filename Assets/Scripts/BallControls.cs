using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class BallControls : MonoBehaviour
{
    
    private float velocity { get; set; } = 1f;

    private float velocityMultiplier { get; set; } = 5f;

    private float vDirection;
    private float hDirection;

    private float newMaxAngularVelocity=16f;

    private Rigidbody propRB;
    private bool isRigidbody;

    GameManager gameManager;
   // PlayerAbilities abilities;
    
    void Start()
    {
       gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();        //musimy odszukaæ obiekt, "gameManager" to nie jest zwyk³y obiekt klasy
       //abilities = GetComponent<PlayerAbilities>();
        
        
        //abilities = new PlayerAbilities();
        //rb = GetComponent<Rigidbody>
        if(isRigidbody = TryGetComponent<Rigidbody>(out propRB))
        {
            Debug.Log(propRB.maxAngularVelocity);
            propRB.maxAngularVelocity = newMaxAngularVelocity;
        }
    }

    private void Update()
    {
        if(propRB.position.y<=-6)
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            gameManager.LevelRestart();
            Time.timeScale = 1f;
        }
        //abilities.SlowMo();
          

    }


    private void FixedUpdate()
    {
         if(isRigidbody&&(hDirection=Input.GetAxis("Horizontal"))!=0)
        {
            //transform.Translate(direction*velocity*velocityMultiplier, 0, 0, Space.World);

            //propRB.AddForce(direction * velocity * velocityMultiplier, 0, 0);

            propRB.AddTorque(0, 0, -hDirection * velocity * velocityMultiplier);
        }

        if (isRigidbody && (vDirection = Input.GetAxis("Vertical")) != 0)
        {
            propRB.AddTorque(vDirection * velocity * velocityMultiplier, 0, 0);
        }
    }
}
