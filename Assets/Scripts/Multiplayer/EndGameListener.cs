using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EndGameListener : MonoBehaviour {
	public GameObject canvas_player_1;

    public GameObject canvas_player_2;

    public GameObject alt_canvas;
	// Use this for initialization

	public GameObject player_1_spawner;
    public GameObject player_2_spawner;
    MultiplayerSpawner player1;
    MultiplayerSpawner player2;

    void Start () {
        canvas_player_1.SetActive(false);
        canvas_player_2.SetActive(false);
        alt_canvas.SetActive(false);
		player1 = player_1_spawner.GetComponent<MultiplayerSpawner>();
        player2 = player_2_spawner.GetComponent<MultiplayerSpawner>();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnGUI()
    {
        if (player1.no_lives <= 0&&player2.no_lives<=0)
        {
			alt_canvas.SetActive(true);
            endGame();

        }else if (player1.no_lives <= 0){
			canvas_player_1.SetActive(true);
            endGame();

        }else if (player2.no_lives <= 0){
			canvas_player_2.SetActive(true);
			endGame();
		}
        
		}

		void endGame(){
        GameObject other_player = GameObject.Find("Player2");
        Player2Controller controller_2;
        if (other_player != null)
        {
            controller_2 = other_player.GetComponent<Player2Controller>();
            controller_2.enabled = false;

        }

        other_player = GameObject.Find("Player1");
        if (other_player != null)
        {

            Player1Controller controller_1;
            controller_1 = other_player.GetComponent<Player1Controller>();
            controller_1.enabled = false;

        }
        StartCoroutine("GoToHomeScreen");

    }



IEnumerator GoToHomeScreen()
{
    yield return new WaitForSecondsRealtime(5);
        SceneManager.LoadScene(0);

    }
}
