using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour {
    private bool ZoomIn = false;
    private bool ZoomOut = false;

    public float zoom = 10;
    private void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {

        
        



        if (Input.GetKeyDown ("1"))
        {
            //if (ZoomIn == false)
            //{
            //zoom-=zoom-1;
            
                if (zoom<20)
            
                zoom += 1;
            
            
                //ZoomIn = true;
            //}
            
        }
        if (Input.GetKeyDown ("2"))
        {
            //if (ZoomOut == false)
            //{
            //zoom+=zoom+1;

            
                if (zoom > 2)

                    zoom -= 1;
            

            //ZoomOut = true;
            //}

        }
        //if (Input.GetAxis("Zoom") == 0)
        //{
          //  ZoomIn = false;
            //ZoomOut = false;
        //}

        GetComponent<Camera>().orthographicSize = zoom;

    }
}
