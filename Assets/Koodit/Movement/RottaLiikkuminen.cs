using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RottaLiikkuminen : MonoBehaviour {

    public bool OnkoSuuntaVasempaan;
    public int MatkaVasen;
    public int MatkaOikea;
    public Vector3 RotanPaikka;
    public bool RottaLiikkunut;


    
    void Start () {
        RotanPaikka = transform.position;
        MatkaVasen = 0;
        MatkaOikea = 0;
        OnkoSuuntaVasempaan = true;
        transform.right = (RotanPaikka+Vector3.left) - transform.position;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (MatkaVasen <= 20 && OnkoSuuntaVasempaan==true)
        {
            if (RuutuLiikkuminen3.Instance.liikkunut == true && transform.position == RotanPaikka && VihuLiikkuminen.Instance.vihuliikkunut == true && VihuLiikkuminenEiAgressiivinen.Instance.vihuliikkunut == true)
            {
                transform.position = RotanPaikka + new Vector3(-3, 0, 0);
                RotanPaikka = transform.position;
                transform.right = (RotanPaikka + Vector3.left) - transform.position;
                MatkaVasen += 1;
            }
            if (MatkaVasen == 21)
            {
                MatkaVasen = 0;
                OnkoSuuntaVasempaan = false;
            }
            
        }
        if (MatkaOikea <= 20 && OnkoSuuntaVasempaan == false)
        {
            if (RuutuLiikkuminen3.Instance.liikkunut == true && transform.position == RotanPaikka && VihuLiikkuminen.Instance.vihuliikkunut == true && VihuLiikkuminenEiAgressiivinen.Instance.vihuliikkunut == true)
            {
                transform.position = RotanPaikka + new Vector3(3, 0, 0);
                RotanPaikka = transform.position;
                transform.right = (RotanPaikka + Vector3.right) - transform.position;
                MatkaOikea += 1;
            }
            if (MatkaOikea == 21)
            {
                MatkaOikea = 0;
                OnkoSuuntaVasempaan = true;
            }
        }
        
	}
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider.tag == "Player")
        {

            SceneManager.LoadScene("MarsuJaRottaVartaassaScene");



        }
    }
}
