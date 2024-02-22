using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class door : MonoBehaviour
{
    public GameObject intText;
    public bool interactable, toggle;
    //public Animator doorAnim;
    public float doorOpenTime = 1f;
    public BoxCollider doorCollider;
    public AudioSource aud;

    public GameObject doorTarget;



    private void Start()
    {
        aud = GetComponent<AudioSource>();
    }
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
        //Debug.Log(transform.parent);

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
        Debug.Log(transform.parent);

        //opening door -  this should be a tween
       // doorAnim.SetBool("openDoor", true);
        aud.Play();
        transform.DOLocalRotate(new Vector3(0, 90, 0), 1f).SetEase(Ease.OutBounce);


        
        intText.SetActive(false);
        interactable = false;
        doorCollider.enabled = false;


        yield return new WaitForSeconds(doorOpenTime);
        //doorAnim.SetBool("openDoor", false);

        transform.DOLocalRotate(new Vector3(0f, 0f, 0f), 1f).SetEase(Ease.OutBounce);

        //interactable = true;
        yield return new WaitForSeconds(1);

        doorCollider.enabled = true;


    }
}

