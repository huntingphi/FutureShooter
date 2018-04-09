using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFire : MonoBehaviour {
	int bullet_layer;
    public GameObject bulletPrefab;
    public float fire_delay = 0.5f;

    public Vector3 offset = new Vector3(0, 0.5f, 0);
    float cool_down_timer;

    Transform player;

    // Use this for initialization
    void Start()
    {
        bullet_layer = gameObject.layer;

    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            GameObject player_object = GameObject.Find("Player1");
            if (player_object != null) player = player_object.transform;
        }
        if (player == null) return;
		
        cool_down_timer -= Time.deltaTime;
        if (cool_down_timer <= 0&&player != null &&Vector3.Distance(transform.position,player.position)<3)
        {
            cool_down_timer = fire_delay;
            Debug.Log("Pew!");
            Vector3 bullet_position = transform.position + transform.rotation * offset;
            GameObject bullet_object = (GameObject)Instantiate(bulletPrefab, bullet_position, transform.rotation);
			bullet_object.layer = bullet_layer;
		}
    }
}
