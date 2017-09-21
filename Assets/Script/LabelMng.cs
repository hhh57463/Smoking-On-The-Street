using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LabelMng : MonoBehaviour {

    public CigarettesPopup CigaSc;
    public Text GameTimeText;
    public Text BestTimeText;
    public Text HateNameText;
    //public Image ResultHateImg;
    //public Sprite[] HateSprites;
    int nHateRandom;
    int BestTime;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        BestTime = PlayerPrefs.GetInt("HightScore");
        GameTimeText.text = CigaSc.nTimeCount.ToString();
        BestTimeText.text = BestTime.ToString();
        if (CigaSc.nTimeCount > BestTime)
        {
            PlayerPrefs.SetInt("HightScore", CigaSc.nTimeCount);
        }
	}

    public void Hate()
    {
        nHateRandom = Random.Range(0, 5);
        switch(nHateRandom)
        {
            case 0:
                //ResultHateImg.sprite = HateSprites[0];
                HateNameText.text = "폐암";
                break;

            case 1:
                //ResultHateImg.sprite = HateSprites[1];
                HateNameText.text = "후두암";
                break;

            case 2:
                //ResultHateImg.sprite = HateSprites[2];
                HateNameText.text = "식도암";
                break;

            case 3:
                //ResultHateImg.sprite = HateSprites[3];
                HateNameText.text = "심근경색";
                break;

            case 4:
                //ResultHateImg.sprite = HateSprites[4];
                HateNameText.text = "뇌졸중";
                break;
        }
    }

}
