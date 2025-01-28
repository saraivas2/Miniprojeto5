using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameras3_4 : MonoBehaviour
{
    [SerializeField] private Camera cam3;
    [SerializeField] private Camera cam4;

    private void Start()
    {
        cam3 = cam3.GetComponent<Camera>();
        cam4 = cam4.GetComponent<Camera>();
        ligarCamera3();

    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Alpha9))
        {
            ligarCamera3();
        }
        else if (Input.GetKey(KeyCode.Alpha0))
        {
            ligarCamera4();
        }

        if (Input.GetKey(KeyCode.U))
        {
            viewPortCam3();
            viewPortCam4();
            ligarCamera3();           
        }

        if (Input.GetKey(KeyCode.T))
        {
            DesligarCameras();
        }
        if (Input.GetKey(KeyCode.Y))
        {
            viewPortCam34();
            ligarCamera3();
            ligarCamera4();
        }
    }

    public void ligarCamera3()
    {
        cam3.enabled = true;
        cam4.enabled = false;
    }

    public void ligarCamera4()
    {
        cam3.enabled = false;
        cam4.enabled = true;
    }

    public void viewPortCam3()
    {
        cam3.rect = new Rect(0, 0, 1, 1);
    }

    public void DesligarCameras()
    {
        cam3.enabled = false;
        cam4.enabled = false;
    }

    public void viewPortCam4()
    {
        cam4.rect = new Rect(0, 0, 1, 1);
    }
    public void viewPortCam34()
    {
        cam3.rect = new Rect(0.5f, 0, 0.5f, 1);
        cam4.rect = new Rect(0.5f, 0, 0.5f, 1);
    }
}
