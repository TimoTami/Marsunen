﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PelinUudelleenAloitus : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
            if (Input.GetKey(KeyCode.Return))

                SceneManager.LoadScene("1TasoMarsu");
        
    }
}