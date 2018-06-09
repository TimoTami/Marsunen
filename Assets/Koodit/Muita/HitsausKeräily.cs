using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitsausKeräily : MonoBehaviour {

    // Use this for initialization
    private void Start()
    {
        // Find the UI in the scene and store a reference for later use
        //userInterface = GameObject.FindObjectOfType<UIScript>();
    }



    // This function gets called everytime this object collides with another
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {


        // is the other object a player?
        if (otherCollider.tag == "Player")
        {

            Destroy(gameObject);
            RuutuLiikkuminen3.Instance.Hitsaus = true;
            RuutuLiikkuminen3.Instance.HitsausHealth = 4;


            //if (userInterface != null)
            //{
            //    // add one point
            //    int playerId = (playerTag == "Player") ? 0 : 1;
            //    userInterface.AddOnePoint(playerId);
            //}

            // then destroy this object
        }
    }
}

