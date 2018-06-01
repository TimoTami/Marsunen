﻿using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Tilemaps;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class VihuTuhoutuminenAlempiLayer : MonoBehaviour
{




    public GameObject VihuGameObject;
    public Vector3 PelaajaHitPosition1;
    public Vector3Int PelaajaHitPosition1Int;
    public Vector3 VihuHitPosition1;
    public Vector3Int VihuHitPosition1Int;
    public int tiilihealth;
    public string osunut;

    public static VihuTuhoutuminenAlempiLayer Instance;

    void Awake()
    {
        Instance = this;
    }


    void Start()
    {
        if (VihuGameObject != null)
        {


            tiilihealth = 2;

        }
    }


    public void OnCollisionEnter2D(Collision2D VihucollisionAlempi)
    {



        //if (Tuhoutuminen.Instance.tilemap.HasTile(Tuhoutuminen.Instance.tilemap.WorldToCell(VihuHitPosition1Int)) == true)
        //{
        //    Physics.IgnoreLayerCollision(16, 28);
        //    osunut = "kyllä1";
        //}

        

            foreach (ContactPoint2D hit in VihucollisionAlempi.contacts)
            {
                
                if (VihuLiikkuminen.Instance.VihuViimeliike == "alas" || VihuLiikkuminen.Instance.VihuViimeliike == "vasen")
                {
                    VihuHitPosition1Int = new Vector3Int((Mathf.RoundToInt(hit.point.x - 0.01f)), (Mathf.RoundToInt(hit.point.y - 0.01f)), 0);
                }
                else if (VihuLiikkuminen.Instance.VihuViimeliike == "ylös" || VihuLiikkuminen.Instance.VihuViimeliike == "oikea")
                {
                    VihuHitPosition1Int = new Vector3Int((Mathf.RoundToInt(hit.point.x + 0.01f)), (Mathf.RoundToInt(hit.point.y + 0.01f)), 0);
                }


                if ((Tuhoutuminen.Instance.tilemap.HasTile(Tuhoutuminen.Instance.tilemap.WorldToCell(VihuHitPosition1Int)) == false) && VihuTuhoutuminen.Instance.OnTuhoutunutVihu == true && VihuGameObject == VihucollisionAlempi.gameObject)
                {
                    osunut = "ei1";



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
                    TuhoutuminenAlempiLayer.Instance.rikkitilemap.SetTile(TuhoutuminenAlempiLayer.Instance.rikkitilemap.WorldToCell(VihuHitPosition1Int), null);
                    VihuLiikkuminen.Instance.vihuliikkunut = true;
                }

            }
        

    }


    private void OnCollisionExit2D(Collision2D Vihucollision)
    {



    }


    //public void OnCollisionEnter2D(Collision2D VihucollisionAlempi)
    //{
    //    if (VihuTuhoutuminen.Instance.OnTuhoutunutVihu == true)
    //    {

    //        if (TuhoutuminenAlempiLayer.Instance.rikkitilemap.HasTile(VihuTuhoutuminen.Instance.VihuAiempiHitPosition) == true)
    //        {
    //            Physics.IgnoreLayerCollision(16, 28);
    //            osunut = "kyllä1";
    //        }

    //        else
    //        {

    //            if (TuhoutuminenAlempiLayer.Instance.rikkitilemap != null && VihuGameObject == VihucollisionAlempi.gameObject)
    //                VihuHitPosition1 = Vector3.zero;
    //            {
    //                foreach (ContactPoint2D hit in VihucollisionAlempi.contacts)
    //                {
    //                    VihuHitPosition1Int = new Vector3Int((int)hit.point.x, (int)hit.point.y, 0);
    //                    VihuHitPosition1.x = hit.point.x + 0.01f * hit.normal.x;
    //                    VihuHitPosition1.y = hit.point.y + 0.01f * hit.normal.y;


    //                    if (Tuhoutuminen.Instance.tilemap.HasTile(VihuHitPosition1Int) == false)
    //                    {
    //                        osunut = "ei1";



    //                        if (VihuLiikkuminen.Instance.VihuViimeliike == "ylös")
    //                        {
    //                            VihuLiikkuminen.Instance.uusipaikka += new Vector3(0f, -0.5f, 0f);
    //                        }
    //                        else if (VihuLiikkuminen.Instance.VihuViimeliike == "alas")
    //                        {
    //                            VihuLiikkuminen.Instance.uusipaikka += new Vector3(0f, 0.5f, 0f);
    //                        }
    //                        else if (VihuLiikkuminen.Instance.VihuViimeliike == "vasen")
    //                        {
    //                            VihuLiikkuminen.Instance.uusipaikka += new Vector3(0.5f, 0f, 0f);
    //                        }
    //                        else if (VihuLiikkuminen.Instance.VihuViimeliike == "oikea")
    //                        {
    //                            VihuLiikkuminen.Instance.uusipaikka += new Vector3(-0.5f, 0f, 0f);
    //                        }

    //                        VihuLiikkuminen.Instance.transform.position = Vector3.MoveTowards(VihuLiikkuminen.Instance.transform.position, VihuLiikkuminen.Instance.uusipaikka, Time.deltaTime * VihuLiikkuminen.Instance.vihuspeed);
    //                        VihuLiikkuminen.Instance.paikka = VihuLiikkuminen.Instance.uusipaikka;
    //                        VihuLiikkuminen.Instance.transform.position = VihuLiikkuminen.Instance.paikka;
    //                        TuhoutuminenAlempiLayer.Instance.rikkitilemap.SetTile(TuhoutuminenAlempiLayer.Instance.rikkitilemap.WorldToCell(VihuHitPosition1), null);
    //                    }

    //                }
    //            }

    //        }
    //    }
    //}
    //private void OnCollisionExit2D(Collision2D Vihucollision)
    //{



    //}

}



