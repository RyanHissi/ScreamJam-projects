using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public int screensTurned = 0;
    public int winScene;
    public bool seenIntro;

    private void Update()
    {
        if(screensTurned >= 3) {
            screensTurned = 0;

            SceneManager.LoadScene(winScene); 
            // Debug.Log("You win!");
        }
    }


}
