using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBallImpact : MonoBehaviour
{
    //[SerializeField] private Transform cannonBallPosition;
    private float cannonBallLife = 3f;




    private void Awake() 
    {
        Destroy(gameObject, cannonBallLife);      
    }

    private void OnCollisionEnter(Collision other) 
    {
        Destroy(this.gameObject);
    }
}
