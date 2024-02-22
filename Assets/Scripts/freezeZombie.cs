using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class freezeZombie : MonoBehaviour
{
    public obunga Zombie;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {
            if(hit.collider.gameObject.tag == "Zombie")
            {
                //obunga zombie = hit.collider.gameObject.GetComponent<obunga>();
                Zombie.frozen = true;

            }
        }

        else
        {
            Zombie.frozen = false;

        }


        //hit.
    }
}
