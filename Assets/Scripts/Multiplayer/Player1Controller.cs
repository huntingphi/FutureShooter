using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Controller : MonoBehaviour
{

    float max_speed = 5f;
    float max_rotation_speed = 180f;

    float object_radius = 0.5f;
    Vector3 last_inbound_position = new Vector3();

	public bool restrict_bounds = false;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!outOfBounds(transform.position.x, transform.position.y, object_radius)||!restrict_bounds)
        {
            last_inbound_position = transform.position;
            //Rotations
            Quaternion rotation;
            {
                rotation = transform.rotation;
                float z = rotation.eulerAngles.z;
                z -= Input.GetAxis("Horizontal") * max_rotation_speed * Time.deltaTime;//-= otherwise right arrow rotates left (bc left rotation results in positive angle)
                rotation = Quaternion.Euler(0, 0, z);
                transform.rotation = rotation;
            }

            //Movement
            {
                Vector3 pos = transform.position;

                Vector3 v = new Vector3(0, Input.GetAxis("Vertical") * max_speed * Time.deltaTime, 0);
                pos += rotation * v;
                transform.position = pos;
            }
        }
        else
        {
            transform.position = last_inbound_position;
        }



    }


    bool outOfBounds(float x_pos, float y_pos, float object_radius)
    {
        // float abs_x_bound = Camera.main.orthographicSize * ((float)Screen.width / (float)Screen.height);
        // float abs_y_bound = Camera.main.orthographicSize;
        // if (x_pos + object_radius > abs_x_bound) return true;
        // if (x_pos - object_radius < -abs_x_bound) return true;
        // if (y_pos + object_radius > abs_y_bound) return true;
        // if (y_pos - object_radius < -abs_y_bound) return true;
        return false;
    }
}
