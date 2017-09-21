using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameMng : MonoBehaviour
{

    public float center_x;

    GameObject _Hero;

    Animator _Title;

    void Awake()
    {
        Screen.SetResolution(720, 1280, false);
    }

    public void StartTitle(Animator Title)
    {
        _Title = Title;
    }

    public void Start_center_Co_Y(GameObject Hero)
    {
        _Hero = Hero;
    }
    public void Start_Up_co(GameObject Target)
    {
        float Hire = 7;
        StartCoroutine(Move_Up(Target,Hire));
    }

    IEnumerator Move_center_X(GameObject Target, float center_x)
    {

        if (center_x < Target.transform.localPosition.x)
        {
            while (center_x <= Target.transform.localPosition.x)
            {
                Target.transform.Translate(Vector3.left * Time.deltaTime*3f);
                yield return null;
            }
        }
        else
        {
            while (center_x >= Target.transform.localPosition.x)
            {
                Target.transform.Translate(Vector3.right * Time.deltaTime * 3f);
                yield return null;
            }
        }
        
        Target.transform.localPosition = new Vector3(center_x,Target.transform.localPosition.y, Target.transform.localPosition.z);
    }

    IEnumerator Move_Up(GameObject Target,float Hire)
    {
        yield return StartCoroutine(Move_center_X(_Hero, center_x));

        _Title.SetTrigger("Up");
        float Top_y = Target.transform.localPosition.y+Hire;
        while (Top_y >= Target.transform.localPosition.y)
        {
            Target.transform.Translate(Vector3.up * Time.deltaTime * 3f);
            yield return null;
        }
        Target.transform.localPosition = new Vector3(Target.transform.localPosition.x, Top_y, Target.transform.localPosition.z);
    }

}