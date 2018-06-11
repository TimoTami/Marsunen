using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class KuumaTiiliTokaTaso : MonoBehaviour {

    bool polttaa;

    //Tilemap KuumaTilemap;
	// Use this for initialization
	void Start () {
        //KuumaTilemap = GameObject.Find("Kuuma").GetComponent<Tilemap>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (polttaa==false)
        if (otherCollider.tag == "Player")
        {

            // KuumaTilemap.SetTile(LiikkuminenYksin.Instance.PosInt, null);
            polttaa = true;
            
            LiikkuminenYksin.Instance.PelaajanHealth -= 2;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        polttaa = false;
    }
}
