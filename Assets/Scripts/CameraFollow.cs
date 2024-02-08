using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    //private Transform ballTransform;

    private Vector3 cameraDistance;

    private float lookUp;

    [SerializeField]
    private float lerpScale;

    void Start()
    {
        lookUp =-20;
        QualitySettings.vSyncCount = 1;
        Application.targetFrameRate = 75;
    }


    private void LateUpdate()
    {
         transform.position=Vector3.Lerp(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position + cameraDistance, lerpScale * Time.deltaTime);    //wektor wypadkowy
        //transform.position = GameObject.Find("Ball").transform.position + cameraDistance;     ustawienie pozycji kamery w XYZ i updatowanie jej
        transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform.position);       //patrz na obiekt
        transform.Rotate(lookUp, 0, 0);     //przekrêæ kamerê w osi x
    }


}
