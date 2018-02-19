using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour {

	public Button startButton;
	private Button btn;

	void Start () {
		btn = startButton.GetComponent<Button> ();
		btn.onClick.AddListener (StartGame);
	}

	private void StartGame() {
		SceneManager.LoadScene ("Game");
	}
}
