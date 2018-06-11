using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TuhoutuminenTokaTasoAlempiLayer : MonoBehaviour {

    public GameObject PelaajaGameObject;
    public Tilemap rikkitilemap;
    public Vector3 PelaajaHitPosition1;
    public Vector3Int PelaajaHitPosition1Int;
    public string pelaajahit;

    public int tiilihealth;
    public string osunut;
    public string osunuttoinen;
    public static TuhoutuminenTokaTasoAlempiLayer Instance;
    void Awake()
    {
        Instance = this;
    }

    void Start()
    {

        {

            if (PelaajaGameObject != null)
            {

                rikkitilemap = GameObject.Find("IlmastointiRikkiTilemapTokaTaso").GetComponent<Tilemap>();


            }
        }
    }

    public void OnCollisionEnter2D(Collision2D collisionAlempi)
    {


        //if (Tuhoutuminen.Instance.tilemap.HasTile(Tuhoutuminen.Instance.tilemap.WorldToCell(PelaajaHitPosition1Int)) == true)

        //{
        //    Physics.IgnoreLayerCollision(16, 29);
        //    osunut = PelaajaHitPosition1Int.ToString();

        //}
        if (PelaajaGameObject == collisionAlempi.gameObject)
            foreach (ContactPoint2D hit in collisionAlempi.contacts)
            {

                if (LiikkuminenYksin.Instance.PelaajaViimeliike == "alas" || LiikkuminenYksin.Instance.PelaajaViimeliike == "vasen")
                {
                    PelaajaHitPosition1Int = new Vector3Int((Mathf.RoundToInt(hit.point.x - 0.01f)), (Mathf.RoundToInt(hit.point.y - 0.01f)), 0);
                }
                else if (LiikkuminenYksin.Instance.PelaajaViimeliike == "ylös" || LiikkuminenYksin.Instance.PelaajaViimeliike == "oikea")
                {
                    PelaajaHitPosition1Int = new Vector3Int((Mathf.RoundToInt(hit.point.x + 0.01f)), (Mathf.RoundToInt(hit.point.y + 0.01f)), 0);
                }


                osunuttoinen = "kyllä";




                if ((TuhoutuminenTokaTaso.Instance.tilemap.HasTile(TuhoutuminenTokaTaso.Instance.tilemap.WorldToCell(PelaajaHitPosition1Int)) == false) && TuhoutuminenTokaTaso.Instance.OnTuhoutunut == true && PelaajaGameObject == collisionAlempi.gameObject)
                {

                    if (LiikkuminenYksin.Instance.PelaajaViimeliike == "ylös")
                    {
                        LiikkuminenYksin.Instance.pos += new Vector3(0f, -0.5f, 0f);
                    }
                    else if (LiikkuminenYksin.Instance.PelaajaViimeliike == "alas")
                    {
                        LiikkuminenYksin.Instance.pos += new Vector3(0f, 0.5f, 0f);
                    }
                    else if (LiikkuminenYksin.Instance.PelaajaViimeliike == "vasen")
                    {
                        LiikkuminenYksin.Instance.pos += new Vector3(0.5f, 0f, 0f);
                    }
                    else if (LiikkuminenYksin.Instance.PelaajaViimeliike == "oikea")
                    {
                        LiikkuminenYksin.Instance.pos += new Vector3(-0.5f, 0f, 0f);
                    }

                    LiikkuminenYksin.Instance.transform.position = Vector3.MoveTowards(LiikkuminenYksin.Instance.transform.position, LiikkuminenYksin.Instance.pos, Time.deltaTime * LiikkuminenYksin.Instance.speed);
                    //RuutuLiikkuminen3.Instance.liikkunut = true;
                    //RuutuLiikkuminen3.Instance.RakettiBensa -=1;
                    tiilihealth -= 1;
                    rikkitilemap.SetTile(rikkitilemap.WorldToCell(PelaajaHitPosition1Int), null);
                    if (LiikkuminenYksin.Instance.Kypärä == true)
                    {
                        LiikkuminenYksin.Instance.KypäränHealth -= 1;
                    }
                    if (LiikkuminenYksin.Instance.Kypärä == false)
                    {
                        LiikkuminenYksin.Instance.PelaajanHealth -= 1;
                    }

                }
            }

    }
    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    if (rikkitilemap.WorldToCell(PelaajaHitPosition1) != null && Tuhoutuminen.Instance.tilemap.WorldToCell(PelaajaHitPosition1) == null)
    //    {

    //    }
    //}
}
