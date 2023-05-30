using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField] private Transform cannonBallSpawnPoint;
    [SerializeField] private GameObject cannonBallPrefab;
    [SerializeField] private float speed = 10f;
    //[SerializeField] Transform cannonTower;
    [SerializeField] private Transform cannon;
    [SerializeField] private TrajectoryRenderer trajectoryRenderer;
    [SerializeField] private Material redColorMaterial;
    [SerializeField] private Material whiteColorMaterial;

    private bool canShoot;
    private float rotationSpeed = 1f;
    private float timer;
    private float timerMax = 2;

    private void Start() 
    {
        canShoot = true;
    }

    private void Update() {

        float HorizontalRotation = Input.GetAxis("Horizontal");
        float VerticalRotation = Input.GetAxis("Vertical");

        transform.Rotate(0, HorizontalRotation * rotationSpeed, 0);
        cannon.transform.Rotate(-VerticalRotation * rotationSpeed, 0, 0);

        trajectoryRenderer.ShowTrajectoryLine(cannonBallSpawnPoint.position, cannonBallSpawnPoint.forward * speed);


        if(Input.GetKeyDown(KeyCode.Space) && canShoot) 
        {
            GameObject bullet = Instantiate(cannonBallPrefab, cannonBallSpawnPoint.position, cannonBallSpawnPoint.rotation);
            bullet.GetComponent<Rigidbody>().velocity = cannonBallSpawnPoint.forward * speed;
            canShoot = false;
            cannon.GetComponent<Renderer>().material = redColorMaterial;
            //ShootTimer();
            Invoke("ShootTimer", 2);
        }
    }



    public void ShootTimer () 
    {
            canShoot = true;
            cannon.GetComponent<MeshRenderer>().material = whiteColorMaterial;
            Debug.Log("canShoot");
    }
}
