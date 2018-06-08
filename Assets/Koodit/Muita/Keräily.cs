using UnityEngine;
using System.Collections;

[AddComponentMenu("Playground/Attributes/Collectable")]
[RequireComponent(typeof(Collider2D))]
public class Keräily : MonoBehaviour
{
    


    // Start is called at the beginning
    private void Start()
    {
        // Find the UI in the scene and store a reference for later use
        //userInterface = GameObject.FindObjectOfType<UIScript>();
    }



    // This function gets called everytime this object collides with another
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        

        // is the other object a player?
        if (otherCollider.tag=="Player")
        {
            
            Destroy(gameObject);
            RuutuLiikkuminen3.Instance.Kypärä = true;
            RuutuLiikkuminen3.Instance.KypäränHealth = 20;


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
