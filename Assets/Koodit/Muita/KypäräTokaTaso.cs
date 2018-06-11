using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KypäräTokaTaso : MonoBehaviour {

	void Start () {
		
	}
	
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {

        if (otherCollider.tag == "Player")
        {
            Destroy(gameObject);
            LiikkuminenYksin.Instance.Kypärä = true;
            LiikkuminenYksin.Instance.KypäränHealth += 20;
        }
    }
}
