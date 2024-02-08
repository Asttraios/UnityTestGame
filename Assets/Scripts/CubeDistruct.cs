using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeDistruct : MonoBehaviour
{

   // protected GameObject destructCube;          niepotrzebne poniewaz skrypt jest uzywany bezposrednio przez ten obiekt, na wlasny uzytek i dotyczy tylko jego
    protected Material destructCubeMaterial;
    protected PhysicMaterial destructCubePhysMat;
    protected Rigidbody destructCubeRigid;
   [SerializeField] protected bool isRigidBody =false;

    [SerializeField] protected Color destructCubeStartColor;
    [SerializeField] protected Color destructCubeEndColor;
    [SerializeField] protected AudioClip boxHitSound1;
    protected Color destructCubeCurrentCol;

    [SerializeField] protected int lifeCount;
    protected int maxLifeCount = 5;



    virtual protected void Start()
    {
        lifeCount = Mathf.Clamp(lifeCount, 5, maxLifeCount);        //czy to jest potrzebne?
        destructCubeMaterial = GetComponent<MeshRenderer>().material;
        
        destructCubePhysMat = GetComponent<BoxCollider>().material;
        destructCubePhysMat.staticFriction = 0.5f;
        destructCubePhysMat.dynamicFriction = 0.5f;
        destructCubePhysMat.bounciness = 0.05f;

        

        if(isRigidBody)
        {
            destructCubeRigid = gameObject.AddComponent<Rigidbody>();
            destructCubeRigid.mass = 0.1f;
            destructCubeRigid.interpolation = RigidbodyInterpolation.Interpolate;
            destructCubeRigid.collisionDetectionMode = CollisionDetectionMode.Continuous;

        }
     


    }

    // Update is called once per frame
    virtual protected void Update()
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

    virtual protected void OnCollisionEnter(Collision cubeCollision)
    {
        if (cubeCollision.gameObject.CompareTag("Player"))
        {
            SetColorIfHit();
            AudioSource.PlayClipAtPoint(boxHitSound1, cubeCollision.contacts[0].point, 100.0f);
            lifeCount--;

        }
           
    }

    virtual protected void SetColorIfHit()
    {
        destructCubeMaterial.color=Color.Lerp(destructCubeStartColor, destructCubeEndColor, (float)(lifeCount - 1) / (float)(maxLifeCount - 1));
    }
}
