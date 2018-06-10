using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MarsuVartaassa : MonoBehaviour {

    

    // Use this for initialization
    void Start () {
        //StartCoroutine(Odota());
        
        
    }
    //IEnumerator Odota()
    //{
    //    yield return new WaitForSecondsRealtime(4);
    //    SceneManager.LoadScene("HamsteriScene");

    //}

    // Update is called once per frame
    void Update () {

        if(Input.anyKey)

        SceneManager.LoadScene("HamsteriScene");
    }
}
