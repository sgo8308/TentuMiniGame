using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseCamera : MonoBehaviour
{
    public Camera firstCamera;
    public Camera seconcamera;
    bool usemode;
    public Canvas canvas;
    void Start()
    {
        usemode = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (usemode)
            {
                usemode = false;
                canvas.gameObject.SetActive(true);
                seconcameraView();
            }
            else 
            {
                usemode = true;
                canvas.gameObject.SetActive(false);
                firstCameraView();
            }
        }
    }
    public void firstCameraView()
    {
        firstCamera.enabled = false;
        seconcamera.enabled = true;
    }

    public void seconcameraView()
    {
        firstCamera.enabled = true;
        seconcamera.enabled = false;
    }
}
