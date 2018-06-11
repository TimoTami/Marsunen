using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BensaaTokaTaso : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    }
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {


        // is the other object a player?
        if (otherCollider.tag == "Player")
        {
            LiikkuminenYksin.Instance.RakettiBensa += 20;
            Destroy(gameObject);
        }
    }
}
