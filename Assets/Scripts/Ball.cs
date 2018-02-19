using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	private Rigidbody2D rb;

	public Transform player;
	public int lives;
	public float speed;
	public float ballInitialHeightOffset;

	private bool gameStarted = false;

	// Início
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		transform.position = new Vector2 (player.position.x, player.position.y + ballInitialHeightOffset);

		Score.lives = lives;
	}

	// Atualização constante
	void Update () {
		if (!gameStarted) {

			if (Input.GetButtonDown("Jump")) {
				
				rb.velocity = new Vector2 (Random.Range (-2f, 2f), speed * Time.deltaTime);
				gameStarted = true;

			} else {

				transform.position = new Vector2 (player.position.x, transform.position.y);
			}

		} else {

			if (rb.velocity.y < 2 && rb.velocity.y > -2) {
				rb.gravityScale = 2;
			} else {
				rb.gravityScale = 0;
			}

		}
	}

	// Colisão
	void OnCollisionEnter2D(Collision2D c) {

		switch (c.gameObject.tag) {
		case "Brick":

			Destroy (c.gameObject);

			break;

		case "Player":

			float ballHorizontalOffset = ballCollisionOffset (transform.position, c.transform.position);
			Vector2 ballNewDirection = new Vector2 (ballHorizontalOffset, 1);

			rb.velocity = ballNewDirection * speed * Time.deltaTime;

			break;

		case "BottomBound":

			lives--;
			Score.lives--;

			if (lives > 0) {

				transform.position = new Vector2 (player.position.x, player.position.y + ballInitialHeightOffset);
				gameStarted = false;

				rb.velocity = Vector2.zero;

			} else {

				Destroy (gameObject);

			}

			break;

		default: 
			break;
		}
	}

	private float ballCollisionOffset(Vector2 ballPosition, Vector2 playerPosition) {
		return (ballPosition.x - playerPosition.x);
	}
}
