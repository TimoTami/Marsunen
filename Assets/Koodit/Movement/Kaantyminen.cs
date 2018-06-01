using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kaantyminen : MonoBehaviour {

    private int speed1 = 1;
    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            var angle = (Mathf.Sin(Time.time * speed1) + 1) / 2 * 90;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }

        if (Input.GetKey(KeyCode.D))
        {
            var angle = (Mathf.Sin(Time.time * speed1) + 1) / 2 * 90;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.back);
        }
        if (Input.GetKey(KeyCode.S))
        {
            var angle = (Mathf.Sin(Time.time * speed1) + 1) / 2 * 90;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
        if (Input.GetKey(KeyCode.W))
        {
            var angle = (Mathf.Sin(Time.time * speed1) + 1) / 2 * 90;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.back);

        }
    }
        }
