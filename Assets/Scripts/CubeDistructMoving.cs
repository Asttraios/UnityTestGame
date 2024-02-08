using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeDistructMoving : CubeDistruct
{
    [SerializeField] private Vector3 direction;
    [SerializeField] private bool turn;
    [SerializeField] private float speed;
    private Vector3 boxMoveDirecion;
    //private Vector3[] boxMoveDirecion;

    protected override void Start()
    {
        boxMoveDirecion = Vector3.left * speed;
        //turn = false;

        lifeCount = Mathf.Clamp(lifeCount, 5, maxLifeCount);        //czy to jest potrzebne?
        destructCubeMaterial = GetComponent<MeshRenderer>().material;
        SetStartMoveDirection();
    }

    // Update is called once per frame
    protected override void Update()
    {
        if (lifeCount == 0)
        {
            Destroy(gameObject);
        }
        else
        {
            SetColorIfHit();
        }
    }

    protected override void OnCollisionEnter(Collision cubeCollision)
    {
        if (cubeCollision.gameObject.CompareTag("Player"))
        {
            SetColorIfHit();
            AudioSource.PlayClipAtPoint(boxHitSound1, cubeCollision.contacts[0].point, 100.0f);
            lifeCount--;

        }

    }

    protected override void SetColorIfHit()
    {
        destructCubeMaterial.color = Color.Lerp(destructCubeStartColor, destructCubeEndColor, (float)(lifeCount - 1) / (float)(maxLifeCount - 1));
    }

    private void FixedUpdate()
    {
        Debug.DrawRay(transform.position, direction, Color.yellow);

        Ray ray = new Ray(transform.position, direction);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            //Debug.Log(hit.transform.gameObject.name);
            if (hit.transform.gameObject.CompareTag("Floor") || hit.transform.gameObject.CompareTag("Player"))
            {
                BoxMove();
            }
            else
            {
                ChangeBoxMoveDirection();
                BoxMove();
            }

        }
        else
        {
            ChangeBoxMoveDirection();
        }

    }

    private void BoxMove()
    {
        gameObject.GetComponent<Rigidbody>().velocity = boxMoveDirecion;
    }

    private void ChangeBoxMoveDirection()
    {
      
        boxMoveDirecion = -boxMoveDirecion; 
        direction.Set(-direction.x, direction.y, direction.z);
        
    }

    private void SetStartMoveDirection()
    {
        if(turn)
        {
            boxMoveDirecion = -boxMoveDirecion;
            direction.Set(-direction.x, direction.y, direction.z);
        }
    }

    /*
    private void RandomMoveDirecion()
    {
        boxMoveDirecion[0] = new Vector3(1 * speed, 0, 0);
        boxMoveDirecion[1] = new Vector3(-1 * speed, 0, 0);
        boxMoveDirecion[2] = new Vector3(0, 0, 1 * speed);
        boxMoveDirecion[3] = new Vector3(0, 0, -1 * speed);

    }
    */
}
