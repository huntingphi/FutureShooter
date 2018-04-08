using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplayerSpawner : MonoBehaviour
{
    public int no_lives = 4;
    public GameObject player;

    public GameObject player_prefab;

    GameObject player_instance;
    float respawn_timer = 1f;

    GameObject[] Spawns;
    // Use this for initialization
    void Start()
    {
        Spawns = GameObject.FindGameObjectsWithTag(player_prefab.name);
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        if (no_lives > 0 && player_instance == null)
        {
            respawn_timer -= Time.deltaTime;
            if (respawn_timer <= 0)
            {
                Spawn();
            }
        }

    }

    void Spawn()
    {
        no_lives--;
        respawn_timer = 1f;
        GameObject spawned_object = nextSpawn();
        // player_prefab.AddComponent<CapsuleCollider2D>();
        // = spawned_object;
        SpriteRenderer player_renderer = player_prefab.GetComponent<SpriteRenderer>();
        SpriteRenderer spawn_renderer = spawned_object.GetComponent<SpriteRenderer>();
        player_renderer.sprite = spawn_renderer.sprite;
        
        CapsuleCollider2D player_collider = player_prefab.GetComponent<CapsuleCollider2D>();
        CapsuleCollider2D spawn_collider = spawned_object.GetComponent<CapsuleCollider2D>();
        // Debug.Log(spawn_collider.size);
        player_collider.size = spawn_collider.size;
        // player_collider.transform = spawn_collider.transform;
        // player_collider = spawn_collider;
        Debug.Log(spawned_object.transform.rotation.eulerAngles);
        // Transform player_transform = player_prefab.GetComponent<Transform>();
        // player_transform = spawned_object.GetComponent<Transform>();
        
        player_instance = (GameObject)Instantiate(player_prefab, spawned_object.transform.position,spawned_object.transform.rotation);
        
        Debug.Log(player_prefab.transform.rotation.eulerAngles);
        
        player_instance.name = player_prefab.name;
    }


    void OnGUI()
    {
        if (no_lives > 0 || player_instance != null) GUI.Label(new Rect(0, 0, 100, 50), "Lives left: " + no_lives);
        else GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 25, 100, 50), "Game over bru");
    }


    GameObject nextSpawn()
    {
        foreach (GameObject obj in Spawns)
        {
            if (obj != null)
            {
                GameObject.Destroy(obj);
                // obj = null;
                return obj;
            }
        }
        return null;
    }
}
