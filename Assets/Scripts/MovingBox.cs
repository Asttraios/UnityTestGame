using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBox : MonoBehaviour
{

    [SerializeField] private Vector3 direction;
    //[SerializeField] private bool turn;
    [SerializeField] private float speed;
    private Vector3 boxMoveDirecion;

    void Start()
    {
        boxMoveDirecion = new Vector3(speed, 0, 0);
        //turn = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Debug.DrawRay(transform.position, direction, Color.yellow);

        Ray ray = new Ray(transform.position, direction);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            //Debug.Log(hit.transform.gameObject.name);
            if(hit.transform.gameObject.CompareTag("Floor") || hit.transform.gameObject.CompareTag("Player"))
            {
                ChangeBoxMoveDirection();
                BoxMove();
            }
            else
            {
                BoxMove();
            }

        }
        else
        {
            //Debug.Log("Nic nie ma");
            BoxMove();
        }

    }

    private void BoxMove()
    {
        gameObject.GetComponent<Rigidbody>().velocity = boxMoveDirecion;
    }

    private void ChangeBoxMoveDirection()
    {
            speed = -speed;
    }
}
