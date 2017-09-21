using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneMng : MonoBehaviour
{

    public Hero HeroSc;

    public float StartXPos;
    public float EndXPos;
    public float Speed;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (!HeroSc.bHeroDie)
        {
            transform.Translate(Vector3.left * Speed * Time.deltaTime);

            if (transform.localPosition.x <= EndXPos)
            {
                transform.localPosition = new Vector3(StartXPos, transform.localPosition.y, 0);
            }
        }
    }
}