using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform enemyPrefab;
    [SerializeField] private int enemiesInWave;
    private float xPos;
    private float zPos;
    private int enemyCount;
    private float waitTime;


    private void Start() 
    {
        StartCoroutine(EnemySpawn());
    }

    IEnumerator EnemySpawn()
    {
        while(enemyCount < enemiesInWave)
        {
            xPos = Random.Range(-12, 15);
            //zPos = Random.Range(15, 20);
            waitTime = Random.Range(2, 5);
            Instantiate(enemyPrefab, new Vector3(xPos, transform.position.y, transform.position.z), Quaternion.identity);
            yield return new WaitForSeconds(waitTime);
            enemyCount++;
        }
    }
}
