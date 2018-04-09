using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Fire : MonoBehaviour
{
    int bullet_layer;
    public GameObject bulletPrefab;
    public float fire_delay = 0.25f;

    public Vector3 offset = new Vector3(0, 0.5f, 0);
    float cool_down_timer;
    // Use this for initialization
    void Start()
    {
        bullet_layer = gameObject.layer;
    }

    // Update is called once per frame
    void Update()
    {
        cool_down_timer -= Time.deltaTime;
        if (Input.GetButton("Fire2") && cool_down_timer <= 0)
        {
            cool_down_timer = fire_delay;
            Vector3 bullet_position = transform.position + transform.rotation * offset;
            GameObject bullet_object = (GameObject)Instantiate(bulletPrefab, bullet_position, transform.rotation);
            bullet_object.layer = bullet_layer;

        }
    }
}
