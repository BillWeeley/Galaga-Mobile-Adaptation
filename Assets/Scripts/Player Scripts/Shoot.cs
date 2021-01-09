using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

	public GameObject projectile; 

	public Transform projectileSpawn; 

	public float nextFire = 1.0f; 
	public float currentTime = 0.0f; 

	[SerializeField] private JoystickButton joystickButton; 

	
	void Start()
	{
		projectileSpawn = this.gameObject.transform; 
	}

	
	void Update()
	{

		shoot(); 
	}

	
	public void shoot()
	{
		currentTime += Time.deltaTime; 
		if (Input.GetKey(KeyCode.Space) || joystickButton.isPressing && currentTime > nextFire) 
		{
			nextFire += currentTime; 

			Instantiate(projectile, projectileSpawn.position, Quaternion.identity); 

			nextFire -= currentTime; 
			currentTime = 0.0f; 
		}
	}
}