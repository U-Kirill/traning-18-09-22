/*
    ███████╗██╗██████╗  ██████╗████████╗  ██████╗ ███████╗██████╗  ██████╗ █████╗ ███╗  ██╗
    ██╔════╝██║██╔══██╗██╔════╝╚══██╔══╝  ██╔══██╗██╔════╝██╔══██╗██╔════╝██╔══██╗████╗ ██║
    █████╗  ██║██████╔╝╚█████╗    ██║     ██████╔╝█████╗  ██████╔╝╚█████╗ ██║  ██║██╔██╗██║
    ██╔══╝  ██║██╔══██╗ ╚═══██╗   ██║     ██╔═══╝ ██╔══╝  ██╔══██╗ ╚═══██╗██║  ██║██║╚████║
    ██║     ██║██║  ██║██████╔╝   ██║     ██║     ███████╗██║  ██║██████╔╝╚█████╔╝██║ ╚███║
    ╚═╝     ╚═╝╚═╝  ╚═╝╚═════╝    ╚═╝     ╚═╝     ╚══════╝╚═╝  ╚═╝╚═════╝  ╚════╝ ╚═╝  ╚══╝

     █████╗  █████╗ ███╗   ███╗███████╗██████╗  █████╗ 
    ██╔══██╗██╔══██╗████╗ ████║██╔════╝██╔══██╗██╔══██╗
    ██║  ╚═╝███████║██╔████╔██║█████╗  ██████╔╝███████║
    ██║  ██╗██╔══██║██║╚██╔╝██║██╔══╝  ██╔══██╗██╔══██║
    ╚█████╔╝██║  ██║██║ ╚═╝ ██║███████╗██║  ██║██║  ██║
     ╚════╝ ╚═╝  ╚═╝╚═╝     ╚═╝╚══════╝╚═╝  ╚═╝╚═╝  ╚═╝

     █████╗  █████╗ ███╗  ██╗████████╗██████╗  █████╗ ██╗     ██╗     ███████╗██████╗ 
    ██╔══██╗██╔══██╗████╗ ██║╚══██╔══╝██╔══██╗██╔══██╗██║     ██║     ██╔════╝██╔══██╗
    ██║  ╚═╝██║  ██║██╔██╗██║   ██║   ██████╔╝██║  ██║██║     ██║     █████╗  ██████╔╝
    ██║  ██╗██║  ██║██║╚████║   ██║   ██╔══██╗██║  ██║██║     ██║     ██╔══╝  ██╔══██╗
    ╚█████╔╝╚█████╔╝██║ ╚███║   ██║   ██║  ██║╚█████╔╝███████╗███████╗███████╗██║  ██║
     ╚════╝  ╚════╝ ╚═╝  ╚══╝   ╚═╝   ╚═╝  ╚═╝ ╚════╝ ╚══════╝╚══════╝╚══════╝╚═╝  ╚═╝

    █▄▄ █▄█   ▀█▀ █ █ █▀▀   █▀▄ █▀▀ █ █ █▀▀ █   █▀█ █▀█ █▀▀ █▀█
    █▄█  █     █  █▀█ ██▄   █▄▀ ██▄ ▀▄▀ ██▄ █▄▄ █▄█ █▀▀ ██▄ █▀▄
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFPSC_FPSCamera : MonoBehaviour
{
    public static SFPSC_FPSCamera cam;

    public float sensitivity = 3;
    private Camera _cam;

    [HideInInspector]
    public float mouseX, mouseY;

    public float maxUpAngle = 80;
    public float maxDownAngle = -80;
    public Transform player;
    public Transform CameraPosition;
    
    private void Awake()
    {
        cam = this;
        _cam = Camera.main;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    
    private float rotX = 0.0f, rotY = 0.0f;
    [HideInInspector]
    public float rotZ = 0.0f;

    private bool _isControllAlowed = true;

    private void Update()
    {
        // Mouse input
        
        mouseX = Input.GetAxis("Mouse X") * sensitivity;
        mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        // Calculations
        rotX -= mouseY;
        rotX = Mathf.Clamp(rotX, maxDownAngle, maxUpAngle);
        rotY += mouseX;

        // Placing values
        _cam.transform.localRotation = _isControllAlowed
            ? Quaternion.Euler(rotX, rotY, rotZ) 
            : CameraPosition.localRotation;
        
        if(_isControllAlowed)
            player.Rotate(Vector3.up * mouseX);
        
        _cam.transform.position = CameraPosition.position;
    }

    public void DisableControll()
    {
        _isControllAlowed = false;
    }

    public void Shake(float magnitude, float duration)
    {
        StartCoroutine(IShake(magnitude, duration));
    }

    private IEnumerator IShake(float mag, float dur)
    {
        WaitForEndOfFrame wfeof = new WaitForEndOfFrame();
        for(float t = 0.0f; t <= dur; t += Time.deltaTime)
        {
            rotZ = Random.Range(-mag, mag) * (t / dur - 1.0f);
            yield return wfeof;
        }
        rotZ = 0.0f;
    }
}
