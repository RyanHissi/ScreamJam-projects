using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    public GameObject intText;
    public bool interactable, toggle;
    public Animator doorAnim;
    public float doorOpenTime = 1f;
    public BoxCollider doorCollider;

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            intText.SetActive(true);
            interactable = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            intText.SetActive(false);
            interactable = false;
        }
    }
    void Update()
    {
        if (interactable == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                StartCoroutine(openDoor());
                /*
                
                toggle = !toggle;
                if (toggle == true)
                {
                    doorAnim.ResetTrigger("close");
                    doorAnim.SetTrigger("open");
                }
                if (toggle == false)
                {
                    doorAnim.ResetTrigger("open");
                    doorAnim.SetTrigger("close");
                }
                intText.SetActive(false);
                interactable = false;
                */
            }
        }
    }

    IEnumerator openDoor()
    {
        //opening door
        doorAnim.SetBool("openDoor", true);
        intText.SetActive(false);
        interactable = false;
        doorCollider.enabled = false;


        yield return new WaitForSeconds(doorOpenTime);
        doorAnim.SetBool("openDoor", false);
        intText.SetActive(true);
        interactable = true;
        yield return new WaitForSeconds(1);

        doorCollider.enabled = true;


    }
}

