using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TuhoutuminenTokaTaso : MonoBehaviour {

    public bool OnTuhoutunut;
    public GameObject PelaajaGameObject;
    public Vector3 PelaajaHitPosition;
    public Vector3Int hitti;
    public Vector3Int PelaajaAiempiHitInt;
    public Tilemap tilemap;
    public string se;
    public string sekö;
    public string booliPäälle;

    public static TuhoutuminenTokaTaso Instance;
    void Awake()
    {
        Instance = this;
    }


    void Start()
    {
        OnTuhoutunut = true;
        if (PelaajaGameObject != null)
        {
            tilemap = GameObject.Find("IlmastointiTilemapTokaTaso").GetComponent<Tilemap>();


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


        if (PelaajaGameObject == collision.gameObject)
        {


            foreach (ContactPoint2D hit in collision.contacts)
            {
                PelaajaHitPosition = new Vector3();
                if (LiikkuminenYksin.Instance.PelaajaViimeliike == "alas" || LiikkuminenYksin.Instance.PelaajaViimeliike == "vasen")
                {
                    PelaajaAiempiHitInt = new Vector3Int((Mathf.RoundToInt(hit.point.x - 0.01f)), (Mathf.RoundToInt(hit.point.y - 0.01f)), 0);
                }
                else if (LiikkuminenYksin.Instance.PelaajaViimeliike == "ylös" || LiikkuminenYksin.Instance.PelaajaViimeliike == "oikea")
                {
                    PelaajaAiempiHitInt = new Vector3Int((Mathf.RoundToInt(hit.point.x + 0.01f)), (Mathf.RoundToInt(hit.point.y + 0.01f)), 0);
                }
                
                

                tilemap.SetTile(tilemap.WorldToCell(PelaajaAiempiHitInt), null);

                if (LiikkuminenYksin.Instance.Kypärä == true)
                {
                    LiikkuminenYksin.Instance.KypäränHealth -= 1;
                }
                if (LiikkuminenYksin.Instance.Kypärä == false)
                {
                    LiikkuminenYksin.Instance.PelaajanHealth -= 1;
                }

                if (tilemap.HasTile(tilemap.WorldToCell(PelaajaAiempiHitInt)) == false)
                {
                    se = "Kyllä";
                }
                if ((tilemap.WorldToCell(PelaajaAiempiHitInt)) == null)
                {
                    sekö = "Kyllä";
                }

                //hit.point - 0.1f * hit.normal;

                if (tilemap.HasTile(tilemap.WorldToCell(PelaajaAiempiHitInt)) == false && PelaajaGameObject == collision.gameObject)
                {



                    if
                    (LiikkuminenYksin.Instance.PelaajaViimeliike == "ylös")
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
                    else if (RuutuLiikkuminen3.Instance.PelaajaViimeliike == "oikea")
                    {
                        LiikkuminenYksin.Instance.pos += new Vector3(-0.5f, 0f, 0f);
                    }

                    LiikkuminenYksin.Instance.transform.position = Vector3.MoveTowards(LiikkuminenYksin.Instance.transform.position, LiikkuminenYksin.Instance.pos, Time.deltaTime * LiikkuminenYksin.Instance.speed);
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
