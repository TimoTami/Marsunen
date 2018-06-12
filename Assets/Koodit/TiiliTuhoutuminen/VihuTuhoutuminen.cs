using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Tilemaps;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class VihuTuhoutuminen : MonoBehaviour
{


 
    public bool OnTuhoutunutVihu;
    public bool OnTuhoutunutVihu2;

    public GameObject VihuGameObject;
    public GameObject VihuGameObject2;
    
    public Vector3Int VihuHitInt;
    public Vector3Int VihuHitInt2;
    
    

    IEnumerator Odota(float Aika)
    {
        yield return new WaitForSeconds(Aika);

    }

    public static VihuTuhoutuminen Instance;
    void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        OnTuhoutunutVihu = true;
        OnTuhoutunutVihu2 = true;
    }

    public void OnCollisionEnter2D(Collision2D Vihucollision)
    {

        
        


        if ( VihuGameObject == Vihucollision.gameObject)
        {
            OnTuhoutunutVihu = false;

            foreach (ContactPoint2D hit in Vihucollision.contacts)
            {
                
                if (VihuLiikkuminen.Instance.VihuViimeliike == "alas" || VihuLiikkuminen.Instance.VihuViimeliike == "vasen")
                {
                    VihuHitInt = new Vector3Int((Mathf.RoundToInt(hit.point.x - 0.01f)), (Mathf.RoundToInt(hit.point.y - 0.01f)), 0);
                }
                else if (VihuLiikkuminen.Instance.VihuViimeliike == "ylös" || VihuLiikkuminen.Instance.VihuViimeliike == "oikea")
                {
                    VihuHitInt = new Vector3Int((Mathf.RoundToInt(hit.point.x + 0.01f)), (Mathf.RoundToInt(hit.point.y + 0.01f)), 0);
                }
               

                Tuhoutuminen.Instance.tilemap.SetTile(Tuhoutuminen.Instance.tilemap.WorldToCell(VihuHitInt), null);

                //if (Tuhoutuminen.Instance.tilemap.HasTile(Tuhoutuminen.Instance.tilemap.WorldToCell(VihuAiempiHitInt)) == false)
                //{
                //    se = "Kyllä";
                //}
                //if ((Tuhoutuminen.Instance.tilemap.WorldToCell(VihuAiempiHitInt)) == null)
                //{
                //    sekö = "Kyllä";
                //}

                //hit.point - 0.1f * hit.normal;

                if (Tuhoutuminen.Instance.tilemap.HasTile(Tuhoutuminen.Instance.tilemap.WorldToCell(VihuHitInt)) == false && VihuGameObject == Vihucollision.gameObject)
                {



                    if (VihuLiikkuminen.Instance.VihuViimeliike == "ylös")
                    {
                        VihuLiikkuminen.Instance.uusipaikka += new Vector3(0f, -0.5f, 0f);
                    }
                    else if (VihuLiikkuminen.Instance.VihuViimeliike == "alas")
                    {
                        VihuLiikkuminen.Instance.uusipaikka += new Vector3(0f, 0.5f, 0f);
                    }
                    else if (VihuLiikkuminen.Instance.VihuViimeliike == "vasen")
                    {
                        VihuLiikkuminen.Instance.uusipaikka += new Vector3(0.5f, 0f, 0f);
                    }
                    else if (VihuLiikkuminen.Instance.VihuViimeliike == "oikea")
                    {
                        VihuLiikkuminen.Instance.uusipaikka += new Vector3(-0.5f, 0f, 0f);
                    }



                    //VihuLiikkuminen.Instance.transform.position = Vector3.MoveTowards(VihuLiikkuminen.Instance.transform.position, VihuLiikkuminen.Instance.uusipaikka, Time.deltaTime * VihuLiikkuminen.Instance.vihuspeed);
                    VihuLiikkuminen.Instance.paikka = VihuLiikkuminen.Instance.uusipaikka;
                    VihuLiikkuminen.Instance.transform.position = VihuLiikkuminen.Instance.paikka;
                    VihuLiikkuminen.Instance.Uudestaan = true;
                    VihuLiikkuminen.Instance.vihuliikkunut = true;



                }
            }
        }
        if (VihuGameObject2 == Vihucollision.gameObject)
        {
            OnTuhoutunutVihu2 = false;

            foreach (ContactPoint2D hit in Vihucollision.contacts)
            {
                
                if (VihuLiikkuminenEiAgressiivinen.Instance.VihuViimeliike == "alas" || VihuLiikkuminenEiAgressiivinen.Instance.VihuViimeliike == "vasen")
                {
                    VihuHitInt2 = new Vector3Int((Mathf.RoundToInt(hit.point.x - 0.01f)), (Mathf.RoundToInt(hit.point.y - 0.01f)), 0);
                }
                else if (VihuLiikkuminenEiAgressiivinen.Instance.VihuViimeliike == "ylös" || VihuLiikkuminenEiAgressiivinen.Instance.VihuViimeliike == "oikea")
                {
                    VihuHitInt2 = new Vector3Int((Mathf.RoundToInt(hit.point.x + 0.01f)), (Mathf.RoundToInt(hit.point.y + 0.01f)), 0);
                }


                Tuhoutuminen.Instance.tilemap.SetTile(Tuhoutuminen.Instance.tilemap.WorldToCell(VihuHitInt2), null);

                //if (Tuhoutuminen.Instance.tilemap.HasTile(Tuhoutuminen.Instance.tilemap.WorldToCell(VihuAiempiHitInt)) == false)
                //{
                //    se = "Kyllä";
                //}
                //if ((Tuhoutuminen.Instance.tilemap.WorldToCell(VihuAiempiHitInt)) == null)
                //{
                //    sekö = "Kyllä";
                //}

                //hit.point - 0.1f * hit.normal;

                if (Tuhoutuminen.Instance.tilemap.HasTile(Tuhoutuminen.Instance.tilemap.WorldToCell(VihuHitInt2)) == false && VihuGameObject2 == Vihucollision.gameObject)
                {



                    if (VihuLiikkuminenEiAgressiivinen.Instance.VihuViimeliike == "ylös")
                    {
                        VihuLiikkuminenEiAgressiivinen.Instance.uusipaikka += new Vector3(0f, -0.5f, 0f);
                    }
                    else if (VihuLiikkuminenEiAgressiivinen.Instance.VihuViimeliike == "alas")
                    {
                        VihuLiikkuminenEiAgressiivinen.Instance.uusipaikka += new Vector3(0f, 0.5f, 0f);
                    }
                    else if (VihuLiikkuminenEiAgressiivinen.Instance.VihuViimeliike == "vasen")
                    {
                        VihuLiikkuminenEiAgressiivinen.Instance.uusipaikka += new Vector3(0.5f, 0f, 0f);
                    }
                    else if (VihuLiikkuminenEiAgressiivinen.Instance.VihuViimeliike == "oikea")
                    {
                        VihuLiikkuminenEiAgressiivinen.Instance.uusipaikka += new Vector3(-0.5f, 0f, 0f);
                    }



                    //VihuLiikkuminenEiAgressiivinen.Instance.transform.position = Vector3.MoveTowards(VihuLiikkuminenEiAgressiivinen.Instance.transform.position, VihuLiikkuminenEiAgressiivinen.Instance.uusipaikka, Time.deltaTime * VihuLiikkuminenEiAgressiivinen.Instance.vihuspeed);
                    VihuLiikkuminenEiAgressiivinen.Instance.paikka = VihuLiikkuminenEiAgressiivinen.Instance.uusipaikka;
                    VihuLiikkuminenEiAgressiivinen.Instance.transform.position = VihuLiikkuminenEiAgressiivinen.Instance.paikka;
                    VihuLiikkuminenEiAgressiivinen.Instance.vihuliikkunut = true;



                }
            }
        }

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (Tuhoutuminen.Instance.tilemap.HasTile(Tuhoutuminen.Instance.tilemap.WorldToCell(VihuHitInt)) == false && TuhoutuminenAlempiLayer.Instance.rikkitilemap.HasTile(TuhoutuminenAlempiLayer.Instance.rikkitilemap.WorldToCell(VihuHitInt)) == true)
        {

            OnTuhoutunutVihu = true;
        }
        if (Tuhoutuminen.Instance.tilemap.HasTile(Tuhoutuminen.Instance.tilemap.WorldToCell(VihuHitInt2)) == false && TuhoutuminenAlempiLayer.Instance.rikkitilemap.HasTile(TuhoutuminenAlempiLayer.Instance.rikkitilemap.WorldToCell(VihuHitInt2)) == true)
        {

            OnTuhoutunutVihu2 = true;
        }

    }

    //public void OnCollisionEnter2D(Collision2D Vihucollision)
    //{

    //    OnTuhoutunutVihu = false;

    //    if (Tuhoutuminen.Instance.tilemap.WorldToCell(VihuHitPosition) != null && VihuGameObject == Vihucollision.gameObject)
    //    {


    //        foreach (ContactPoint2D hit in Vihucollision.contacts)
    //        {
    //            VihuAiempiHitPosition = new Vector3Int((int)hit.point.x, (int)hit.point.y, 0);
    //            VihuHitPosition = Vector3.zero;
    //            VihuHitPosition.x = hit.point.x + 0.01f * hit.normal.x;
    //            VihuHitPosition.y = hit.point.y + 0.01f * hit.normal.y;

    //            if (VihuLiikkuminen.Instance.VihuViimeliike == "ylös")
    //            {
    //                VihuLiikkuminen.Instance.uusipaikka += new Vector3(0f, -0.5f, 0f);
    //            }
    //            else if (VihuLiikkuminen.Instance.VihuViimeliike == "alas")
    //            {
    //                VihuLiikkuminen.Instance.uusipaikka += new Vector3(0f, 0.5f, 0f);
    //            }
    //            else if (VihuLiikkuminen.Instance.VihuViimeliike == "vasen")
    //            {
    //                VihuLiikkuminen.Instance.uusipaikka += new Vector3(0.5f, 0f, 0f);
    //            }
    //            else if (VihuLiikkuminen.Instance.VihuViimeliike == "oikea")
    //            {
    //                VihuLiikkuminen.Instance.uusipaikka += new Vector3(-0.5f, 0f, 0f);
    //            }

    //            VihuLiikkuminen.Instance.transform.position = Vector3.MoveTowards(VihuLiikkuminen.Instance.transform.position, VihuLiikkuminen.Instance.uusipaikka, Time.deltaTime * VihuLiikkuminen.Instance.vihuspeed);
    //            VihuLiikkuminen.Instance.paikka = VihuLiikkuminen.Instance.uusipaikka;
    //            VihuLiikkuminen.Instance.transform.position = VihuLiikkuminen.Instance.paikka;
    //            StartCoroutine(Odota(1F));

    //        }
    //    }
    //}
    //private void OnCollisionExit2D(Collision2D Vihucollision)
    //{
    //    if (VihuGameObject == Vihucollision.gameObject)
    //    {
    //        Tuhoutuminen.Instance.tilemap.SetTile(Tuhoutuminen.Instance.tilemap.WorldToCell(VihuHitPosition), null);
    //        OnTuhoutunutVihu = true;
    //    }
    //}

}




