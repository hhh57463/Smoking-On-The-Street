using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{

    public GameObject Cam;
    public bool bCameraShake = false;
    public float fXCord;
    public float fYCord;
    public float fTime = 0.5f;
    public float fDeltaTime;
    public Vector3 CameraPosSave;

    void Start()
    {
        fTime = 0.5f;
        CameraPosSave = Cam.transform.localPosition;
    }

    void Update()
    {
        if (bCameraShake)
            Shake();
    }
    public void Shake()
    {
        fDeltaTime += Time.deltaTime;
        fXCord = Random.Range(3.5f, 3.7f);
        fYCord = Random.Range(-0.1f, 0.1f);
        Cam.transform.localPosition = new Vector3(fXCord, fYCord, CameraPosSave.z);
        if (fDeltaTime >= fTime)
        {
            bCameraShake = false;
            Cam.transform.position = CameraPosSave;
            fDeltaTime = Time.deltaTime;
        }
    }
}
