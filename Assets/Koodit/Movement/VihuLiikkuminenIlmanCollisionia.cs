using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class VihuLiikkuminenIlmanCollisionia : MonoBehaviour {




    public bool EiSaaLiikkuaYlös;
    public bool EiSaaLiikkuaAlas;
    public bool EiSaaliikkuaOikea;
    public bool EiSaaLiikkuaVasen;
    public bool vihuliikkunut;
    public Vector3 target;
    public Vector3 paikka;
    public Vector3 uusipaikka;
    public Vector3 suunta;
    public float matkaX;
    public Vector3 matkaY;
    public float vihuspeed = 0.1f;
    public string VihuViimeliike;
    

    string targetpositio = @"C:\Tiedontallennusharjoitus\Targetpositiotiedosto.txt";
    string xsuunta = @"C:\Tiedontallennusharjoitus\Xsuuntatiedosto.txt";
    string ysuunta = @"C:\Tiedontallennusharjoitus\Ysuuntatiedosto.txt";
    string testausylös = @"C:\Tiedontallennusharjoitus\Testaustiedostoylös.txt";
    string testausalas = @"C:\Tiedontallennusharjoitus\Testaustiedostoalas.txt";
    string testausoikea = @"C:\Tiedontallennusharjoitus\Testaustiedostooikea.txt";
    string testausvasen = @"C:\Tiedontallennusharjoitus\Testaustiedostovasen.txt";


    public static VihuLiikkuminenIlmanCollisionia Instance;


    void Awake()
    {
        Instance = this;
    }


    void Start()
    {
        paikka = transform.position;
        uusipaikka = transform.position;
        vihuliikkunut = true;
    }


    void Update()
    {

        target = RuutuLiikkuminen3.Instance.transform.position;


        File.WriteAllText(targetpositio, target.ToString());


        if (RuutuLiikkuminen3.Instance.liikkunut == true && transform.position == uusipaikka)
        {
            matkaX = Vector3.Distance(target, transform.position);




            //----------------------------------------------------EKA OSIO------------------------------------------------------------------------



            if (target.y > transform.position.y && Mathf.Abs(target.x - transform.position.x) <= Mathf.Abs(target.y - transform.position.y))
            {
                //yDir = 1f;

                if (TuhoutuminenAlempiLayer.Instance.rikkitilemap.HasTile(TuhoutuminenAlempiLayer.Instance.rikkitilemap.WorldToCell(paikka + new Vector3(0, 1, 0))) && EiSaaLiikkuaYlös == false)
                {
                    

                    
                    EiSaaLiikkuaYlös = true;
                    vihuliikkunut = false;
                    return;
                }
                else if(EiSaaLiikkuaYlös==false)
                {
                    //transform.position = paikka + suunta ;
                    suunta = Vector3.up;
                    uusipaikka = suunta + paikka;
                    transform.position = Vector3.MoveTowards(paikka, uusipaikka, Time.deltaTime * vihuspeed);
                    paikka = uusipaikka;
                    transform.position = paikka;
                    VihuViimeliike = "ylös";
                    File.WriteAllText(testausylös, ("tapahtuiylös"));
                    vihuliikkunut = true;
                    EiSaaLiikkuaYlös=false;
                    EiSaaLiikkuaAlas=false;
                    EiSaaliikkuaOikea=false;
                    EiSaaLiikkuaVasen=false;
                    return;
                }

            }
            else if (target.y  < transform.position.y && Mathf.Abs(target.x - transform.position.x) <= Mathf.Abs(target.y - transform.position.y))
            {
                //yDir = -1f;

                if (TuhoutuminenAlempiLayer.Instance.rikkitilemap.HasTile(TuhoutuminenAlempiLayer.Instance.rikkitilemap.WorldToCell(paikka + new Vector3(0, -1, 0))) && EiSaaLiikkuaAlas == false)
                {
                   
                    EiSaaLiikkuaAlas = true;
                    vihuliikkunut = false;
                    return;
                }
                else if (EiSaaLiikkuaAlas==false)
                {
                    //transform.position = paikka + suunta ;
                    suunta = Vector3.down;
                    uusipaikka = suunta + paikka;
                    transform.position = Vector3.MoveTowards(paikka, uusipaikka, Time.deltaTime * vihuspeed);
                    paikka = uusipaikka;
                    transform.position = paikka;
                    VihuViimeliike = "alas";
                    File.WriteAllText(testausalas, ("tapahtuialas"));
                    vihuliikkunut = true;
                    EiSaaLiikkuaYlös = false;
                    EiSaaLiikkuaAlas = false;
                    EiSaaliikkuaOikea = false;
                    EiSaaLiikkuaVasen = false;
                    return;
                }
            }

            else if (target.x > transform.position.x  && Mathf.Abs(target.x - transform.position.x) >= Mathf.Abs(target.y - transform.position.y))
            {
                //xDir = 1f;

                if (TuhoutuminenAlempiLayer.Instance.rikkitilemap.HasTile(TuhoutuminenAlempiLayer.Instance.rikkitilemap.WorldToCell(paikka + new Vector3(1, 0, 0))) && EiSaaliikkuaOikea == false)
                {
                   
                    EiSaaliikkuaOikea = true;
                    vihuliikkunut = false;
                    return;
                }
                else if (EiSaaliikkuaOikea==false)
                {
                    //transform.position = paikka + suunta ;
                    suunta = Vector3.right;
                    uusipaikka = suunta + paikka;
                    transform.position = Vector3.MoveTowards(paikka, uusipaikka, Time.deltaTime * vihuspeed);
                    paikka = uusipaikka;
                    transform.position = paikka;
                    VihuViimeliike = "oikea";
                    File.WriteAllText(testausoikea, ("tapahtuioikea"));
                    vihuliikkunut = true;
                    EiSaaLiikkuaYlös = false;
                    EiSaaLiikkuaAlas = false;
                    EiSaaliikkuaOikea = false;
                    EiSaaLiikkuaVasen = false;
                    return;
                }
            }
            else if (target.x  < transform.position.x && Mathf.Abs(target.x - transform.position.x) >= Mathf.Abs(target.y - transform.position.y))
            {
                //xDir = -1f;

                if (TuhoutuminenAlempiLayer.Instance.rikkitilemap.HasTile(TuhoutuminenAlempiLayer.Instance.rikkitilemap.WorldToCell(paikka + new Vector3(-1, 0, 0))) && EiSaaLiikkuaVasen == false)
                {
                   
                    EiSaaLiikkuaVasen = true;
                    vihuliikkunut = false;
                    return;
                }
                else if(EiSaaLiikkuaVasen==false)
                {
                    //transform.position = paikka + suunta ;
                    suunta = Vector3.left;
                    uusipaikka = suunta + paikka;
                    transform.position = Vector3.MoveTowards(paikka, uusipaikka, Time.deltaTime * vihuspeed);
                    paikka = uusipaikka;
                    transform.position = paikka;
                    VihuViimeliike = "vasen";
                    File.WriteAllText(testausvasen, ("tapahtuivasen"));
                    vihuliikkunut = true;
                    EiSaaLiikkuaYlös = false;
                    EiSaaLiikkuaAlas = false;
                    EiSaaliikkuaOikea = false;
                    EiSaaLiikkuaVasen = false;
                    return;
                }
            }





            //---------------------------------------------------TOKA OSIO-----------------------------------------------------------------------





            if (target.y > transform.position.y && Mathf.Abs(target.x - transform.position.x) > Mathf.Abs(target.y - transform.position.y))
            {
                //yDir = 1f;

                if (TuhoutuminenAlempiLayer.Instance.rikkitilemap.HasTile(TuhoutuminenAlempiLayer.Instance.rikkitilemap.WorldToCell(paikka + new Vector3(0, 1, 0))) && EiSaaLiikkuaYlös == false)
                {



                    EiSaaLiikkuaYlös = true;
                    vihuliikkunut = false;
                    return;
                }
                else if (EiSaaLiikkuaYlös == false)
                {
                    //transform.position = paikka + suunta ;
                    suunta = Vector3.up;
                    uusipaikka = suunta + paikka;
                    transform.position = Vector3.MoveTowards(paikka, uusipaikka, Time.deltaTime * vihuspeed);
                    paikka = uusipaikka;
                    transform.position = paikka;
                    VihuViimeliike = "ylös";
                    File.WriteAllText(testausylös, ("tapahtuiylös"));
                    vihuliikkunut = true;
                    EiSaaLiikkuaYlös = false;
                    EiSaaLiikkuaAlas = false;
                    EiSaaliikkuaOikea = false;
                    EiSaaLiikkuaVasen = false;
                    return;
                }

            }
            else if (target.y < transform.position.y && Mathf.Abs(target.x - transform.position.x) > Mathf.Abs(target.y - transform.position.y))
            {
                //yDir = -1f;

                if (TuhoutuminenAlempiLayer.Instance.rikkitilemap.HasTile(TuhoutuminenAlempiLayer.Instance.rikkitilemap.WorldToCell(paikka + new Vector3(0, -1, 0))) && EiSaaLiikkuaAlas == false)
                {

                    EiSaaLiikkuaAlas = true;
                    vihuliikkunut = false;
                    return;
                }
                else if (EiSaaLiikkuaAlas == false)
                {
                    //transform.position = paikka + suunta ;
                    suunta = Vector3.down;
                    uusipaikka = suunta + paikka;
                    transform.position = Vector3.MoveTowards(paikka, uusipaikka, Time.deltaTime * vihuspeed);
                    paikka = uusipaikka;
                    transform.position = paikka;
                    VihuViimeliike = "alas";
                    File.WriteAllText(testausalas, ("tapahtuialas"));
                    vihuliikkunut = true;
                    EiSaaLiikkuaYlös = false;
                    EiSaaLiikkuaAlas = false;
                    EiSaaliikkuaOikea = false;
                    EiSaaLiikkuaVasen = false;
                    return;
                }
            }

            else if (target.x > transform.position.x && Mathf.Abs(target.x - transform.position.x) < Mathf.Abs(target.y - transform.position.y))
            {
                //xDir = 1f;

                if (TuhoutuminenAlempiLayer.Instance.rikkitilemap.HasTile(TuhoutuminenAlempiLayer.Instance.rikkitilemap.WorldToCell(paikka + new Vector3(1, 0, 0))) && EiSaaliikkuaOikea == false)
                {

                    EiSaaliikkuaOikea = true;
                    vihuliikkunut = false;
                    return;
                }
                else if (EiSaaliikkuaOikea == false)
                {
                    //transform.position = paikka + suunta ;
                    suunta = Vector3.right;
                    uusipaikka = suunta + paikka;
                    transform.position = Vector3.MoveTowards(paikka, uusipaikka, Time.deltaTime * vihuspeed);
                    paikka = uusipaikka;
                    transform.position = paikka;
                    VihuViimeliike = "oikea";
                    File.WriteAllText(testausoikea, ("tapahtuioikea"));
                    vihuliikkunut = true;
                    EiSaaLiikkuaYlös = false;
                    EiSaaLiikkuaAlas = false;
                    EiSaaliikkuaOikea = false;
                    EiSaaLiikkuaVasen = false;
                    return;
                }
            }
            else if (target.x < transform.position.x && Mathf.Abs(target.x - transform.position.x) < Mathf.Abs(target.y - transform.position.y))
            {
                //xDir = -1f;

                if (TuhoutuminenAlempiLayer.Instance.rikkitilemap.HasTile(TuhoutuminenAlempiLayer.Instance.rikkitilemap.WorldToCell(paikka + new Vector3(-1, 0, 0))) && EiSaaLiikkuaVasen == false)
                {

                    EiSaaLiikkuaVasen = true;
                    vihuliikkunut = false;
                    return;
                }
                else if (EiSaaLiikkuaVasen == false)
                {
                    //transform.position = paikka + suunta ;
                    suunta = Vector3.left;
                    uusipaikka = suunta + paikka;
                    transform.position = Vector3.MoveTowards(paikka, uusipaikka, Time.deltaTime * vihuspeed);
                    paikka = uusipaikka;
                    transform.position = paikka;
                    VihuViimeliike = "vasen";
                    File.WriteAllText(testausvasen, ("tapahtuivasen"));
                    vihuliikkunut = true;
                    EiSaaLiikkuaYlös = false;
                    EiSaaLiikkuaAlas = false;
                    EiSaaliikkuaOikea = false;
                    EiSaaLiikkuaVasen = false;
                    return;
                }
            }




            //----------------------------------------------------KOLMAS OSIO------------------------------------------------------------------------







            if (target.y > transform.position.y && Mathf.Abs(target.x - transform.position.x) <= Mathf.Abs(target.y - transform.position.y))
            {
                //yDir = 1f;

                if (TuhoutuminenAlempiLayer.Instance.rikkitilemap.HasTile(TuhoutuminenAlempiLayer.Instance.rikkitilemap.WorldToCell(paikka + new Vector3(0, 1, 0))) && EiSaaLiikkuaYlös == false)
                {



                    EiSaaLiikkuaYlös = true;
                    vihuliikkunut = false;
                    return;
                }
                else if (EiSaaLiikkuaYlös == false)
                {
                    //transform.position = paikka + suunta ;
                    suunta = Vector3.up;
                    uusipaikka = suunta + paikka;
                    transform.position = Vector3.MoveTowards(paikka, uusipaikka, Time.deltaTime * vihuspeed);
                    paikka = uusipaikka;
                    transform.position = paikka;
                    VihuViimeliike = "ylös";
                    File.WriteAllText(testausylös, ("tapahtuiylös"));
                    vihuliikkunut = true;
                    EiSaaLiikkuaYlös = false;
                    EiSaaLiikkuaAlas = false;
                    EiSaaliikkuaOikea = false;
                    EiSaaLiikkuaVasen = false;
                    return;
                }

            }
            else if (target.y < transform.position.y && Mathf.Abs(target.x - transform.position.x) <= Mathf.Abs(target.y - transform.position.y))
            {
                //yDir = -1f;

                if (TuhoutuminenAlempiLayer.Instance.rikkitilemap.HasTile(TuhoutuminenAlempiLayer.Instance.rikkitilemap.WorldToCell(paikka + new Vector3(0, -1, 0))) && EiSaaLiikkuaAlas == false)
                {

                    EiSaaLiikkuaAlas = true;
                    vihuliikkunut = false;
                    return;
                }
                else if (EiSaaLiikkuaAlas == false)
                {
                    //transform.position = paikka + suunta ;
                    suunta = Vector3.down;
                    uusipaikka = suunta + paikka;
                    transform.position = Vector3.MoveTowards(paikka, uusipaikka, Time.deltaTime * vihuspeed);
                    paikka = uusipaikka;
                    transform.position = paikka;
                    VihuViimeliike = "alas";
                    File.WriteAllText(testausalas, ("tapahtuialas"));
                    vihuliikkunut = true;
                    EiSaaLiikkuaYlös = false;
                    EiSaaLiikkuaAlas = false;
                    EiSaaliikkuaOikea = false;
                    EiSaaLiikkuaVasen = false;
                    return;
                }
            }

            else if (target.x > transform.position.x && Mathf.Abs(target.x - transform.position.x) >= Mathf.Abs(target.y - transform.position.y))
            {
                //xDir = 1f;

                if (TuhoutuminenAlempiLayer.Instance.rikkitilemap.HasTile(TuhoutuminenAlempiLayer.Instance.rikkitilemap.WorldToCell(paikka + new Vector3(1, 0, 0))) && EiSaaliikkuaOikea == false)
                {

                    EiSaaliikkuaOikea = true;
                    vihuliikkunut = false;
                    return;
                }
                else if (EiSaaliikkuaOikea == false)
                {
                    //transform.position = paikka + suunta ;
                    suunta = Vector3.right;
                    uusipaikka = suunta + paikka;
                    transform.position = Vector3.MoveTowards(paikka, uusipaikka, Time.deltaTime * vihuspeed);
                    paikka = uusipaikka;
                    transform.position = paikka;
                    VihuViimeliike = "oikea";
                    File.WriteAllText(testausoikea, ("tapahtuioikea"));
                    vihuliikkunut = true;
                    EiSaaLiikkuaYlös = false;
                    EiSaaLiikkuaAlas = false;
                    EiSaaliikkuaOikea = false;
                    EiSaaLiikkuaVasen = false;
                    return;
                }
            }
            else if (target.x < transform.position.x && Mathf.Abs(target.x - transform.position.x) >= Mathf.Abs(target.y - transform.position.y))
            {
                //xDir = -1f;

                if (TuhoutuminenAlempiLayer.Instance.rikkitilemap.HasTile(TuhoutuminenAlempiLayer.Instance.rikkitilemap.WorldToCell(paikka + new Vector3(-1, 0, 0))) && EiSaaLiikkuaVasen == false)
                {

                    EiSaaLiikkuaVasen = true;
                    vihuliikkunut = false;
                    return;
                }
                else if (EiSaaLiikkuaVasen == false)
                {
                    //transform.position = paikka + suunta ;
                    suunta = Vector3.left;
                    uusipaikka = suunta + paikka;
                    transform.position = Vector3.MoveTowards(paikka, uusipaikka, Time.deltaTime * vihuspeed);
                    paikka = uusipaikka;
                    transform.position = paikka;
                    VihuViimeliike = "vasen";
                    File.WriteAllText(testausvasen, ("tapahtuivasen"));
                    vihuliikkunut = true;
                    EiSaaLiikkuaYlös = false;
                    EiSaaLiikkuaAlas = false;
                    EiSaaliikkuaOikea = false;
                    EiSaaLiikkuaVasen = false;
                    return;
                }
            }





            //---------------------------------------------------------NELJÄS OSIO--------------------------------------------------------------------






            if (target.y > transform.position.y && Mathf.Abs(target.x - transform.position.x) <= Mathf.Abs(target.y - transform.position.y))
            {
                //yDir = 1f;

                if (TuhoutuminenAlempiLayer.Instance.rikkitilemap.HasTile(TuhoutuminenAlempiLayer.Instance.rikkitilemap.WorldToCell(paikka + new Vector3(0, 1, 0))) && EiSaaLiikkuaYlös == false)
                {



                    EiSaaLiikkuaYlös = true;
                    vihuliikkunut = false;
                    return;
                }
                else if (EiSaaLiikkuaYlös == false)
                {
                    //transform.position = paikka + suunta ;
                    suunta = Vector3.up;
                    uusipaikka = suunta + paikka;
                    transform.position = Vector3.MoveTowards(paikka, uusipaikka, Time.deltaTime * vihuspeed);
                    paikka = uusipaikka;
                    transform.position = paikka;
                    VihuViimeliike = "ylös";
                    File.WriteAllText(testausylös, ("tapahtuiylös"));
                    vihuliikkunut = true;
                    EiSaaLiikkuaYlös = false;
                    EiSaaLiikkuaAlas = false;
                    EiSaaliikkuaOikea = false;
                    EiSaaLiikkuaVasen = false;
                    return;
                }

            }
            else if (target.y < transform.position.y && Mathf.Abs(target.x - transform.position.x) <= Mathf.Abs(target.y - transform.position.y))
            {
                //yDir = -1f;

                if (TuhoutuminenAlempiLayer.Instance.rikkitilemap.HasTile(TuhoutuminenAlempiLayer.Instance.rikkitilemap.WorldToCell(paikka + new Vector3(0, -1, 0))) && EiSaaLiikkuaAlas == false)
                {

                    EiSaaLiikkuaAlas = true;
                    vihuliikkunut = false;
                    return;
                }
                else if (EiSaaLiikkuaAlas == false)
                {
                    //transform.position = paikka + suunta ;
                    suunta = Vector3.down;
                    uusipaikka = suunta + paikka;
                    transform.position = Vector3.MoveTowards(paikka, uusipaikka, Time.deltaTime * vihuspeed);
                    paikka = uusipaikka;
                    transform.position = paikka;
                    VihuViimeliike = "alas";
                    File.WriteAllText(testausalas, ("tapahtuialas"));
                    vihuliikkunut = true;
                    EiSaaLiikkuaYlös = false;
                    EiSaaLiikkuaAlas = false;
                    EiSaaliikkuaOikea = false;
                    EiSaaLiikkuaVasen = false;
                    return;
                }
            }

            else if (target.x > transform.position.x && Mathf.Abs(target.x - transform.position.x) >= Mathf.Abs(target.y - transform.position.y))
            {
                //xDir = 1f;

                if (TuhoutuminenAlempiLayer.Instance.rikkitilemap.HasTile(TuhoutuminenAlempiLayer.Instance.rikkitilemap.WorldToCell(paikka + new Vector3(1, 0, 0))) && EiSaaliikkuaOikea == false)
                {

                    EiSaaliikkuaOikea = true;
                    vihuliikkunut = false;
                    return;
                }
                else if (EiSaaliikkuaOikea == false)
                {
                    //transform.position = paikka + suunta ;
                    suunta = Vector3.right;
                    uusipaikka = suunta + paikka;
                    transform.position = Vector3.MoveTowards(paikka, uusipaikka, Time.deltaTime * vihuspeed);
                    paikka = uusipaikka;
                    transform.position = paikka;
                    VihuViimeliike = "oikea";
                    File.WriteAllText(testausoikea, ("tapahtuioikea"));
                    vihuliikkunut = true;
                    EiSaaLiikkuaYlös = false;
                    EiSaaLiikkuaAlas = false;
                    EiSaaliikkuaOikea = false;
                    EiSaaLiikkuaVasen = false;
                    return;
                }
            }
            else if (target.x < transform.position.x && Mathf.Abs(target.x - transform.position.x) >= Mathf.Abs(target.y - transform.position.y))
            {
                //xDir = -1f;

                if (TuhoutuminenAlempiLayer.Instance.rikkitilemap.HasTile(TuhoutuminenAlempiLayer.Instance.rikkitilemap.WorldToCell(paikka + new Vector3(-1, 0, 0))) && EiSaaLiikkuaVasen == false)
                {

                    EiSaaLiikkuaVasen = true;
                    vihuliikkunut = false;
                    return;
                }
                else if (EiSaaLiikkuaVasen == false)
                {
                    //transform.position = paikka + suunta ;
                    suunta = Vector3.left;
                    uusipaikka = suunta + paikka;
                    transform.position = Vector3.MoveTowards(paikka, uusipaikka, Time.deltaTime * vihuspeed);
                    paikka = uusipaikka;
                    transform.position = paikka;
                    VihuViimeliike = "vasen";
                    File.WriteAllText(testausvasen, ("tapahtuivasen"));
                    vihuliikkunut = true;
                    EiSaaLiikkuaYlös = false;
                    EiSaaLiikkuaAlas = false;
                    EiSaaliikkuaOikea = false;
                    EiSaaLiikkuaVasen = false;
                    return;
                }
            }
        }
    }
}

