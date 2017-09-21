using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bar : MonoBehaviour
{
    public bool bGageAccess = false;
    public Vector3 GageVec3;
    public GameObject BarGams;
    public Hero HeroSc;
    public float fGage;

    // Use this for initialization
    void Start()
    {
        GageVec3 = transform.localScale;
        fGage = 0.0005f;
    }

    // Update is called once per frame
    void Update()
    {
        BarGage();
    }

    void BarGage()
    {
        if (!bGageAccess && transform.localScale.y <= 2.25)
        {
            GageVec3.y += fGage;
        }
        if (transform.localScale.y >= 2.25)
        {
            bGageAccess = true;
            HeroSc.bHeroDie = true;
        }
        transform.localScale = GageVec3;
    }
}
