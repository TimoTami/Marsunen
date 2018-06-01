using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class VihuLiikkuminen : MonoBehaviour {


    bool vihuliikkunut;
    public Vector3 target;
    public Vector3 paikka;
    public Vector3 uusipaikka;
    public Vector3 suunta;
    public float matkaX;
    public Vector3 matkaY;
    public float vihuspeed = 0.1f;
    public string VihuViimeliike;
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


    public static VihuLiikkuminen Instance;
 
    
    void Awake()
    {
        Instance = this;
    }

    
    void Start () {
        paikka = transform.position;
        uusipaikka = transform.position; 
    }
	
	
	void Update()
    {
         
         target =  RuutuLiikkuminen3.Instance.transform.position;
        

        File.WriteAllText(targetpositio, target.ToString());

       
        if (RuutuLiikkuminen3.Instance.liikkunut==true&&transform.position==uusipaikka)
        {
            
            matkaX = Vector3.Distance(target, transform.position);
            
            

            if (target.y > transform.position.y && Mathf.Abs(target.x - transform.position.x) <= Mathf.Abs(target.y - transform.position.y))
            {
                //yDir = 1f;
                suunta = Vector3.up;
                uusipaikka = suunta + paikka;
                //transform.position = paikka + suunta ;
                transform.position =Vector3.MoveTowards (paikka, uusipaikka, Time.deltaTime*vihuspeed);
                paikka = uusipaikka;
                transform.position = paikka;
                VihuViimeliike = "ylös";
                File.WriteAllText(testausylös, ("tapahtuiylös"));

            }
            else if (target.y < transform.position.y && Mathf.Abs(target.x - transform.position.x) <= Mathf.Abs(target.y - transform.position.y))
            {
                //yDir = -1f;
                suunta = Vector3.down;
                uusipaikka = suunta + paikka;
                //transform.position = paikka + suunta ;
                transform.position =Vector3.MoveTowards (paikka, uusipaikka, Time.deltaTime*vihuspeed);
                paikka = uusipaikka;
                transform.position = paikka;
                VihuViimeliike = "alas";
                File.WriteAllText(testausalas, ("tapahtuialas"));
            }
            //if (target.y == transform.position.y && Mathf.Abs(target.x + transform.position.x) <= Mathf.Abs(target.y + transform.position.y))
            //{
            //    //yDir = 1f;
            //    suunta = Vector3.up;
            //    uusipaikka = suunta + paikka;
            //    //transform.position = paikka + suunta ;
            //    transform.position = Vector3.MoveTowards(paikka, uusipaikka, Time.deltaTime * vihuspeed);
            //    paikka = uusipaikka;
            //    transform.position = paikka;
            //    File.WriteAllText(testausylös, ("tapahtuiylös"));

            //}
            //if (target.y == transform.position.y && Mathf.Abs(target.x + transform.position.x) <= Mathf.Abs(target.y + transform.position.y))
            //{
            //    //yDir = 1f;
            //    suunta = Vector3.up;
            //    uusipaikka = suunta + paikka;
            //    //transform.position = paikka + suunta ;
            //    transform.position = Vector3.MoveTowards(paikka, uusipaikka, Time.deltaTime * vihuspeed);
            //    paikka = uusipaikka;
            //    transform.position = paikka;
            //    File.WriteAllText(testausylös, ("tapahtuiylös"));

            //}
            else if (target.x > transform.position.x && Mathf.Abs(target.x - transform.position.x) >= Mathf.Abs(target.y - transform.position.y))
            {
                //xDir = 1f;
                suunta = Vector3.right;
                uusipaikka = suunta + paikka;
                //transform.position = paikka + suunta ;
                transform.position = Vector3.MoveTowards(paikka, uusipaikka, Time.deltaTime * vihuspeed);
                paikka = uusipaikka;
                transform.position = paikka;
                VihuViimeliike = "oikea";
                File.WriteAllText(testausoikea, ("tapahtuioikea"));
            }
            else if (target.x < transform.position.x && Mathf.Abs(target.x - transform.position.x) >= Mathf.Abs(target.y - transform.position.y))
            {
                //xDir = -1f;
                suunta = Vector3.left;
                uusipaikka = suunta + paikka;
                //transform.position = paikka + suunta ;
                transform.position = Vector3.MoveTowards(paikka, uusipaikka, Time.deltaTime * vihuspeed);
                paikka = uusipaikka;
                transform.position = paikka;
                VihuViimeliike = "vasen";
                File.WriteAllText(testausvasen, ("tapahtuivasen"));
            }
            //else if (target.x == transform.position.x && Mathf.Abs(target.x + transform.position.x) <= Mathf.Abs(target.y + transform.position.y))
            //{
            //    //xDir = -1f;
            //    suunta = Vector3.left;
            //    uusipaikka = suunta + paikka;
            //    //transform.position = paikka + suunta ;
            //    transform.position = Vector3.MoveTowards(paikka, uusipaikka, Time.deltaTime * vihuspeed);
            //    paikka = uusipaikka;
            //    transform.position = paikka;
            //    File.WriteAllText(testausvasen, ("tapahtuivasen"));
            //}
            //if (target.x == transform.position.x && Mathf.Abs(target.x + transform.position.x) >= Mathf.Abs(target.y + transform.position.y))
            //{
            //    //xDir = -1f;
            //    suunta = Vector3.left;
            //    uusipaikka = suunta + paikka;
            //    //transform.position = paikka + suunta ;
            //    transform.position = Vector3.MoveTowards(paikka, uusipaikka, Time.deltaTime * vihuspeed);
            //    paikka = uusipaikka;
            //    transform.position = paikka;
            //    File.WriteAllText(testausvasen, ("tapahtuivasen"));
            //}

            //else
            //{
            //    //yDir = -1f;
            //    suunta = Vector3.down;
            //    uusipaikka = suunta + paikka;
            //    //transform.position = paikka + suunta ;
            //    transform.position = Vector3.MoveTowards(paikka, uusipaikka, Time.deltaTime * vihuspeed);
            //    paikka = uusipaikka;
            //    transform.position = paikka;
            //    File.WriteAllText(testausalas, ("tapahtuialas"));
            //}
        }
    }

  
}
