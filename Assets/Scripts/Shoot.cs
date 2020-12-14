using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
	[SerializeField] float speed, fireRate;
	[SerializeField] private GameObject bullet, bulletParent;

	[SerializeField] private JoystickButton joystickButton;
	private float nextFiretime;
	
	void Start()
	{
		
	}

	
	void Update()
	{

		shoot(); 
	}

	
	public void shoot()
	{
	
		if (Input.GetKey(KeyCode.Space) ||  joystickButton.isPressing ) 
		{
			if (nextFiretime < Time.time)
			{
				Instantiate(bullet, bulletParent.transform.position, Quaternion.identity);
				nextFiretime = Time.time + fireRate;
			}
		}
	}
}