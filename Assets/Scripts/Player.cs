using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	private Rigidbody2D rb;

	public float speed;
	private float direction;

	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}

	void Update () {
		direction = Input.GetAxisRaw ("Horizontal");
		rb.velocity = new Vector2 (direction * speed * Time.deltaTime, 0);
	}
}
