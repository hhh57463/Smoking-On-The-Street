using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{

    public CigarettesPopup CigaCs;
    public CameraShake CameraShakeSc;
    public LabelMng LabelSc;
    public Bar BarSc;
    public GameObject CigaGams;
    public bool bHeroDie = false;
    public Sprite[] DieSprite;
    public int nDieSpriteNum = 0;
    public Animator HeroAni;
    public GameObject ResultScene;
    SpriteRenderer Sr;
    bool bHateSet = false;


    void Start()
    {
        HeroAni = GetComponent<Animator>();
        Sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (bHeroDie)
        {
            HeroAni.enabled = false;
            StartCoroutine(Die());
            CigaCs.bHeroDieLoad = true;
            if (!bHateSet)
            {
                LabelSc.Hate();
                bHateSet = true;
            }
            if (transform.localPosition.y > 2.7f)
            {
                transform.Translate(Vector3.down * 2f * Time.deltaTime);
            }
        }
    }

    IEnumerator Die()
    {
        Sr.sprite = DieSprite[nDieSpriteNum];
        yield return new WaitForSeconds(0.3f);
        if (nDieSpriteNum <= 3)
        {
            nDieSpriteNum++;
            StartCoroutine(Die());
        }
        if (nDieSpriteNum == 4)
        {
            StartCoroutine(GameEnd());
        }
    }

    IEnumerator GameEnd()
    {
        yield return new WaitForSeconds(1f);
        ResultScene.transform.localPosition = Vector2.zero;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Store"))
        {
            CigaCs.bImageChange = true;
            CigaGams.transform.localPosition = Vector2.zero;
            Time.timeScale = 0;
            BarSc.bGageAccess = true;
            CameraShakeSc.bCameraShake = false;
            if (BarSc.fGage <= 0.0055f)
                BarSc.fGage += 0.0005f;
        }
    }

}
