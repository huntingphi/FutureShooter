using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplayerAIFire : MonoBehaviour {
	public GameObject target_object;
	string target;
    // Use this for initialization
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
		target = target_object.name;

    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            GameObject player_object = GameObject.Find(target);
            if (player_object != null) player = player_object.transform;
        }
        if (player == null) return;

        cool_down_timer -= Time.deltaTime;
        if (cool_down_timer <= 0 && player != null && Vector3.Distance(transform.position, player.position) < 9)
        {
            cool_down_timer = fire_delay;
            Vector3 bullet_position = transform.position + transform.rotation * offset;
            GameObject bullet_object = (GameObject)Instantiate(bulletPrefab, bullet_position, transform.rotation);
            bullet_object.layer = bullet_layer;
        }
    }
}
