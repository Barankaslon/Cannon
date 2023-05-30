using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] private LifeCounter lifeCounter;
    void OnCollisionEnter(Collision other)
    {
        Debug.Log("Collision Finish");
        Destroy(other.gameObject);
        lifeCounter.UpdateLives();
    }
}
