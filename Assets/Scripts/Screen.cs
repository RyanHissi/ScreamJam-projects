using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screen : MonoBehaviour
{
    public GameObject intText;
    public bool interactable, toggle;
    public Animator ScreenAnim;

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
                toggle = !toggle;
                if (toggle == true)
                {
                    ScreenAnim.ResetTrigger("on");
                    ScreenAnim.SetTrigger("off");
                }
                if (toggle == false)
                {
                    ScreenAnim.ResetTrigger("off");
                    ScreenAnim.SetTrigger("on");
                }
                intText.SetActive(false);
                interactable = false;
            }
        }
    }
}

