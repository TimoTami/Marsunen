using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System.IO;
using UnityEngine.SceneManagement;

public class RuutuLiikkuminen3 : MonoBehaviour
{
    public int RakettiBensa;
    public bool Kypärä;
    public int KypäränHealth;
    public bool liikkunut;
    public int PelaajanHealth;
    public bool Hitsaus;
    public int HitsausHealth;
    public string PelaajaViimeliike;
    public string l;
    public Vector3 pos;                                // For movement
    public float speed = 2;                         // Speed of movement

    public Tile RikkiTiili;
    public Tile Tiili;

    public float Viive = 1f;
    private float AikaaKulunut = 0f;

    public static RuutuLiikkuminen3 Instance;

    string viimepositiox = @"C:\Tiedontallennusharjoitus\Viimepositiotiedostox.txt";
    string viimepositioy = @"C:\Tiedontallennusharjoitus\Viimepositiotiedostoy.txt";
    string viimepositioz = @"C:\Tiedontallennusharjoitus\Viimepositiotiedostoz.txt";
    string nykyinenpositio = @"C:\Tiedontallennusharjoitus\Nykyinenpositiotiedosto.txt";


    void Awake()
    {
        //SceneManager.LoadScene("HamsteriScene");
        Instance = this;
    }

        public void Start()
    {

        RakettiBensa = 200;
        PelaajanHealth = 20;
        liikkunut = false;
        pos = transform.position;          // Take the initial position
 
        File.WriteAllText(viimepositiox, pos.x.ToString());
        File.WriteAllText(viimepositioy, pos.y.ToString());
        File.WriteAllText(viimepositioz, pos.z.ToString());

    }

    public void Update()
    {
        AikaaKulunut += Time.deltaTime;
        if (PelaajanHealth <= 0||RakettiBensa<=0)
        {
            SceneManager.LoadScene("HamsteriScene");
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
        if(HitsausHealth<=0)
        {
            Hitsaus = false;
        }
    }
    public void FixedUpdate()
    {
        liikkunut = false;

        if (VihuLiikkuminen.Instance.vihuliikkunut==false&&VihuLiikkuminenEiAgressiivinen.Instance.vihuliikkunut==false)
        {
            liikkunut = true;
            return;
        }
        if(VihuLiikkuminen.Instance.SaaRikkoa==true||VihuLiikkuminenEiAgressiivinen.Instance.SaaRikkoa==true)
        {
            liikkunut = true;
            return;
        }
        else if (transform.position == pos&&VihuLiikkuminen.Instance.vihuliikkunut==true&&VihuLiikkuminenEiAgressiivinen.Instance.vihuliikkunut==true)
        {
            if ((Input.GetKey(KeyCode.LeftArrow)||Input.GetKey(KeyCode.RightArrow)|| Input.GetKey(KeyCode.UpArrow)|| Input.GetKey(KeyCode.DownArrow)) &&  AikaaKulunut >= Viive)
            {
                
                AikaaKulunut = 0f;

                if (Hitsaus == true && Input.GetKey(KeyCode.LeftArrow) && Tuhoutuminen.Instance.tilemap.HasTile(Tuhoutuminen.Instance.tilemap.WorldToCell(pos + new Vector3(-1, 0, 0)) )==false)
                {
                    TuhoutuminenAlempiLayer.Instance.rikkitilemap.SetTile(TuhoutuminenAlempiLayer.Instance.rikkitilemap.WorldToCell(pos + new Vector3(-1, 0, 0)), RikkiTiili);
                    Tuhoutuminen.Instance.tilemap.SetTile(Tuhoutuminen.Instance.tilemap.WorldToCell(pos + new Vector3(-1, 0, 0)), Tiili);
                    HitsausHealth -= 1;
                }
                if (Hitsaus == true && Input.GetKey(KeyCode.RightArrow) && Tuhoutuminen.Instance.tilemap.HasTile(Tuhoutuminen.Instance.tilemap.WorldToCell(pos + new Vector3(1, 0, 0))) == false)
                {
                    TuhoutuminenAlempiLayer.Instance.rikkitilemap.SetTile(TuhoutuminenAlempiLayer.Instance.rikkitilemap.WorldToCell(pos + new Vector3(1, 0, 0)), RikkiTiili);
                    Tuhoutuminen.Instance.tilemap.SetTile(Tuhoutuminen.Instance.tilemap.WorldToCell(pos + new Vector3(1, 0, 0)), Tiili);
                    HitsausHealth -= 1;
                }
                if (Hitsaus == true && Input.GetKey(KeyCode.UpArrow) && Tuhoutuminen.Instance.tilemap.HasTile(Tuhoutuminen.Instance.tilemap.WorldToCell(pos + new Vector3(0, 1, 0))) == false)
                {
                    TuhoutuminenAlempiLayer.Instance.rikkitilemap.SetTile(TuhoutuminenAlempiLayer.Instance.rikkitilemap.WorldToCell(pos + new Vector3(0, 1, 0)), RikkiTiili);
                    Tuhoutuminen.Instance.tilemap.SetTile(Tuhoutuminen.Instance.tilemap.WorldToCell(pos + new Vector3(0, 1, 0)), Tiili);
                    HitsausHealth -= 1;
                }
                if (Hitsaus == true && Input.GetKey(KeyCode.DownArrow) && Tuhoutuminen.Instance.tilemap.HasTile(Tuhoutuminen.Instance.tilemap.WorldToCell(pos + new Vector3(0, -1, 0))) == false)
                {
                    TuhoutuminenAlempiLayer.Instance.rikkitilemap.SetTile(TuhoutuminenAlempiLayer.Instance.rikkitilemap.WorldToCell(pos + new Vector3(0, -1, 0)), RikkiTiili);
                    Tuhoutuminen.Instance.tilemap.SetTile(Tuhoutuminen.Instance.tilemap.WorldToCell(pos + new Vector3(0, -1, 0)), Tiili);
                    HitsausHealth -= 1;
                }
            }


            l = "ei saa liikkua";
            if (Input.GetKey(KeyCode.A) && transform.position == pos)
            {        // Left

                File.WriteAllText(viimepositiox, pos.x.ToString());
                File.WriteAllText(viimepositioy, pos.y.ToString());
                File.WriteAllText(viimepositioz, pos.z.ToString());
                pos += Vector3.left;
                PelaajaViimeliike = "vasen";

                transform.rotation = Quaternion.LookRotation(Vector3.forward, pos - transform.position);
                l = "saa liikkua";
                liikkunut = true;
                RakettiBensa -= 1;
            }
            if (Input.GetKey(KeyCode.D) && transform.position == pos)
            {        // Right
                File.WriteAllText(viimepositiox, pos.x.ToString());
                File.WriteAllText(viimepositioy, pos.y.ToString());
                File.WriteAllText(viimepositioz, pos.z.ToString());
                pos += Vector3.right;
                PelaajaViimeliike = "oikea";

                transform.rotation = Quaternion.LookRotation(Vector3.forward, pos - transform.position);
                l = "saa liikkua";
                liikkunut = true;
                RakettiBensa -= 1;
            }
            if (Input.GetKey(KeyCode.W) && transform.position == pos)
            {        // Up
                File.WriteAllText(viimepositiox, pos.x.ToString());
                File.WriteAllText(viimepositioy, pos.y.ToString());
                File.WriteAllText(viimepositioz, pos.z.ToString());
                pos += Vector3.up;
                PelaajaViimeliike = "ylös";

                transform.rotation = Quaternion.LookRotation(Vector3.forward, pos - transform.position);
                l = "saa liikkua";
                liikkunut = true;
                RakettiBensa -= 1;
            }
            if (Input.GetKey(KeyCode.S) && transform.position == pos)
            {        // Down
                File.WriteAllText(viimepositiox, pos.x.ToString());
                File.WriteAllText(viimepositioy, pos.y.ToString());
                File.WriteAllText(viimepositioz, pos.z.ToString());
                pos += Vector3.down;
                PelaajaViimeliike = "alas";

                transform.rotation = Quaternion.LookRotation(Vector3.forward, pos - transform.position);
                l = "saa liikkua";
                liikkunut = true;
                RakettiBensa -= 1;
            }
        }
       

            transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime * speed);
            


        if (transform.position==pos)
        {
            File.WriteAllText(nykyinenpositio, pos.ToString());
        }

     

        
        
        




    }
 
}