using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class KuumaTiiliTokaTaso : MonoBehaviour {

    bool polttaa;
    AudioSource palaminen;

    //Tilemap KuumaTilemap;
    // Use this for initialization
    void Start () {
        palaminen = GetComponent<AudioSource>();
        //KuumaTilemap = GameObject.Find("Kuuma").GetComponent<Tilemap>();
    }
	
	// Update is called once per frame
	void Update () {
		//if(TuhoutuminenTokaTasoAlempiLayer.Instance.rikkitilemap.HasTile(new Vector3Int((int)transform.position.x, (int)transform.position.y, 0)) == true)
  //      {
  //          Physics2D.IgnoreLayerCollision(14, 29, true);
  //      }
  //      else
  //      {
  //          Physics2D.IgnoreLayerCollision(14, 29, false);
  //      }
	}
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (polttaa==false)
        if (otherCollider.tag == "Player")
        {
                
                palaminen.Play();
                
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
