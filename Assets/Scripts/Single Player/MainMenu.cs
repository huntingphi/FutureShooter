using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour {

	// Use this for initialization
	public void PlaySingle(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
	}

	public void Quit(){
		Application.Quit();
		Debug.Log("Game quitted");

	}
}
