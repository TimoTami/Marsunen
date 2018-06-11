using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteVaihtoTokaTaso : MonoBehaviour {

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


        if (LiikkuminenYksin.Instance.Kypärä == true)
        {
            spriteRenderer.sprite = MarsuSavuKypärä;
            if (LiikkuminenYksin.Instance.transform.position != LiikkuminenYksin.Instance.pos)
            {
                spriteRenderer.sprite = MarsuLiekkiKypärä;
            }
            if (LiikkuminenYksin.Instance.transform.position == LiikkuminenYksin.Instance.pos)
            {
                spriteRenderer.sprite = MarsuSavuKypärä;
            }

        }
        if (LiikkuminenYksin.Instance.Kypärä == false)
        {
            spriteRenderer.sprite = MarsuSavu;
            if (LiikkuminenYksin.Instance.transform.position != LiikkuminenYksin.Instance.pos)
            {
                spriteRenderer.sprite = MarsuLiekki;
            }
            if (LiikkuminenYksin.Instance.transform.position == LiikkuminenYksin.Instance.pos)
            {
                spriteRenderer.sprite = MarsuSavu;
            }
        }
    }
}
