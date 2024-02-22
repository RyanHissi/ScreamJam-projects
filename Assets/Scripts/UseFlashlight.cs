using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UseFlashlight : MonoBehaviour
{

    public Slider batterySlider;   
    public float batteryMax = 100f;
    public float batteryAmount;
    public float batteryDrainRate;
    public float batteryChargeRate;

    public GameObject lightObj;
    bool lightOn;
    bool canTurnOn;

    public obunga Zombie;




    // Start is called before the first frame update
    void Start()
    {
        batteryAmount = batteryMax;
        batterySlider.maxValue = batteryMax;
    }

    // Update is called once per frame
    void Update()
    {
        if(batteryAmount <= 0)
        {
            lightObj.SetActive(false);
            lightOn = false;
            Zombie.frozen = false;
            StartCoroutine(batteryCooldown());

        }

        else if(batteryAmount >= batteryMax) 
        { 
            batteryAmount = batteryMax;
        }
        //light on
        if (Input.GetMouseButtonDown(0) && batteryAmount >= 0 && canTurnOn)
        {

            lightObj.SetActive(true);
            lightOn = true;

        }
        if (Input.GetMouseButton(0) && batteryAmount >= 0)
        {
            batteryAmount -= batteryDrainRate * .01f;

        }

        //light off
        if (Input.GetMouseButtonUp(0))
        {
            lightObj.SetActive(false);
            lightOn = false;
            Zombie.frozen = false;


        }

        batteryAmount += batteryChargeRate * .01f;
        batterySlider.value = batteryAmount;




    }

    IEnumerator batteryCooldown()
    {
        canTurnOn = false;
        yield return new WaitForSeconds(5);
        canTurnOn = true;

    }
}
