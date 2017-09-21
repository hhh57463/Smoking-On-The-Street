using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour {


    public Hero HeroSc;
    public Sprite[] NpcSprite;
    public Sprite[] NpcDmgSprite;
    public SpriteRenderer NpcRend;
    int nRand;
    public bool bMove = false;
    public bool bNpcImageChanger = false;

	// Use this for initialization
	void Start () {

        NpcRend = GetComponent<SpriteRenderer>();
        nRand = Random.Range(0, 3);
        NpcSpriteRandom();

    }

    // Update is called once per frame
    void Update()
    {
        if (!HeroSc.bHeroDie)
        {
            Move();
            //NpcSpriteRandom();
        }
    }

    void Move()
    {
        if (bMove)
        {
            transform.Translate(Vector3.left * 3f * Time.deltaTime);
        }
        if (transform.localPosition.x <= -1.5f)
        {
            transform.localPosition = new Vector3(9f, 3.2f, 0f);
            gameObject.SetActive(false);
        }
    }

    public void NpcSpriteRandom()
    {
        if (bNpcImageChanger)
        {
            nRand = Random.Range(0, 3);
            bNpcImageChanger = false;
        }
        switch (nRand)
        {
            case 0:
                NpcRend.sprite = NpcSprite[0];
                break;
            case 1:
                NpcRend.sprite = NpcSprite[1];
                break;
            case 2:
                NpcRend.sprite = NpcSprite[2];
                break;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Hero"))
        {
            if (nRand == 0)
            {
                NpcRend.sprite = NpcDmgSprite[0];
            }
            if (nRand == 1)
            {
                NpcRend.sprite = NpcDmgSprite[1];
            }
            if (nRand == 2)
            {
                NpcRend.sprite = NpcDmgSprite[2];
            }
        }
    }
}
