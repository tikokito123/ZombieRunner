using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    [SerializeField] float lightDecay = 0.1f;
    [SerializeField] float angelDecay = 1f;
    [SerializeField] float minimunAngel = 40f;
    Light myLight;
    void Start()
    {
        myLight = GetComponent<Light>();
    }
    void Update()
    {
        DecreaseLightAngel();
        DecreaseLightDecay();
    }

    public void RestoreAngel(float restoreAngel)
    {
        myLight.spotAngle = restoreAngel;
    }
    public void RestoreLightIntensity(float restoreIntensity)
    {
        myLight.intensity += restoreIntensity;
    }
    private void DecreaseLightAngel()
    {
        if (myLight.spotAngle > minimunAngel)
        {
            myLight.spotAngle -= angelDecay * Time.deltaTime;
        }
        else
        {
            return; 
        }
    }
    private void DecreaseLightDecay()
    {
        myLight.intensity -= lightDecay * Time.deltaTime;
    }
}
