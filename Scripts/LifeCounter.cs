using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LifeCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI lifeCounterText;
    [SerializeField] private int currentLives;


    private void Start()
    {
        currentLives = 3;
    }

    private void Update() 
    {
        lifeCounterText.SetText("Lives: " + currentLives.ToString());
    }

    public void UpdateLives() 
    {
        if(currentLives > 0)
        {
            currentLives -= 1;
        } else {
            GameOverUI.Instance.Show();
        }
    }
}
