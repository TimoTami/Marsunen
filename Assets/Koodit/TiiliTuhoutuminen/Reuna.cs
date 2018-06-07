using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Reuna : MonoBehaviour {

    public GameObject PelaajaGameObject;
    public GameObject VihuGameObject;
    public GameObject VihuGameObject2;
    public Tilemap ReunaTilemap;

    public static Reuna Instance;

    void Awake()
    {
        Instance = this;
    }
    // Use this for initialization
    void Start()
    {
        ReunaTilemap = GameObject.Find("IlmastointiReunaTilemap").GetComponent<Tilemap>();
    }
    
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OnCollisionEnter2D(Collision2D collision)
    {
        foreach (ContactPoint2D hit in collision.contacts)
        {
            if (PelaajaGameObject == collision.gameObject)
            {

                if (RuutuLiikkuminen3.Instance.Kypärä == true)
                {
                    RuutuLiikkuminen3.Instance.KypäränHealth -= 1;
                }
                if (RuutuLiikkuminen3.Instance.Kypärä == false)
                {
                    RuutuLiikkuminen3.Instance.PelaajanHealth -= 1;
                }

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


            if (VihuGameObject == collision.gameObject)
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
            if (VihuGameObject2 == collision.gameObject)
            {

                if (VihuLiikkuminenEiAgressiivinen.Instance.VihuViimeliike == "ylös")
                {
                    VihuLiikkuminenEiAgressiivinen.Instance.uusipaikka += new Vector3(0f, -0.5f, 0f);
                }
                else if (VihuLiikkuminenEiAgressiivinen.Instance.VihuViimeliike == "alas")
                {
                    VihuLiikkuminenEiAgressiivinen.Instance.uusipaikka += new Vector3(0f, 0.5f, 0f);
                }
                else if (VihuLiikkuminenEiAgressiivinen.Instance.VihuViimeliike == "vasen")
                {
                    VihuLiikkuminenEiAgressiivinen.Instance.uusipaikka += new Vector3(0.5f, 0f, 0f);
                }
                else if (VihuLiikkuminenEiAgressiivinen.Instance.VihuViimeliike == "oikea")
                {
                    VihuLiikkuminenEiAgressiivinen.Instance.uusipaikka += new Vector3(-0.5f, 0f, 0f);
                }

                VihuLiikkuminenEiAgressiivinen.Instance.transform.position = Vector3.MoveTowards(VihuLiikkuminenEiAgressiivinen.Instance.transform.position, VihuLiikkuminenEiAgressiivinen.Instance.uusipaikka, Time.deltaTime * VihuLiikkuminenEiAgressiivinen.Instance.vihuspeed);
                VihuLiikkuminenEiAgressiivinen.Instance.paikka = VihuLiikkuminenEiAgressiivinen.Instance.uusipaikka;
                VihuLiikkuminenEiAgressiivinen.Instance.transform.position = VihuLiikkuminenEiAgressiivinen.Instance.paikka;
                VihuLiikkuminenEiAgressiivinen.Instance.vihuliikkunut = true;



            }
        }
    }
}
