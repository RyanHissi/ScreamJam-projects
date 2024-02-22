using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class obunga : MonoBehaviour
{
    public NavMeshAgent ai;
    public Transform player;
    Vector3 dest;


    public bool frozen;

    public GameObject jumpScare;

    void Update()
    {
        if (frozen)
        {
            ai.destination = this.gameObject.transform.position;
        }

        else
        {
            dest = player.position;
            ai.destination = dest;
        }

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            gameObject.transform.position = new Vector3(100,100,100);
            
            jumpScare.transform.parent.gameObject.SetActive(true);
            jumpScare.SetActive(true);
            Animator anim = jumpScare.GetComponent<Animator>();
            anim.SetTrigger("Jumpscare");
            StartCoroutine(gameOver());
        }

    }

    IEnumerator gameOver()
    {
        
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(2);
    }

}

