using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class textShow : MonoBehaviour
{
    public GameObject[] lines;
    public GameObject finalLine;
    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.instance.seenIntro = false)
        {
            StartCoroutine(introText());
            Debug.Log("Intro Playing");
        }
      //  else if(GameManager.instance.seenIntro = true)
     //   {
       //     Debug.Log("Intro skipped");

     //       this.gameObject.SetActive(false);

      //  }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator introText()
    {
        foreach(GameObject line in lines)
        {
            line.SetActive(true);

            yield return new WaitForSeconds(1f);
        }

        foreach (GameObject line in lines)
        {
            line.SetActive(false);
        }

            finalLine.SetActive(true);
            yield return new WaitForSeconds(2);
            this.transform.DOScaleY(0, .3f);
            GameManager.instance.seenIntro = true;


    }
}
