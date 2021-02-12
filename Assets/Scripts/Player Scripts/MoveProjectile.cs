using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveProjectile : MonoBehaviour
{

	public Rigidbody2D projectile;//reference to a rigidbody2d

	public float moveSpeed = 10.0f;

	// Use this for initialization
	void Start()
	{
		projectile = this.gameObject.GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update()
	{
		projectile.velocity = new Vector2(0, 1) * moveSpeed;
	}

	//add some hit detecion
	void OnTriggerEnter2D(Collider2D col)
	{
		//when it hits an enemy...
		if (col.gameObject.name == "Enemy")
		{
			ScoreScript.scoreValue += 10;
			col.gameObject.SetActive(false);
		}
		//when it hits the top of the screen
		if (col.gameObject.name == "Top")
		{
			Destroy(gameObject);
		}
	}
}

