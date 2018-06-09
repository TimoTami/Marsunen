using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthit : MonoBehaviour {

    public Text HealthTeksti;
    //public Text KypäräHealthTeksti;
    //public Text HitsausHealthTeksti;

	// Use this for initialization
	void Start () {
        HealthTeksti = GetComponent<Text>();
        //KypäräHealthTeksti = GetComponent<Text>();
        //HitsausHealthTeksti = GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        HealthTeksti.text = "Health " + RuutuLiikkuminen3.Instance.PelaajanHealth +"\r\n" + "Kypärä " + RuutuLiikkuminen3.Instance.KypäränHealth +"\r\n" + "Sauva " + RuutuLiikkuminen3.Instance.HitsausHealth;
        //KypäräHealthTeksti.text = "Kypärä " + RuutuLiikkuminen3.Instance.KypäränHealth;
        //HitsausHealthTeksti.text = "Sauva " + RuutuLiikkuminen3.Instance.HitsausHealth;
    }
}
