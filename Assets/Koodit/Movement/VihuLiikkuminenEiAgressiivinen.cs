using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VihuLiikkuminenEiAgressiivinen : MonoBehaviour
{

    public Vector3 instapaikka;
    public bool SaaRikkoa;
    public bool vihuliikkunut;
    public Vector3 target;
    public Vector3 paikka;
    public Vector3 uusipaikka;
    public Vector3 suunta;
    public float matkaX;
    public Vector3 matkaY;
    public float vihuspeed = 0.02f;
    public string VihuViimeliike;
    public string tapahtuma;
    public int EsteLisäYlös;
    public int EsteLisäAlas;
    public int EsteLisäOikea;
    public int EsteLisäVasen;

    string targetpositio = @"C:\Tiedontallennusharjoitus\Targetpositiotiedosto.txt";
    string xsuunta = @"C:\Tiedontallennusharjoitus\Xsuuntatiedosto.txt";
    string ysuunta = @"C:\Tiedontallennusharjoitus\Ysuuntatiedosto.txt";
    string testausylös = @"C:\Tiedontallennusharjoitus\Testaustiedostoylös.txt";
    string testausalas = @"C:\Tiedontallennusharjoitus\Testaustiedostoalas.txt";
    string testausoikea = @"C:\Tiedontallennusharjoitus\Testaustiedostooikea.txt";
    string testausvasen = @"C:\Tiedontallennusharjoitus\Testaustiedostovasen.txt";
    public bool OnkoPitkäMatka;


    public static VihuLiikkuminenEiAgressiivinen Instance;


    void Awake()
    {
        Instance = this;
    }


    void Start()
    {
        paikka = transform.position;
        uusipaikka = transform.position;
        EsteLisäYlös = 0;
        EsteLisäAlas = 0;
        EsteLisäOikea = 0;
        EsteLisäVasen = 0;
        SaaRikkoa = false;
        vihuliikkunut = true;
    }


    void FixedUpdate()
    {
        if (Mathf.Abs(target.x - transform.position.x) >= 5 || (Mathf.Abs(target.y - transform.position.y) >= 5))
        {
            OnkoPitkäMatka = true;
        }
        else
        {
            OnkoPitkäMatka = false;
        }
        instapaikka = Instance.transform.position;
        target = RuutuLiikkuminen3.Instance.transform.position;


        File.WriteAllText(targetpositio, target.ToString());

        
        if (RuutuLiikkuminen3.Instance.liikkunut == true && transform.position == uusipaikka)
        {
            matkaX = Vector3.Distance(target, transform.position);


            if (VihuLiikkuminen.Instance.SaaRikkoa == true)
            {
                return;
            }


            //--------------------------------------------------------EKA OSIO--------------------------------------------------------------------





            else if (target.y > transform.position.y + EsteLisäYlös && Mathf.Abs(target.x - transform.position.x) <= Mathf.Abs(target.y - transform.position.y))
            {
                //yDir = 1f;

                if (TuhoutuminenAlempiLayer.Instance.rikkitilemap.HasTile(TuhoutuminenAlempiLayer.Instance.rikkitilemap.WorldToCell(paikka + new Vector3(0, 1, 0))) && SaaRikkoa == false)
                {
                    EsteLisäYlös = 20;
                    if (Mathf.Abs(target.x - transform.position.x) >= 5 || (Mathf.Abs(target.y - transform.position.y) >= 5))
                    {
                        EsteLisäYlös = 10;
                    }

                    if (Tuhoutuminen.Instance.tilemap.HasTile(Tuhoutuminen.Instance.tilemap.WorldToCell(paikka + new Vector3(0, 1, 0))))
                    {
                        EsteLisäYlös += 1;
                    }
                    if (TuhoutuminenAlempiLayer.Instance.rikkitilemap.HasTile(TuhoutuminenAlempiLayer.Instance.rikkitilemap.WorldToCell(paikka + new Vector3(0, 2, 0))))
                    {
                        EsteLisäYlös += 1;
                        if (Mathf.Abs(target.x - transform.position.x) >= 5 || (Mathf.Abs(target.y - transform.position.y) >= 5))
                        {
                            EsteLisäYlös = 10;
                        }

                        if (TuhoutuminenAlempiLayer.Instance.rikkitilemap.HasTile(TuhoutuminenAlempiLayer.Instance.rikkitilemap.WorldToCell(paikka + new Vector3(0, 3, 0))))
                        {
                            EsteLisäYlös += 1;
                        }
                        if (Tuhoutuminen.Instance.tilemap.HasTile(Tuhoutuminen.Instance.tilemap.WorldToCell(paikka + new Vector3(0, 3, 0))))
                        {
                            EsteLisäYlös += 4;
                        }
                    }
                    if (Tuhoutuminen.Instance.tilemap.HasTile(Tuhoutuminen.Instance.tilemap.WorldToCell(paikka + new Vector3(0, 2, 0))))
                    {
                        EsteLisäYlös += 1;
                    }
                    SaaRikkoa = true;
                    vihuliikkunut = false;
                    tapahtuma = "1OsioYlös";
                    return;
                }
                else
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
                    EsteLisäYlös = 0;
                    EsteLisäAlas = 0;
                    EsteLisäOikea = 0;
                    EsteLisäVasen = 0;
                    SaaRikkoa = false;
                    return;
                }

            }
            else if (target.y + EsteLisäAlas < transform.position.y && Mathf.Abs(target.x - transform.position.x) <= Mathf.Abs(target.y - transform.position.y))
            {
                //yDir = -1f;

                if (TuhoutuminenAlempiLayer.Instance.rikkitilemap.HasTile(TuhoutuminenAlempiLayer.Instance.rikkitilemap.WorldToCell(paikka + new Vector3(0, -1, 0))) && SaaRikkoa == false)
                {
                    EsteLisäAlas = 20;
                    if (Mathf.Abs(target.x - transform.position.x) >= 5 || (Mathf.Abs(target.y - transform.position.y) >= 5))
                    {
                        EsteLisäAlas = 10;
                    }

                    if (Tuhoutuminen.Instance.tilemap.HasTile(Tuhoutuminen.Instance.tilemap.WorldToCell(paikka + new Vector3(0, -1, 0))))
                    {
                        EsteLisäAlas += 1;
                    }
                    if (TuhoutuminenAlempiLayer.Instance.rikkitilemap.HasTile(TuhoutuminenAlempiLayer.Instance.rikkitilemap.WorldToCell(paikka + new Vector3(0, -2, 0))))
                    {
                        EsteLisäAlas += 1;
                        if (Mathf.Abs(target.x - transform.position.x) >= 5 || (Mathf.Abs(target.y - transform.position.y) >= 5))
                        {
                            EsteLisäAlas = 10;
                        }

                        if (TuhoutuminenAlempiLayer.Instance.rikkitilemap.HasTile(TuhoutuminenAlempiLayer.Instance.rikkitilemap.WorldToCell(paikka + new Vector3(0, -3, 0))))
                        {
                            EsteLisäAlas += 1;
                        }
                        if (Tuhoutuminen.Instance.tilemap.HasTile(Tuhoutuminen.Instance.tilemap.WorldToCell(paikka + new Vector3(0, -3, 0))))
                        {
                            EsteLisäAlas += 4;
                        }
                    }
                    if (Tuhoutuminen.Instance.tilemap.HasTile(Tuhoutuminen.Instance.tilemap.WorldToCell(paikka + new Vector3(0, -2, 0))))
                    {
                        EsteLisäAlas += 1;
                    }
                    SaaRikkoa = true;
                    vihuliikkunut = false;
                    tapahtuma = "1OsioAlas";
                    return;
                }
                else
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
                    EsteLisäYlös = 0;
                    EsteLisäAlas = 0;
                    EsteLisäOikea = 0;
                    EsteLisäVasen = 0;
                    SaaRikkoa = false;
                    return;
                }
            }

            else if (target.x > transform.position.x + EsteLisäOikea && Mathf.Abs(target.x - transform.position.x) >= Mathf.Abs(target.y - transform.position.y))
            {
                //xDir = 1f;

                if (TuhoutuminenAlempiLayer.Instance.rikkitilemap.HasTile(TuhoutuminenAlempiLayer.Instance.rikkitilemap.WorldToCell(paikka + new Vector3(1, 0, 0))) && SaaRikkoa == false)
                {
                    EsteLisäOikea = 20;
                    if (Mathf.Abs(target.x - transform.position.x) >= 5 || (Mathf.Abs(target.y - transform.position.y) >= 5))
                    {
                        EsteLisäOikea = 10;
                    }

                    if (Tuhoutuminen.Instance.tilemap.HasTile(Tuhoutuminen.Instance.tilemap.WorldToCell(paikka + new Vector3(1, 0, 0))))
                    {
                        EsteLisäOikea += 1;
                    }
                    if (TuhoutuminenAlempiLayer.Instance.rikkitilemap.HasTile(TuhoutuminenAlempiLayer.Instance.rikkitilemap.WorldToCell(paikka + new Vector3(2, 0, 0))))
                    {
                        EsteLisäOikea += 1;
                        if (Mathf.Abs(target.x - transform.position.x) >= 5 || (Mathf.Abs(target.y - transform.position.y) >= 5))
                        {
                            EsteLisäOikea = 10;
                        }


                        if (TuhoutuminenAlempiLayer.Instance.rikkitilemap.HasTile(TuhoutuminenAlempiLayer.Instance.rikkitilemap.WorldToCell(paikka + new Vector3(3, 0, 0))))
                        {
                            EsteLisäOikea += 1;
                        }
                        if (Tuhoutuminen.Instance.tilemap.HasTile(Tuhoutuminen.Instance.tilemap.WorldToCell(paikka + new Vector3(3, 0, 0))))
                        {
                            EsteLisäOikea += 4;
                        }
                    }
                    if (Tuhoutuminen.Instance.tilemap.HasTile(Tuhoutuminen.Instance.tilemap.WorldToCell(paikka + new Vector3(2, 0, 0))))
                    {
                        EsteLisäOikea += 1;
                    }
                    SaaRikkoa = true;
                    vihuliikkunut = false;
                    tapahtuma = "1OsioOikea";
                    return;
                }
                else
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
                    EsteLisäYlös = 0;
                    EsteLisäAlas = 0;
                    EsteLisäOikea = 0;
                    EsteLisäVasen = 0;
                    SaaRikkoa = false;
                    return;
                }
            }
            else if (target.x + EsteLisäVasen < transform.position.x && Mathf.Abs(target.x - transform.position.x) >= Mathf.Abs(target.y - transform.position.y))
            {
                //xDir = -1f;

                if (TuhoutuminenAlempiLayer.Instance.rikkitilemap.HasTile(TuhoutuminenAlempiLayer.Instance.rikkitilemap.WorldToCell(paikka + new Vector3(-1, 0, 0))) && SaaRikkoa == false)
                {
                    EsteLisäVasen = 20;
                    if (Mathf.Abs(target.x - transform.position.x) >= 5 || (Mathf.Abs(target.y - transform.position.y) >= 5))
                    {
                        EsteLisäVasen = 10;
                    }

                    if (Tuhoutuminen.Instance.tilemap.HasTile(Tuhoutuminen.Instance.tilemap.WorldToCell(paikka + new Vector3(-1, 0, 0))))
                    {
                        EsteLisäVasen += 1;
                    }
                    if (TuhoutuminenAlempiLayer.Instance.rikkitilemap.HasTile(TuhoutuminenAlempiLayer.Instance.rikkitilemap.WorldToCell(uusipaikka + new Vector3(-2, 0, 0))))
                    {
                        EsteLisäVasen += 1;
                        if (Mathf.Abs(target.x - transform.position.x) >= 5 || (Mathf.Abs(target.y - transform.position.y) >= 5))
                        {
                            EsteLisäVasen = 10;
                        }


                        if (TuhoutuminenAlempiLayer.Instance.rikkitilemap.HasTile(TuhoutuminenAlempiLayer.Instance.rikkitilemap.WorldToCell(paikka + new Vector3(-3, 0, 0))))
                        {
                            EsteLisäVasen += 1;
                        }
                        if (Tuhoutuminen.Instance.tilemap.HasTile(Tuhoutuminen.Instance.tilemap.WorldToCell(paikka + new Vector3(-3, 0, 0))))
                        {
                            EsteLisäVasen += 4;
                        }
                    }
                    if (Tuhoutuminen.Instance.tilemap.HasTile(Tuhoutuminen.Instance.tilemap.WorldToCell(uusipaikka + new Vector3(-2, 0, 0))))
                    {
                        EsteLisäVasen += 1;
                    }
                    SaaRikkoa = true;
                    vihuliikkunut = false;
                    tapahtuma = "1OsioVasen";
                    return;
                }
                else
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
                    EsteLisäYlös = 0;
                    EsteLisäAlas = 0;
                    EsteLisäOikea = 0;
                    EsteLisäVasen = 0;
                    SaaRikkoa = false;
                    return;
                }
            }







            //------------------------------------------------------------------ONGELMA 1-------------------------------------------------------------------- -








            else if (target.y > transform.position.y + EsteLisäYlös && Mathf.Abs(target.x - transform.position.x) > Mathf.Abs(target.y - transform.position.y))
            {
                //yDir = 1f;

                if (TuhoutuminenAlempiLayer.Instance.rikkitilemap.HasTile(TuhoutuminenAlempiLayer.Instance.rikkitilemap.WorldToCell(paikka + new Vector3(0, 1, 0))) && SaaRikkoa == false)
                {
                    EsteLisäYlös = 20;
                    if (Mathf.Abs(target.x - transform.position.x) >= 5 || (Mathf.Abs(target.y - transform.position.y) >= 5))
                    {
                        EsteLisäYlös = 10;
                    }

                    if (Tuhoutuminen.Instance.tilemap.HasTile(Tuhoutuminen.Instance.tilemap.WorldToCell(paikka + new Vector3(0, 1, 0))))
                    {
                        EsteLisäYlös += 1;
                    }
                    if (TuhoutuminenAlempiLayer.Instance.rikkitilemap.HasTile(TuhoutuminenAlempiLayer.Instance.rikkitilemap.WorldToCell(paikka + new Vector3(0, 2, 0))))
                    {
                        EsteLisäYlös += 1;
                        if (Mathf.Abs(target.x - transform.position.x) >= 5 || (Mathf.Abs(target.y - transform.position.y) >= 5))
                        {
                            EsteLisäYlös = 10;
                        }

                        if (TuhoutuminenAlempiLayer.Instance.rikkitilemap.HasTile(TuhoutuminenAlempiLayer.Instance.rikkitilemap.WorldToCell(paikka + new Vector3(0, 3, 0))))
                        {
                            EsteLisäYlös += 1;
                        }
                        if (Tuhoutuminen.Instance.tilemap.HasTile(Tuhoutuminen.Instance.tilemap.WorldToCell(paikka + new Vector3(0, 3, 0))))
                        {
                            EsteLisäYlös += 4;
                        }
                    }
                    if (Tuhoutuminen.Instance.tilemap.HasTile(Tuhoutuminen.Instance.tilemap.WorldToCell(paikka + new Vector3(0, 2, 0))))
                    {
                        EsteLisäYlös += 1;
                    }
                    SaaRikkoa = true;
                    vihuliikkunut = false;
                    tapahtuma = "2OsioYlös";
                    return;
                }
                else
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
                    EsteLisäYlös = 0;
                    EsteLisäAlas = 0;
                    EsteLisäOikea = 0;
                    EsteLisäVasen = 0;
                    SaaRikkoa = false;
                    return;
                }

            }
            else if (target.y + EsteLisäAlas < transform.position.y && Mathf.Abs(target.x - transform.position.x) > Mathf.Abs(target.y - transform.position.y))
            {
                //yDir = -1f;

                if (TuhoutuminenAlempiLayer.Instance.rikkitilemap.HasTile(TuhoutuminenAlempiLayer.Instance.rikkitilemap.WorldToCell(paikka + new Vector3(0, -1, 0))) && SaaRikkoa == false)
                {
                    EsteLisäAlas = 20;
                    if (Mathf.Abs(target.x - transform.position.x) >= 5 || (Mathf.Abs(target.y - transform.position.y) >= 5))
                    {
                        EsteLisäAlas = 10;
                    }

                    if (Tuhoutuminen.Instance.tilemap.HasTile(Tuhoutuminen.Instance.tilemap.WorldToCell(paikka + new Vector3(0, -1, 0))))
                    {
                        EsteLisäAlas += 1;
                    }
                    if (TuhoutuminenAlempiLayer.Instance.rikkitilemap.HasTile(TuhoutuminenAlempiLayer.Instance.rikkitilemap.WorldToCell(paikka + new Vector3(0, -2, 0))))
                    {
                        EsteLisäAlas += 1;
                        if (Mathf.Abs(target.x - transform.position.x) >= 5 || (Mathf.Abs(target.y - transform.position.y) >= 5))
                        {
                            EsteLisäAlas = 10;
                        }

                        if (TuhoutuminenAlempiLayer.Instance.rikkitilemap.HasTile(TuhoutuminenAlempiLayer.Instance.rikkitilemap.WorldToCell(paikka + new Vector3(0, -3, 0))))
                        {
                            EsteLisäAlas += 1;
                        }
                        if (Tuhoutuminen.Instance.tilemap.HasTile(Tuhoutuminen.Instance.tilemap.WorldToCell(paikka + new Vector3(0, -3, 0))))
                        {
                            EsteLisäAlas += 4;
                        }
                    }
                    if (Tuhoutuminen.Instance.tilemap.HasTile(Tuhoutuminen.Instance.tilemap.WorldToCell(paikka + new Vector3(0, -2, 0))))
                    {
                        EsteLisäAlas += 1;
                    }
                    SaaRikkoa = true;
                    vihuliikkunut = false;
                    tapahtuma = "2OsioAlas";
                    return;
                }
                else
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
                    EsteLisäYlös = 0;
                    EsteLisäAlas = 0;
                    EsteLisäOikea = 0;
                    EsteLisäVasen = 0;
                    SaaRikkoa = false;
                    return;
                }
            }

            else if (target.x > transform.position.x + EsteLisäOikea && Mathf.Abs(target.x - transform.position.x) < Mathf.Abs(target.y - transform.position.y))
            {
                //xDir = 1f;

                if (TuhoutuminenAlempiLayer.Instance.rikkitilemap.HasTile(TuhoutuminenAlempiLayer.Instance.rikkitilemap.WorldToCell(paikka + new Vector3(1, 0, 0))) && SaaRikkoa == false)
                {
                    EsteLisäOikea = 20;
                    if (Mathf.Abs(target.x - transform.position.x) >= 5 || (Mathf.Abs(target.y - transform.position.y) >= 5))
                    {
                        EsteLisäOikea = 10;
                    }

                    if (Tuhoutuminen.Instance.tilemap.HasTile(Tuhoutuminen.Instance.tilemap.WorldToCell(paikka + new Vector3(1, 0, 0))))
                    {
                        EsteLisäOikea += 1;
                    }
                    if (TuhoutuminenAlempiLayer.Instance.rikkitilemap.HasTile(TuhoutuminenAlempiLayer.Instance.rikkitilemap.WorldToCell(paikka + new Vector3(2, 0, 0))))
                    {
                        EsteLisäOikea += 1;
                        if (Mathf.Abs(target.x - transform.position.x) >= 5 || (Mathf.Abs(target.y - transform.position.y) >= 5))
                        {
                            EsteLisäOikea = 10;
                        }


                        if (TuhoutuminenAlempiLayer.Instance.rikkitilemap.HasTile(TuhoutuminenAlempiLayer.Instance.rikkitilemap.WorldToCell(paikka + new Vector3(3, 0, 0))))
                        {
                            EsteLisäOikea += 1;
                        }
                        if (Tuhoutuminen.Instance.tilemap.HasTile(Tuhoutuminen.Instance.tilemap.WorldToCell(paikka + new Vector3(3, 0, 0))))
                        {
                            EsteLisäOikea += 4;
                        }
                    }
                    if (Tuhoutuminen.Instance.tilemap.HasTile(Tuhoutuminen.Instance.tilemap.WorldToCell(paikka + new Vector3(2, 0, 0))))
                    {
                        EsteLisäOikea += 1;
                    }
                    SaaRikkoa = true;
                    vihuliikkunut = false;
                    tapahtuma = "2OsioOikea";
                    return;
                }
                else
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
                    EsteLisäYlös = 0;
                    EsteLisäAlas = 0;
                    EsteLisäOikea = 0;
                    EsteLisäVasen = 0;
                    SaaRikkoa = false;
                    return;
                }
            }
            else if (target.x + EsteLisäVasen < transform.position.x && Mathf.Abs(target.x - transform.position.x) < Mathf.Abs(target.y - transform.position.y))
            {
                //xDir = -1f;

                if (TuhoutuminenAlempiLayer.Instance.rikkitilemap.HasTile(TuhoutuminenAlempiLayer.Instance.rikkitilemap.WorldToCell(paikka + new Vector3(-1, 0, 0))) && SaaRikkoa == false)
                {
                    EsteLisäVasen = 20;
                    if (Mathf.Abs(target.x - transform.position.x) >= 5 || (Mathf.Abs(target.y - transform.position.y) >= 5))
                    {
                        EsteLisäVasen = 10;
                    }

                    if (Tuhoutuminen.Instance.tilemap.HasTile(Tuhoutuminen.Instance.tilemap.WorldToCell(paikka + new Vector3(-1, 0, 0))))
                    {
                        EsteLisäVasen += 1;
                    }
                    if (TuhoutuminenAlempiLayer.Instance.rikkitilemap.HasTile(TuhoutuminenAlempiLayer.Instance.rikkitilemap.WorldToCell(uusipaikka + new Vector3(-2, 0, 0))))
                    {
                        EsteLisäVasen += 1;
                        if (Mathf.Abs(target.x - transform.position.x) >= 8 || (Mathf.Abs(target.y - transform.position.y) >= 8))
                        {
                            EsteLisäVasen = 10;
                        }


                        if (TuhoutuminenAlempiLayer.Instance.rikkitilemap.HasTile(TuhoutuminenAlempiLayer.Instance.rikkitilemap.WorldToCell(paikka + new Vector3(-3, 0, 0))))
                        {
                            EsteLisäVasen += 1;
                        }
                        if (Tuhoutuminen.Instance.tilemap.HasTile(Tuhoutuminen.Instance.tilemap.WorldToCell(paikka + new Vector3(-3, 0, 0))))
                        {
                            EsteLisäVasen += 4;
                        }
                    }
                    if (Tuhoutuminen.Instance.tilemap.HasTile(Tuhoutuminen.Instance.tilemap.WorldToCell(uusipaikka + new Vector3(-2, 0, 0))))
                    {
                        EsteLisäVasen += 1;
                    }
                    SaaRikkoa = true;
                    vihuliikkunut = false;
                    tapahtuma = "2OsioVasen";
                    return;
                }
                else
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
                    EsteLisäYlös = 0;
                    EsteLisäAlas = 0;
                    EsteLisäOikea = 0;
                    EsteLisäVasen = 0;
                    SaaRikkoa = false;
                    return;
                }
            }








            //------------------------------------------------------------------SAMA MATKA-------------------------------------------------------------------- -









            else if (target.y == transform.position.y + EsteLisäYlös && target.y >= transform.position.y && Mathf.Abs(target.x - transform.position.x) > Mathf.Abs(target.y - transform.position.y))
            {
                //yDir = 1f;

                if (TuhoutuminenAlempiLayer.Instance.rikkitilemap.HasTile(TuhoutuminenAlempiLayer.Instance.rikkitilemap.WorldToCell(paikka + new Vector3(0, 1, 0))) && SaaRikkoa == false)
                {
                    EsteLisäYlös = 20;
                    if (Mathf.Abs(target.x - transform.position.x) >= 5 || (Mathf.Abs(target.y - transform.position.y) >= 5))
                    {
                        EsteLisäYlös = 10;

                    }

                    if (Tuhoutuminen.Instance.tilemap.HasTile(Tuhoutuminen.Instance.tilemap.WorldToCell(paikka + new Vector3(0, 1, 0))))
                    {
                        EsteLisäYlös += 1;
                    }
                    if (TuhoutuminenAlempiLayer.Instance.rikkitilemap.HasTile(TuhoutuminenAlempiLayer.Instance.rikkitilemap.WorldToCell(paikka + new Vector3(0, 2, 0))))
                    {
                        EsteLisäYlös += 1;
                        if (Mathf.Abs(target.x - transform.position.x) >= 5 || (Mathf.Abs(target.y - transform.position.y) >= 5))
                        {
                            EsteLisäYlös = 10;
                        }

                        if (TuhoutuminenAlempiLayer.Instance.rikkitilemap.HasTile(TuhoutuminenAlempiLayer.Instance.rikkitilemap.WorldToCell(paikka + new Vector3(0, 3, 0))))
                        {
                            EsteLisäYlös += 1;
                        }
                        if (Tuhoutuminen.Instance.tilemap.HasTile(Tuhoutuminen.Instance.tilemap.WorldToCell(paikka + new Vector3(0, 3, 0))))
                        {
                            EsteLisäYlös += 4;
                        }
                    }
                    if (Tuhoutuminen.Instance.tilemap.HasTile(Tuhoutuminen.Instance.tilemap.WorldToCell(paikka + new Vector3(0, 2, 0))))
                    {
                        EsteLisäYlös += 1;
                    }
                    SaaRikkoa = true;
                    vihuliikkunut = false;
                    tapahtuma = "3OsioYlös";
                    return;
                }
                else
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
                    EsteLisäYlös = 0;
                    EsteLisäAlas = 0;
                    EsteLisäOikea = 0;
                    EsteLisäVasen = 0;
                    SaaRikkoa = false;
                    return;
                }

            }
            else if (target.y + EsteLisäAlas == transform.position.y && target.y <= transform.position.y && Mathf.Abs(target.x - transform.position.x) > Mathf.Abs(target.y - transform.position.y))
            {
                //yDir = -1f;

                if (TuhoutuminenAlempiLayer.Instance.rikkitilemap.HasTile(TuhoutuminenAlempiLayer.Instance.rikkitilemap.WorldToCell(paikka + new Vector3(0, -1, 0))) && SaaRikkoa == false)
                {
                    EsteLisäAlas = 20;
                    if (Mathf.Abs(target.x - transform.position.x) >= 5 || (Mathf.Abs(target.y - transform.position.y) >= 5))
                    {
                        EsteLisäAlas = 10;
                    }

                    if (Tuhoutuminen.Instance.tilemap.HasTile(Tuhoutuminen.Instance.tilemap.WorldToCell(paikka + new Vector3(0, -1, 0))))
                    {
                        EsteLisäAlas += 1;
                    }
                    if (TuhoutuminenAlempiLayer.Instance.rikkitilemap.HasTile(TuhoutuminenAlempiLayer.Instance.rikkitilemap.WorldToCell(paikka + new Vector3(0, -2, 0))))
                    {
                        EsteLisäAlas += 1;
                        if (Mathf.Abs(target.x - transform.position.x) >= 5 || (Mathf.Abs(target.y - transform.position.y) >= 5))
                        {
                            EsteLisäAlas = 10;
                        }

                        if (TuhoutuminenAlempiLayer.Instance.rikkitilemap.HasTile(TuhoutuminenAlempiLayer.Instance.rikkitilemap.WorldToCell(paikka + new Vector3(0, -3, 0))))
                        {
                            EsteLisäAlas += 1;
                        }
                        if (Tuhoutuminen.Instance.tilemap.HasTile(Tuhoutuminen.Instance.tilemap.WorldToCell(paikka + new Vector3(0, -3, 0))))
                        {
                            EsteLisäAlas += 4;
                        }
                    }
                    if (Tuhoutuminen.Instance.tilemap.HasTile(Tuhoutuminen.Instance.tilemap.WorldToCell(paikka + new Vector3(0, -2, 0))))
                    {
                        EsteLisäAlas += 1;
                    }
                    SaaRikkoa = true;
                    vihuliikkunut = false;
                    tapahtuma = "3OsioAlas";
                    return;
                }
                else
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
                    EsteLisäYlös = 0;
                    EsteLisäAlas = 0;
                    EsteLisäOikea = 0;
                    EsteLisäVasen = 0;
                    SaaRikkoa = false;
                    return;
                }
            }

            else if (target.x == transform.position.x + EsteLisäOikea && target.x >= transform.position.x && Mathf.Abs(target.x - transform.position.x) < Mathf.Abs(target.y - transform.position.y))
            {
                //xDir = 1f;

                if (TuhoutuminenAlempiLayer.Instance.rikkitilemap.HasTile(TuhoutuminenAlempiLayer.Instance.rikkitilemap.WorldToCell(paikka + new Vector3(1, 0, 0))) && SaaRikkoa == false)
                {
                    EsteLisäOikea = 20;
                    if (Mathf.Abs(target.x - transform.position.x) >= 5 || (Mathf.Abs(target.y - transform.position.y) >= 5))
                    {
                        EsteLisäOikea = 10;
                    }

                    if (Tuhoutuminen.Instance.tilemap.HasTile(Tuhoutuminen.Instance.tilemap.WorldToCell(paikka + new Vector3(1, 0, 0))))
                    {
                        EsteLisäOikea += 1;
                    }
                    if (TuhoutuminenAlempiLayer.Instance.rikkitilemap.HasTile(TuhoutuminenAlempiLayer.Instance.rikkitilemap.WorldToCell(paikka + new Vector3(2, 0, 0))))
                    {
                        EsteLisäOikea += 1;
                        if (Mathf.Abs(target.x - transform.position.x) >= 5 || (Mathf.Abs(target.y - transform.position.y) >= 5))
                        {
                            EsteLisäOikea = 10;
                        }


                        if (TuhoutuminenAlempiLayer.Instance.rikkitilemap.HasTile(TuhoutuminenAlempiLayer.Instance.rikkitilemap.WorldToCell(paikka + new Vector3(3, 0, 0))))
                        {
                            EsteLisäOikea += 1;
                        }
                        if (Tuhoutuminen.Instance.tilemap.HasTile(Tuhoutuminen.Instance.tilemap.WorldToCell(paikka + new Vector3(3, 0, 0))))
                        {
                            EsteLisäOikea += 4;
                        }
                    }
                    if (Tuhoutuminen.Instance.tilemap.HasTile(Tuhoutuminen.Instance.tilemap.WorldToCell(paikka + new Vector3(2, 0, 0))))
                    {
                        EsteLisäOikea += 1;
                    }
                    SaaRikkoa = true;
                    vihuliikkunut = false;
                    tapahtuma = "3OsioOikea";
                    return;
                }
                else
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
                    EsteLisäYlös = 0;
                    EsteLisäAlas = 0;
                    EsteLisäOikea = 0;
                    EsteLisäVasen = 0;
                    SaaRikkoa = false;
                    return;
                }
            }
            else if (target.x + EsteLisäVasen == transform.position.x && target.x <= transform.position.x && Mathf.Abs(target.x - transform.position.x) < Mathf.Abs(target.y - transform.position.y))
            {
                //xDir = -1f;

                if (TuhoutuminenAlempiLayer.Instance.rikkitilemap.HasTile(TuhoutuminenAlempiLayer.Instance.rikkitilemap.WorldToCell(paikka + new Vector3(-1, 0, 0))) && SaaRikkoa == false)
                {
                    EsteLisäVasen = 20;
                    if (Mathf.Abs(target.x - transform.position.x) >= 5 || (Mathf.Abs(target.y - transform.position.y) >= 5))
                    {
                        EsteLisäVasen = 10;
                    }

                    if (Tuhoutuminen.Instance.tilemap.HasTile(Tuhoutuminen.Instance.tilemap.WorldToCell(paikka + new Vector3(-1, 0, 0))))
                    {
                        EsteLisäVasen += 1;
                    }
                    if (TuhoutuminenAlempiLayer.Instance.rikkitilemap.HasTile(TuhoutuminenAlempiLayer.Instance.rikkitilemap.WorldToCell(uusipaikka + new Vector3(-2, 0, 0))))
                    {
                        EsteLisäVasen += 1;
                        if (Mathf.Abs(target.x - transform.position.x) >= 5 || (Mathf.Abs(target.y - transform.position.y) >= 5))
                        {
                            EsteLisäVasen = 10;
                        }


                        if (TuhoutuminenAlempiLayer.Instance.rikkitilemap.HasTile(TuhoutuminenAlempiLayer.Instance.rikkitilemap.WorldToCell(paikka + new Vector3(-3, 0, 0))))
                        {
                            EsteLisäVasen += 1;
                        }
                        if (Tuhoutuminen.Instance.tilemap.HasTile(Tuhoutuminen.Instance.tilemap.WorldToCell(paikka + new Vector3(-3, 0, 0))))
                        {
                            EsteLisäVasen += 4;
                        }
                    }
                    if (Tuhoutuminen.Instance.tilemap.HasTile(Tuhoutuminen.Instance.tilemap.WorldToCell(uusipaikka + new Vector3(-2, 0, 0))))
                    {
                        EsteLisäVasen += 1;
                    }
                    SaaRikkoa = true;
                    vihuliikkunut = false;
                    tapahtuma = "3OsioVasen";
                    return;
                }
                else
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
                    EsteLisäYlös = 0;
                    EsteLisäAlas = 0;
                    EsteLisäOikea = 0;
                    EsteLisäVasen = 0;
                    SaaRikkoa = false;
                    return;
                }
            }







            //------------------------------------------------------------------------------ONGELMA 2-------------------------------------------------------------------------------------------------------------------------








            else if (target.y + EsteLisäYlös < transform.position.y && target.y > transform.position.y && Mathf.Abs(target.x - transform.position.x) < Mathf.Abs(target.y - transform.position.y))
            {
                //yDir = 1f;

                if (TuhoutuminenAlempiLayer.Instance.rikkitilemap.HasTile(TuhoutuminenAlempiLayer.Instance.rikkitilemap.WorldToCell(paikka + new Vector3(0, 1, 0))) && SaaRikkoa == false)
                {
                    EsteLisäYlös = 20;
                    if (Mathf.Abs(target.x - transform.position.x) >= 5 || (Mathf.Abs(target.y - transform.position.y) >= 5))
                    {
                        EsteLisäYlös = 10;
                    }

                    if (Tuhoutuminen.Instance.tilemap.HasTile(Tuhoutuminen.Instance.tilemap.WorldToCell(paikka + new Vector3(0, 1, 0))))
                    {
                        EsteLisäYlös += 1;
                    }
                    if (TuhoutuminenAlempiLayer.Instance.rikkitilemap.HasTile(TuhoutuminenAlempiLayer.Instance.rikkitilemap.WorldToCell(paikka + new Vector3(0, 2, 0))))
                    {
                        EsteLisäYlös += 1;
                        if (Mathf.Abs(target.x - transform.position.x) >= 5 || (Mathf.Abs(target.y - transform.position.y) >= 5))
                        {
                            EsteLisäYlös = 10;
                        }

                        if (TuhoutuminenAlempiLayer.Instance.rikkitilemap.HasTile(TuhoutuminenAlempiLayer.Instance.rikkitilemap.WorldToCell(paikka + new Vector3(0, 3, 0))))
                        {
                            EsteLisäYlös += 1;
                        }
                        if (Tuhoutuminen.Instance.tilemap.HasTile(Tuhoutuminen.Instance.tilemap.WorldToCell(paikka + new Vector3(0, 3, 0))))
                        {
                            EsteLisäYlös += 4;
                        }
                    }
                    if (Tuhoutuminen.Instance.tilemap.HasTile(Tuhoutuminen.Instance.tilemap.WorldToCell(paikka + new Vector3(0, 2, 0))))
                    {
                        EsteLisäYlös += 1;
                    }
                    SaaRikkoa = true;
                    vihuliikkunut = false;
                    tapahtuma = "4OsioYlös";
                    return;
                }
                else
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
                    EsteLisäYlös = 0;
                    EsteLisäAlas = 0;
                    EsteLisäOikea = 0;
                    EsteLisäVasen = 0;
                    SaaRikkoa = false;
                    return;
                }

            }
            else if (target.y > transform.position.y + EsteLisäAlas && target.y < transform.position.y && Mathf.Abs(target.x - transform.position.x) < Mathf.Abs(target.y - transform.position.y))
            {
                //yDir = -1f;

                if (TuhoutuminenAlempiLayer.Instance.rikkitilemap.HasTile(TuhoutuminenAlempiLayer.Instance.rikkitilemap.WorldToCell(paikka + new Vector3(0, -1, 0))) && SaaRikkoa == false)
                {
                    EsteLisäAlas = 20;
                    if (Mathf.Abs(target.x - transform.position.x) >= 5 || (Mathf.Abs(target.y - transform.position.y) >= 5))
                    {
                        EsteLisäAlas = 10;
                    }

                    if (Tuhoutuminen.Instance.tilemap.HasTile(Tuhoutuminen.Instance.tilemap.WorldToCell(paikka + new Vector3(0, -1, 0))))
                    {
                        EsteLisäAlas += 1;
                    }
                    if (TuhoutuminenAlempiLayer.Instance.rikkitilemap.HasTile(TuhoutuminenAlempiLayer.Instance.rikkitilemap.WorldToCell(paikka + new Vector3(0, -2, 0))))
                    {
                        EsteLisäAlas += 1;
                        if (Mathf.Abs(target.x - transform.position.x) >= 5 || (Mathf.Abs(target.y - transform.position.y) >= 5))
                        {
                            EsteLisäAlas = 10;
                        }

                        if (TuhoutuminenAlempiLayer.Instance.rikkitilemap.HasTile(TuhoutuminenAlempiLayer.Instance.rikkitilemap.WorldToCell(paikka + new Vector3(0, -3, 0))))
                        {
                            EsteLisäAlas += 1;
                        }
                        if (Tuhoutuminen.Instance.tilemap.HasTile(Tuhoutuminen.Instance.tilemap.WorldToCell(paikka + new Vector3(0, -3, 0))))
                        {
                            EsteLisäAlas += 4;
                        }
                    }
                    if (Tuhoutuminen.Instance.tilemap.HasTile(Tuhoutuminen.Instance.tilemap.WorldToCell(paikka + new Vector3(0, -2, 0))))
                    {
                        EsteLisäAlas += 1;
                    }
                    SaaRikkoa = true;
                    vihuliikkunut = false;
                    tapahtuma = "4OsioAlas";
                    return;
                }
                else
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
                    EsteLisäYlös = 0;
                    EsteLisäAlas = 0;
                    EsteLisäOikea = 0;
                    EsteLisäVasen = 0;
                    SaaRikkoa = false;
                    return;
                }
            }

            else if (target.x + EsteLisäOikea < transform.position.x && target.x > transform.position.x && Mathf.Abs(target.x - transform.position.x) > Mathf.Abs(target.y - transform.position.y))
            {
                //xDir = 1f;

                if (TuhoutuminenAlempiLayer.Instance.rikkitilemap.HasTile(TuhoutuminenAlempiLayer.Instance.rikkitilemap.WorldToCell(paikka + new Vector3(1, 0, 0))) && SaaRikkoa == false)
                {
                    EsteLisäOikea = 20;
                    if (Mathf.Abs(target.x - transform.position.x) >= 5 || (Mathf.Abs(target.y - transform.position.y) >= 5))
                    {
                        EsteLisäOikea = 10;
                    }

                    if (Tuhoutuminen.Instance.tilemap.HasTile(Tuhoutuminen.Instance.tilemap.WorldToCell(paikka + new Vector3(1, 0, 0))))
                    {
                        EsteLisäOikea += 1;
                    }
                    if (TuhoutuminenAlempiLayer.Instance.rikkitilemap.HasTile(TuhoutuminenAlempiLayer.Instance.rikkitilemap.WorldToCell(paikka + new Vector3(2, 0, 0))))
                    {
                        EsteLisäOikea += 1;
                        if (Mathf.Abs(target.x - transform.position.x) >= 5 || (Mathf.Abs(target.y - transform.position.y) >= 5))
                        {
                            EsteLisäOikea = 10;
                        }


                        if (TuhoutuminenAlempiLayer.Instance.rikkitilemap.HasTile(TuhoutuminenAlempiLayer.Instance.rikkitilemap.WorldToCell(paikka + new Vector3(3, 0, 0))))
                        {
                            EsteLisäOikea += 1;
                        }
                        if (Tuhoutuminen.Instance.tilemap.HasTile(Tuhoutuminen.Instance.tilemap.WorldToCell(paikka + new Vector3(3, 0, 0))))
                        {
                            EsteLisäOikea += 4;
                        }
                    }
                    if (Tuhoutuminen.Instance.tilemap.HasTile(Tuhoutuminen.Instance.tilemap.WorldToCell(paikka + new Vector3(2, 0, 0))))
                    {
                        EsteLisäOikea += 1;
                    }
                    SaaRikkoa = true;
                    vihuliikkunut = false;
                    tapahtuma = "4OsioOikea";
                    return;
                }
                else
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
                    EsteLisäYlös = 0;
                    EsteLisäAlas = 0;
                    EsteLisäOikea = 0;
                    EsteLisäVasen = 0;
                    SaaRikkoa = false;
                    return;
                }
            }
            else if (target.x > transform.position.x + EsteLisäVasen && target.x < transform.position.x && Mathf.Abs(target.x - transform.position.x) > Mathf.Abs(target.y - transform.position.y))
            {
                //xDir = -1f;

                if (TuhoutuminenAlempiLayer.Instance.rikkitilemap.HasTile(TuhoutuminenAlempiLayer.Instance.rikkitilemap.WorldToCell(paikka + new Vector3(-1, 0, 0))) && SaaRikkoa == false)
                {
                    EsteLisäVasen = 20;
                    if (Mathf.Abs(target.x - transform.position.x) >= 5 || (Mathf.Abs(target.y - transform.position.y) >= 5))
                    {
                        EsteLisäVasen = 10;
                    }

                    if (Tuhoutuminen.Instance.tilemap.HasTile(Tuhoutuminen.Instance.tilemap.WorldToCell(paikka + new Vector3(-1, 0, 0))))
                    {
                        EsteLisäVasen += 1;
                    }
                    if (TuhoutuminenAlempiLayer.Instance.rikkitilemap.HasTile(TuhoutuminenAlempiLayer.Instance.rikkitilemap.WorldToCell(uusipaikka + new Vector3(-2, 0, 0))))
                    {
                        EsteLisäVasen += 1;
                        if (Mathf.Abs(target.x - transform.position.x) >= 5 || (Mathf.Abs(target.y - transform.position.y) >= 5))
                        {
                            EsteLisäVasen = 10;
                        }


                        if (TuhoutuminenAlempiLayer.Instance.rikkitilemap.HasTile(TuhoutuminenAlempiLayer.Instance.rikkitilemap.WorldToCell(paikka + new Vector3(-3, 0, 0))))
                        {
                            EsteLisäVasen += 1;
                        }
                        if (Tuhoutuminen.Instance.tilemap.HasTile(Tuhoutuminen.Instance.tilemap.WorldToCell(paikka + new Vector3(-3, 0, 0))))
                        {
                            EsteLisäVasen += 4;
                        }
                    }
                    if (Tuhoutuminen.Instance.tilemap.HasTile(Tuhoutuminen.Instance.tilemap.WorldToCell(uusipaikka + new Vector3(-2, 0, 0))))
                    {
                        EsteLisäVasen += 1;
                    }
                    SaaRikkoa = true;
                    vihuliikkunut = false;
                    tapahtuma = "4OsioVasen";
                    return;
                }
                else
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
                    EsteLisäYlös = 0;
                    EsteLisäAlas = 0;
                    EsteLisäOikea = 0;
                    EsteLisäVasen = 0;
                    SaaRikkoa = false;
                    return;
                }
            }


        }
    }
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {


        // is the other object a player?
        if (otherCollider.tag == "Player")
        {

            SceneManager.LoadScene("HamsteriScene");


            //if (userInterface != null)
            //{
            //    // add one point
            //    int playerId = (playerTag == "Player") ? 0 : 1;
            //    userInterface.AddOnePoint(playerId);
            //}

            // then destroy this object
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Physics2D.IgnoreLayerCollision(28, 28);

    }
}



