using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour {

	public Text txtLives;
	public static int lives;

	private bool terminating = false;
	
	void Update () {
		txtLives.text = "Vidas: " + lives.ToString ();

		if (lives <= 0 && !terminating) {
			terminating = true;
			StartCoroutine (WaitForTerminating ());
		}
	}

	IEnumerator WaitForTerminating() {
		print ("Terminating...");

		yield return new WaitForSeconds (3);
		print ("Terminated!");
		SceneManager.LoadScene ("Menu");
	}
}
