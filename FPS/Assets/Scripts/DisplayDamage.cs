using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayDamage : MonoBehaviour
{
    [SerializeField] Canvas impactCanvas;
    [SerializeField] float impactTime = 0.3f;
    void Start()
    {
        impactCanvas.enabled = false;
    }

    void Update()
    {

    }
    public void ShowDamageImpact()
    {
        StartCoroutine(ShowImpact());
    }
    IEnumerator ShowImpact()
    {
        impactCanvas.enabled = true;
        yield return new WaitForSeconds(impactTime);
        impactCanvas.enabled = false;
    }
}
