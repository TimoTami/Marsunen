using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ReunaTokaTaso : MonoBehaviour {

    public GameObject PelaajaGameObject;
    public GameObject VihuGameObject;
    public GameObject VihuGameObject2;
    public Tilemap ReunaTilemap;

    public static ReunaTokaTaso Instance;

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
    void Update()
    {

    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        foreach (ContactPoint2D hit in collision.contacts)
        {
            if (PelaajaGameObject == collision.gameObject)
            {

                if (LiikkuminenYksin.Instance.Kypärä == true)
                {
                    LiikkuminenYksin.Instance.KypäränHealth -= 1;
                }
                if (LiikkuminenYksin.Instance.Kypärä == false)
                {
                    LiikkuminenYksin.Instance.PelaajanHealth -= 1;
                }

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
                else if (LiikkuminenYksin.Instance.PelaajaViimeliike == "oikea")
                {
                    LiikkuminenYksin.Instance.pos += new Vector3(-0.5f, 0f, 0f);
                }

                LiikkuminenYksin.Instance.transform.position = Vector3.MoveTowards(LiikkuminenYksin.Instance.transform.position, LiikkuminenYksin.Instance.pos, Time.deltaTime * LiikkuminenYksin.Instance.speed);

                

            }
            
        }
    }
}
