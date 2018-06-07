using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteVaihto : MonoBehaviour
{
    public Sprite MarsuSavu;
    public Sprite MarsuSavuKypärä;
    public Sprite MarsuLiekki;
    public Sprite MarsuLiekkiKypärä;
    private SpriteRenderer spriteRenderer;

    public void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (spriteRenderer.sprite == null)
        {
            spriteRenderer.sprite = MarsuSavu;
        }

    }

    public void Update()
    {
        

        if (RuutuLiikkuminen3.Instance.Kypärä == true)
        {
            spriteRenderer.sprite = MarsuSavuKypärä;
            if (RuutuLiikkuminen3.Instance.transform.position != RuutuLiikkuminen3.Instance.pos)
            {
                spriteRenderer.sprite = MarsuLiekkiKypärä;
            }
            if (RuutuLiikkuminen3.Instance.transform.position == RuutuLiikkuminen3.Instance.pos)
            {
                spriteRenderer.sprite = MarsuSavuKypärä;
            }

        }
        if (RuutuLiikkuminen3.Instance.Kypärä == false)
        {
            spriteRenderer.sprite = MarsuSavu;
            if (RuutuLiikkuminen3.Instance.transform.position != RuutuLiikkuminen3.Instance.pos)
            {
                spriteRenderer.sprite = MarsuLiekki;
            }
            if (RuutuLiikkuminen3.Instance.transform.position == RuutuLiikkuminen3.Instance.pos)
            {
                spriteRenderer.sprite = MarsuSavu;
            }
        }
    }
   
}