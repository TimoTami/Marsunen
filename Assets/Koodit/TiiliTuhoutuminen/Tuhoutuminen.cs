using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Tilemaps;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class Tuhoutuminen : MonoBehaviour
{

    public bool OnTuhoutunut;
    public GameObject PelaajaGameObject;
    public Vector3 PelaajaHitPosition;
    public Vector3Int hitti;
    public Vector3Int PelaajaAiempiHitInt;
    public Tilemap tilemap;
    public string se;
    public string sekö;
    public string booliPäälle;

    public static Tuhoutuminen Instance;
    void Awake()
    {
        Instance = this;
    }

    
    void Start()
    {
        OnTuhoutunut = true;
            if (PelaajaGameObject != null)
            {
                this.tilemap = GameObject.Find("IlmastointiTilemap").GetComponent<Tilemap>();
                

            }
    }

    void Update()
    {
        //var tilePos = this.tilemap.WorldToCell(PelaajaHitPosition);
        //this.tilemap.SetTile(tilePos, null);
        //GridInformation.

      
    }



    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (PelaajaGameObject == collision.gameObject)
            OnTuhoutunut = false;
        

        if ( PelaajaGameObject == collision.gameObject)
        {


            foreach (ContactPoint2D hit in collision.contacts)
            {
                PelaajaHitPosition = new Vector3();
                if (RuutuLiikkuminen3.Instance.PelaajaViimeliike == "alas" || RuutuLiikkuminen3.Instance.PelaajaViimeliike == "vasen")
                {
                    PelaajaAiempiHitInt = new Vector3Int((Mathf.RoundToInt(hit.point.x - 0.01f)), (Mathf.RoundToInt(hit.point.y - 0.01f)), 0);
                }
                else if (RuutuLiikkuminen3.Instance.PelaajaViimeliike == "ylös" || RuutuLiikkuminen3.Instance.PelaajaViimeliike == "oikea")
                {
                    PelaajaAiempiHitInt = new Vector3Int((Mathf.RoundToInt(hit.point.x + 0.01f)), (Mathf.RoundToInt(hit.point.y + 0.01f)), 0);
                }
                    PelaajaHitPosition.x = hit.point.x + 0.1f * hit.normal.x;
                PelaajaHitPosition.y = hit.point.y + 0.1f * hit.normal.y;
                //tilemap.SetTile(PelaajaHitPosition null);
                hitti = new Vector3Int((int)-1.5f, (int)0.5f, 0);

                tilemap.SetTile(tilemap.WorldToCell(PelaajaAiempiHitInt), null);

                if (RuutuLiikkuminen3.Instance.Kypärä == true)
                {
                    RuutuLiikkuminen3.Instance.KypäränHealth -= 1;
                }
                if (RuutuLiikkuminen3.Instance.Kypärä == false)
                {
                    RuutuLiikkuminen3.Instance.PelaajanHealth -= 1;
                }

                if (tilemap.HasTile(tilemap.WorldToCell(PelaajaAiempiHitInt))==false)
                {
                    se = "Kyllä";
                }
                if ((tilemap.WorldToCell(PelaajaAiempiHitInt)) == null)
                {
                    sekö = "Kyllä";
                }

                //hit.point - 0.1f * hit.normal;

                if (tilemap.HasTile(tilemap.WorldToCell(PelaajaAiempiHitInt))==false && PelaajaGameObject == collision.gameObject)
                {
                    


                    if
                    (RuutuLiikkuminen3.Instance.PelaajaViimeliike == "ylös")
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
                    



                }
            }
        }
     
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (tilemap.HasTile(tilemap.WorldToCell(PelaajaAiempiHitInt)) == false && TuhoutuminenAlempiLayer.Instance.rikkitilemap.HasTile(TuhoutuminenAlempiLayer.Instance.rikkitilemap.WorldToCell(PelaajaAiempiHitInt)) == true)
        {

            OnTuhoutunut = true;
            booliPäälle = "Kyllä";
        }

    }


}



 
