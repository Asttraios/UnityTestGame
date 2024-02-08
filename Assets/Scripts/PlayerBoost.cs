using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoost : MonoBehaviour 
{

    [SerializeField] private float forceMultiplier;
    Rigidbody rb;
    GameObject playerBoostText;
    private bool isKeyPressed=false;
    private bool isBoostActive = true;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerBoostText = GameObject.Find("BoostUI");
        ShowBoostText();
    }


    void Update()
    {
        Debug.Log(rb.velocity);
        ShowBoostText();
        if(Input.GetKeyDown(KeyCode.LeftShift) && isBoostActive && rb.velocity != Vector3.zero) {
        
            isKeyPressed = true;
            isBoostActive = false;
        
        }
        else
        {
            isKeyPressed = false;

        }
    }

    private void FixedUpdate()
    {
        if(isKeyPressed)
        {
            rb.AddForce(rb.velocity.normalized * forceMultiplier, ForceMode.Impulse);
            isKeyPressed=false;
            StartCoroutine(BoostCoroutine());
            
        }
        
    }

    IEnumerator BoostCoroutine() {

        yield return new WaitForSeconds(3f);
        isBoostActive = true;
        yield break;
    
    }

    private void ShowBoostText()
    {
        if (isBoostActive)
            playerBoostText.SetActive(true);
        else
            playerBoostText.SetActive(false);
    }


}


