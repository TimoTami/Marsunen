using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitsausKeräily : MonoBehaviour {

    // Use this for initialization
    private void Start()
    {
 
    }




    private void OnTriggerEnter2D(Collider2D otherCollider)
    {


  
        if (otherCollider.tag == "Player")
        {

            Destroy(gameObject);
            RuutuLiikkuminen3.Instance.Hitsaus = true;
            RuutuLiikkuminen3.Instance.HitsausHealth = 5;


  
        }
    }
}

