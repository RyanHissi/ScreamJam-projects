using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public float delaySeconds;
    public GameObject TVOn;
    public GameObject TVOff;
    public int sceneToLoad;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    public void pressStart()
    {
        StartCoroutine(gameStart());
    }

    public IEnumerator gameStart()
    {
        TVOff.SetActive(true);
        TVOn.SetActive(false);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(sceneToLoad);

    }

    public void quitGame()
    {
        Application.Quit();
    }
}
