using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    [SerializeField] private Transform impact;
    [SerializeField] private Transform cannonBallPosition;
    private float cannonBallLife = 3f;
    private Transform bulletImpact;




    private void Awake() 
    {
        Destroy(gameObject, cannonBallLife);      
    }

    private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.CompareTag("Ground") || other.gameObject.CompareTag("Obstacles")) 
        {
            Destroy(this.gameObject);
            Debug.Log("Collision Ground");
            bulletImpact = Instantiate(impact, cannonBallPosition.transform.position, Quaternion.identity);
        } else {
        bulletImpact = Instantiate(impact, cannonBallPosition.transform.position, Quaternion.identity);
        Debug.Log("Collision");
        Destroy(other.gameObject);
        Destroy(this.gameObject);
        }
    }
}
