using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MarsuJaRottaVartaassa : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //StartCoroutine(Odota());
    }
	//IEnumerator Odota()
 //   {
 //       yield return new WaitForSecondsRealtime(12);
 //       SceneManager.LoadScene("HamsteriScene");

 //   }
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Return))

            SceneManager.LoadScene("HamsteriScene");
    }
}
