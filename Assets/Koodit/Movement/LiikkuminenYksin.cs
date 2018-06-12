using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LiikkuminenYksin : MonoBehaviour {

    public int RakettiBensa;
    public bool Kypärä;
    public int KypäränHealth;
    public bool liikkunut;
    public int PelaajanHealth;
    public bool Hitsaus;
    public int HitsausHealth;
    public string PelaajaViimeliike;
    public string l;
    public Vector3 pos;
    public Vector3Int PosInt;
    public float speed = 1;
    AudioSource RakettiÄäni;

    //public Tile RikkiTiili;
    //public Tile Tiili;

    //public float Viive = 1f;
    //private float AikaaKulunut = 0f;

    public static LiikkuminenYksin Instance;


    void Awake()
    {
        //SceneManager.LoadScene("HamsteriScene");
        Instance = this;
    }

    public void Start()
    {
        RakettiÄäni = GetComponent<AudioSource>();
        RakettiBensa = 200;
        PelaajanHealth = 40;
        liikkunut = false;
        pos = transform.position;          // Take the initial position

        

    }

    public void Update()
    {
        //AikaaKulunut += Time.deltaTime;
        if (PelaajanHealth <= 0 || RakettiBensa <= 0)
        {
            SceneManager.LoadScene("1TasoMarsu");
            //Application.LoadLevel(Application.loadedLevel);
        }
        //if (Kypärä == true)
        //{

        //    if (KypäränHealth <= 0)
        //    {
        //        Kypärä = false;
        //    }
        //}
        if (KypäränHealth <= 0)
        {
            Kypärä = false;
        }
        if (HitsausHealth <= 0)
        {
            Hitsaus = false;
        }
    }
    public void FixedUpdate()
    {
        liikkunut = false;


        
        if (transform.position == pos)
        {
            //if ((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow)) && AikaaKulunut >= Viive)
            //{

            //    AikaaKulunut = 0f;

            //    if (Hitsaus == true && Input.GetKey(KeyCode.LeftArrow))
            //    {
            //        TuhoutuminenAlempiLayer.Instance.rikkitilemap.SetTile(TuhoutuminenAlempiLayer.Instance.rikkitilemap.WorldToCell(pos + new Vector3(-1, 0, 0)), RikkiTiili);
            //        Tuhoutuminen.Instance.tilemap.SetTile(Tuhoutuminen.Instance.tilemap.WorldToCell(pos + new Vector3(-1, 0, 0)), Tiili);
            //        HitsausHealth -= 1;
            //    }
            //    if (Hitsaus == true && Input.GetKey(KeyCode.RightArrow))
            //    {
            //        TuhoutuminenAlempiLayer.Instance.rikkitilemap.SetTile(TuhoutuminenAlempiLayer.Instance.rikkitilemap.WorldToCell(pos + new Vector3(1, 0, 0)), RikkiTiili);
            //        Tuhoutuminen.Instance.tilemap.SetTile(Tuhoutuminen.Instance.tilemap.WorldToCell(pos + new Vector3(1, 0, 0)), Tiili);
            //        HitsausHealth -= 1;
            //    }
            //    if (Hitsaus == true && Input.GetKey(KeyCode.UpArrow))
            //    {
            //        TuhoutuminenAlempiLayer.Instance.rikkitilemap.SetTile(TuhoutuminenAlempiLayer.Instance.rikkitilemap.WorldToCell(pos + new Vector3(0, 1, 0)), RikkiTiili);
            //        Tuhoutuminen.Instance.tilemap.SetTile(Tuhoutuminen.Instance.tilemap.WorldToCell(pos + new Vector3(0, 1, 0)), Tiili);
            //        HitsausHealth -= 1;
            //    }
            //    if (Hitsaus == true && Input.GetKey(KeyCode.DownArrow))
            //    {
            //        TuhoutuminenAlempiLayer.Instance.rikkitilemap.SetTile(TuhoutuminenAlempiLayer.Instance.rikkitilemap.WorldToCell(pos + new Vector3(0, -1, 0)), RikkiTiili);
            //        Tuhoutuminen.Instance.tilemap.SetTile(Tuhoutuminen.Instance.tilemap.WorldToCell(pos + new Vector3(0, -1, 0)), Tiili);
            //        HitsausHealth -= 1;
            //    }
            //}


            l = "ei saa liikkua";
            if (Input.GetKey(KeyCode.A) && transform.position == pos)
            {        // Left

                RakettiÄäni.Play();
                pos += Vector3.left;
                PelaajaViimeliike = "vasen";

                transform.rotation = Quaternion.LookRotation(Vector3.forward, pos - transform.position);
                l = "saa liikkua";
                liikkunut = true;
                RakettiBensa -= 1;
            }
            if (Input.GetKey(KeyCode.D) && transform.position == pos)
            {        // Right
                RakettiÄäni.Play();
                pos += Vector3.right;
                PelaajaViimeliike = "oikea";

                transform.rotation = Quaternion.LookRotation(Vector3.forward, pos - transform.position);
                l = "saa liikkua";
                liikkunut = true;
                RakettiBensa -= 1;
            }
            if (Input.GetKey(KeyCode.W) && transform.position == pos)
            {        // Up
                RakettiÄäni.Play();
                pos += Vector3.up;
                PelaajaViimeliike = "ylös";

                transform.rotation = Quaternion.LookRotation(Vector3.forward, pos - transform.position);
                l = "saa liikkua";
                liikkunut = true;
                RakettiBensa -= 1;
            }
            if (Input.GetKey(KeyCode.S) && transform.position == pos)
            {        // Down
                RakettiÄäni.Play();
                pos += Vector3.down;
                PelaajaViimeliike = "alas";

                transform.rotation = Quaternion.LookRotation(Vector3.forward, pos - transform.position);
                l = "saa liikkua";
                liikkunut = true;
                RakettiBensa -= 1;
            }
        }


        transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime * speed);
        PosInt = new Vector3Int((Mathf.RoundToInt(transform.position.x)), (Mathf.RoundToInt(transform.position.y)), 0);
        
        









    }
}
