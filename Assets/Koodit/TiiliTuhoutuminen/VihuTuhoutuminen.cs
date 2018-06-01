using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Tilemaps;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class VihuTuhoutuminen : MonoBehaviour
{


 
    public bool OnTuhoutunutVihu;
    
    public GameObject VihuGameObject;
    public Vector3 PelaajaHitPosition;
    public Vector3Int VihuAiempiHitInt;
    public Vector3 VihuHitPosition;
    public Vector3Int VihuAiempiHitPosition;

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
        
    }

    public void OnCollisionEnter2D(Collision2D Vihucollision)
    {

        OnTuhoutunutVihu = false;


        if ( VihuGameObject == Vihucollision.gameObject)
        {


            foreach (ContactPoint2D hit in Vihucollision.contacts)
            {
                PelaajaHitPosition = new Vector3();
                if (VihuLiikkuminen.Instance.VihuViimeliike == "alas" || VihuLiikkuminen.Instance.VihuViimeliike == "vasen")
                {
                    VihuAiempiHitInt = new Vector3Int((Mathf.RoundToInt(hit.point.x - 0.01f)), (Mathf.RoundToInt(hit.point.y - 0.01f)), 0);
                }
                else if (VihuLiikkuminen.Instance.VihuViimeliike == "ylös" || VihuLiikkuminen.Instance.VihuViimeliike == "oikea")
                {
                    VihuAiempiHitInt = new Vector3Int((Mathf.RoundToInt(hit.point.x + 0.01f)), (Mathf.RoundToInt(hit.point.y + 0.01f)), 0);
                }
               

                Tuhoutuminen.Instance.tilemap.SetTile(Tuhoutuminen.Instance.tilemap.WorldToCell(VihuAiempiHitInt), null);

                //if (Tuhoutuminen.Instance.tilemap.HasTile(Tuhoutuminen.Instance.tilemap.WorldToCell(VihuAiempiHitInt)) == false)
                //{
                //    se = "Kyllä";
                //}
                //if ((Tuhoutuminen.Instance.tilemap.WorldToCell(VihuAiempiHitInt)) == null)
                //{
                //    sekö = "Kyllä";
                //}

                //hit.point - 0.1f * hit.normal;

                if (Tuhoutuminen.Instance.tilemap.HasTile(Tuhoutuminen.Instance.tilemap.WorldToCell(VihuAiempiHitInt)) == false && VihuGameObject == Vihucollision.gameObject)
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

                    

                    VihuLiikkuminen.Instance.transform.position = Vector3.MoveTowards(VihuLiikkuminen.Instance.transform.position, VihuLiikkuminen.Instance.uusipaikka, Time.deltaTime * VihuLiikkuminen.Instance.vihuspeed);
                    VihuLiikkuminen.Instance.paikka = VihuLiikkuminen.Instance.uusipaikka;
                    VihuLiikkuminen.Instance.transform.position = VihuLiikkuminen.Instance.paikka;
                    VihuLiikkuminen.Instance.vihuliikkunut = true;



                }
            }
        }

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (Tuhoutuminen.Instance.tilemap.HasTile(Tuhoutuminen.Instance.tilemap.WorldToCell(VihuAiempiHitInt)) == false && TuhoutuminenAlempiLayer.Instance.rikkitilemap.HasTile(TuhoutuminenAlempiLayer.Instance.rikkitilemap.WorldToCell(VihuAiempiHitInt)) == true)
        {

            OnTuhoutunutVihu = true;
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




