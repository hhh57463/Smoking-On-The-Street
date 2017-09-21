using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store : MonoBehaviour {

    public Hero HeroSc;
    public bool bMoveDie = false;
    public SpriteRenderer StoreSr;
    public Sprite[] StoreSprite;

    void Start()
    {
        SpriteChange();
    }

    // Update is called once per frame
    void Update()
    {
        if (!HeroSc.bHeroDie)
        {
            Move();
        }
    }

    void Move()
    {
        if (bMoveDie)
        {
            transform.Translate(Vector3.left * 3f * Time.deltaTime);
        }
        if (transform.localPosition.x <= -1.5f)
        {
            SpriteChange();
            transform.localPosition = new Vector3(9f, 3.8f, 0f);
            gameObject.SetActive(false);
        }
    }

    void SpriteChange()
    {
        int nRand = Random.Range(0, 2);
        if (nRand == 0)
        {
            StoreSr.sprite = StoreSprite[0];
        }
        else if (nRand == 1)
        {
            StoreSr.sprite = StoreSprite[1];
        }
    }
}
