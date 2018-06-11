using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthitTokaTaso : MonoBehaviour {

    public Text HealthTeksti;
    //public Text KypäräHealthTeksti;
    //public Text HitsausHealthTeksti;

    // Use this for initialization
    void Start()
    {
        HealthTeksti = GetComponent<Text>();
        //KypäräHealthTeksti = GetComponent<Text>();
        //HitsausHealthTeksti = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        HealthTeksti.text = "Health: " + LiikkuminenYksin.Instance.PelaajanHealth / 2 + "\r\n" + "Kypärä: " + LiikkuminenYksin.Instance.KypäränHealth / 2 + "\r\n" + "Rakettibensa: " + LiikkuminenYksin.Instance.RakettiBensa;
        //KypäräHealthTeksti.text = "Kypärä " + RuutuLiikkuminen3.Instance.KypäränHealth;
        //HitsausHealthTeksti.text = "Sauva " + RuutuLiikkuminen3.Instance.HitsausHealth;
    }
}
