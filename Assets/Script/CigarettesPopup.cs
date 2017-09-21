using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CigarettesPopup : MonoBehaviour
{
    public Bar BarSc;

    public Store StoreSc;
    public NPC NpcSc;
    public Hero HeroSc;

    public bool bCigarettePopup = false;
    public bool bStoreMove = false;
    public bool bImageChange = false;
    public bool bHeroDieLoad = false;
    bool bFirstStart = false;
    bool bCameraPos = false;

    public Transform CameraDownPosTr;                    //카메라?가 일정 아래로 내려가면 팝업을 띄우게함
    float fTimeCheck;

    public GameObject NodeGams;
    public GameObject BarGams;

    public GameObject StoreGams;
    public GameObject NpcGams;

    Image Images;
    public Sprite[] CigaretteSprites;

    public int nCigaNum;
    public int nTimeCount = 0;

    // Use this for initialization

    void Awake()
    {
        Images = GetComponent<Image>();
        nCigaNum = Random.Range(0, 5);
    }

    void Start()
    {
        switch (nCigaNum)
        {
            case 0:
                Images.sprite = CigaretteSprites[0];
                break;
            case 1:
                Images.sprite = CigaretteSprites[1];
                break;
            case 2:
                Images.sprite = CigaretteSprites[2];
                break;
            case 3:
                Images.sprite = CigaretteSprites[3];
                break;
            case 4:
                Images.sprite = CigaretteSprites[4];
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        ImageChange();
        Ciga();
    }

    void Ciga()
    {
        if (bCigarettePopup && CameraDownPosTr.localPosition.y >= -4.9f)
        {
            transform.localPosition = Vector2.zero;
            Time.timeScale = 0;
        }
    }

    void ImageChange()
    {
        if (bImageChange)
        {
            nCigaNum = Random.Range(0, 5);
            bImageChange = false;
        }

        switch (nCigaNum)
        {
            case 0:
                Images.sprite = CigaretteSprites[0];
                break;
            case 1:
                Images.sprite = CigaretteSprites[1];
                break;
            case 2:
                Images.sprite = CigaretteSprites[2];
                break;
            case 3:
                Images.sprite = CigaretteSprites[3];
                break;
            case 4:
                Images.sprite = CigaretteSprites[4];
                break;
        }
    }

    IEnumerator Store()
    {
        yield return new WaitForSeconds(20f);

        StoreGams.SetActive(true);
        StoreSc.bMoveDie = true;
    }

    IEnumerator Npc()
    {
        yield return new WaitForSeconds(10f);
        NpcGams.SetActive(true);
        NpcSc.bNpcImageChanger = true;
        NpcSc.bMove = true;
        NpcSc.NpcSpriteRandom();
    }

    public IEnumerator TimeCount()
    {
        yield return new WaitForSeconds(1f);
        if (!bHeroDieLoad)
        {
            nTimeCount++;
            StartCoroutine(TimeCount());
        }
    }

    public void MenuStartBtn()
    {
        bCigarettePopup = true;
    }

    public void CigarettesBtn()
    {
        if (!HeroSc.bHeroDie)
        {
            StartCoroutine(Store());
            StartCoroutine(Npc());
        }
        Time.timeScale = 1;
        bCigarettePopup = false;
        transform.localPosition = new Vector2(800f, 0f); ;
        NodeGams.SetActive(true);
        BarGams.SetActive(true);
        BarSc.bGageAccess = false;
        if (!bFirstStart)
        {
            StartCoroutine(TimeCount());
            bFirstStart = true;
        }
    }

}
