using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] Camera FOV;
    [SerializeField] float zoomInFOV = 30f;
    [SerializeField] float zoomOutFOV = 60f;
    [SerializeField] float zoomInSen = 0.5f;
    [SerializeField] float zoomOutSen = 2f;
    RigidbodyFirstPersonController mouseSen;
    private void Update()
    {
        Aim();
    }
    private void Start()
    {
        mouseSen = GetComponentInParent<RigidbodyFirstPersonController>();
    }
    void Aim()
    {
        if (Input.GetMouseButton(1))
        {
            FOV.fieldOfView = zoomInFOV;
            mouseSen.mouseLook.XSensitivity = zoomInSen;
            mouseSen.mouseLook.YSensitivity = zoomInSen;
        }
        else
        {
            FOV.fieldOfView = zoomOutFOV;
            mouseSen.mouseLook.XSensitivity = zoomOutSen;
            mouseSen.mouseLook.YSensitivity = zoomOutSen;
        }
    }
}
