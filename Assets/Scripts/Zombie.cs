using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class obunga : MonoBehaviour
{
    public Animator anim;
    public NavMeshAgent ai;
    public Transform player;
    Vector3 dest;


    public bool frozen;
    bool held;

    public GameObject jumpScare;


    private void Start()
    {
        held = true;
        StartCoroutine(startHold());
    }
    void Update()
    {
        if (frozen || held)
        {
            ai.destination = this.gameObject.transform.position;
            anim.SetBool("Frozen", true);
        }

        else
        {
            dest = player.position;
            ai.destination = dest;
            anim.SetBool("Frozen", false);

        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            gameObject.transform.position = new Vector3(100,100,100);

            jumpScare.SetActive(true);
            jumpScare.transform.DOLocalMoveY(-2.67f, .3f);

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

    IEnumerator startHold()
    {
        yield return new WaitForSeconds(20);
        Debug.Log("Zombie active");
        held = false;
    }

}

