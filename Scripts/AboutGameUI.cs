using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AboutGameUI : MonoBehaviour
{
    private void Awake() 
    {
        transform.Find("startGame").GetComponent<Button>().onClick.AddListener(() => {
            GameSceneManager.Load(GameSceneManager.Scene.MainMenuScene);
        });
    }
}
