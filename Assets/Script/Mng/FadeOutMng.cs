using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOutMng : MonoBehaviour {

    public void FadeOut(GameObject Target)    
    {
        StartCoroutine(Fade(Target));
    }

    IEnumerator Fade(GameObject Target)
    {

        Color c = new Color(255,255,255);
        for (float f = 1f; f >= 0; f -= 0.1f)
        {
            c.a = f;
            Target.GetComponent<Image>().color = c;
            yield return null;
        }
        c.a = 0;
        Target.GetComponent<Image>().color = c;
        Target.SetActive(false);
    }


}
