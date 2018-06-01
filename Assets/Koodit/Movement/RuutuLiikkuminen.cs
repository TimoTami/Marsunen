using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Movement/RuutuLiikkuminen")]
[RequireComponent(typeof(Rigidbody2D))]
public class RuutuLiikkuminen : MonoBehaviour
{

    //public Enums.Directions lookAxis = 0;

    Vector3 pos;                                // For movement
    float speed = 2.0f;                         // Speed of movement
    float tiltAngle = 90.0f;
    float smooth = 55.0f;



    void Start()
    {
        pos = transform.position;          // Take the initial position
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A) && transform.position == pos)
        {
            if (Input.GetAxis("Horizontal") == -1)
            {        // Left
                pos += Vector3.left;
                //lookAxis = Enums.Directions.Up;
                //Utils.SetAxisTowards(lookAxis, transform, pos);
            }
        }
        if (Input.GetKey(KeyCode.D) && transform.position == pos)
        {
            if (Input.GetAxis("Horizontal") == 1)

            {        // Right
                pos += Vector3.right;
                //lookAxis = Enums.Directions.Down;
                //Utils.SetAxisTowards(lookAxis, transform, pos);
            }
        }
        if (Input.GetKey(KeyCode.W) && transform.position == pos)
            if (Input.GetAxis("Vertical") == 1)
            {


                {        // Up
                    pos += Vector3.up;
                    //lookAxis = Enums.Directions.Left;
                    //Utils.SetAxisTowards(lookAxis, transform, pos);
                }
            }
        if (Input.GetKey(KeyCode.S) && transform.position == pos)
        {
            if (Input.GetAxis("Vertical") == -1)
            {        // Down
                pos += Vector3.down;
                //lookAxis = Enums.Directions.Right;
                //Utils.SetAxisTowards(lookAxis, transform, pos);
            }
        }

        float tiltAroundZ = Input.GetAxis("Horizontal") * tiltAngle;
        float tiltAroundX = Input.GetAxis("Vertical") * tiltAngle;

        Quaternion target = Quaternion.Euler(0, 0, tiltAroundZ);

        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);

        transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime * speed);    // Move there
        




    }
}
