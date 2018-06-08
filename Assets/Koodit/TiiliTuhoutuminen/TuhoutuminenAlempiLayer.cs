using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Tilemaps;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class TuhoutuminenAlempiLayer : MonoBehaviour
{


 
    public GameObject PelaajaGameObject;
    public Tilemap rikkitilemap;
    public Vector3 PelaajaHitPosition1;
    public Vector3Int PelaajaHitPosition1Int;
    public string pelaajahit;
    
    public int tiilihealth;
    public string osunut;
    public string osunuttoinen;
    public static TuhoutuminenAlempiLayer Instance;
    void Awake()
    {
        Instance = this;
    }
    
    void Start()
    {

        {
           
            if (PelaajaGameObject != null)
            {
                
                rikkitilemap = GameObject.Find("IlmastointiRikkiTilemap").GetComponent<Tilemap>();
                tiilihealth = 2;

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
        if(PelaajaGameObject==collisionAlempi.gameObject)
            foreach (ContactPoint2D hit in collisionAlempi.contacts)
            {
                 
                if (RuutuLiikkuminen3.Instance.PelaajaViimeliike == "alas" || RuutuLiikkuminen3.Instance.PelaajaViimeliike == "vasen")
                {
                    PelaajaHitPosition1Int = new Vector3Int((Mathf.RoundToInt(hit.point.x - 0.01f)), (Mathf.RoundToInt(hit.point.y - 0.01f)), 0);
                }
                else if (RuutuLiikkuminen3.Instance.PelaajaViimeliike == "ylös" || RuutuLiikkuminen3.Instance.PelaajaViimeliike == "oikea")
                {
                    PelaajaHitPosition1Int = new Vector3Int((Mathf.RoundToInt(hit.point.x + 0.01f)), (Mathf.RoundToInt(hit.point.y + 0.01f)), 0);
                }

                
                osunuttoinen = "kyllä";
                



                if ((Tuhoutuminen.Instance.tilemap.HasTile(Tuhoutuminen.Instance.tilemap.WorldToCell(PelaajaHitPosition1Int)) == false) && Tuhoutuminen.Instance.OnTuhoutunut == true && PelaajaGameObject == collisionAlempi.gameObject)
                {

                    if (RuutuLiikkuminen3.Instance.PelaajaViimeliike == "ylös")
                    {
                        RuutuLiikkuminen3.Instance.pos += new Vector3(0f, -0.5f, 0f);
                    }
                    else if (RuutuLiikkuminen3.Instance.PelaajaViimeliike == "alas")
                    {
                        RuutuLiikkuminen3.Instance.pos += new Vector3(0f, 0.5f, 0f);
                    }
                    else if (RuutuLiikkuminen3.Instance.PelaajaViimeliike == "vasen")
                    {
                        RuutuLiikkuminen3.Instance.pos += new Vector3(0.5f, 0f, 0f);
                    }
                    else if (RuutuLiikkuminen3.Instance.PelaajaViimeliike == "oikea")
                    {
                        RuutuLiikkuminen3.Instance.pos += new Vector3(-0.5f, 0f, 0f);
                    }

                    RuutuLiikkuminen3.Instance.transform.position = Vector3.MoveTowards(RuutuLiikkuminen3.Instance.transform.position, RuutuLiikkuminen3.Instance.pos, Time.deltaTime * RuutuLiikkuminen3.Instance.speed);
                    //RuutuLiikkuminen3.Instance.liikkunut = true;
                    RuutuLiikkuminen3.Instance.RakettiBensa -=1;
                    tiilihealth -= 1;
                    rikkitilemap.SetTile(rikkitilemap.WorldToCell(PelaajaHitPosition1Int), null);
                if (RuutuLiikkuminen3.Instance.Kypärä == true)
                {
                    RuutuLiikkuminen3.Instance.KypäränHealth -= 1;
                }
                if (RuutuLiikkuminen3.Instance.Kypärä == false)
                {
                    RuutuLiikkuminen3.Instance.PelaajanHealth -= 1;
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




