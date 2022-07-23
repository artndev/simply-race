using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCollectibleScript : MonoBehaviour {

	public bool rotate; 
	public float rotationSpeed;
	public AudioSource collectSound;

	void Start () 
	{
		collectSound = GetComponent<AudioSource>();
	}
	

	void Update () 
	{

		if (rotate)
			transform.Rotate (Vector3.up * rotationSpeed * Time.deltaTime, Space.World);

	}

	void OnCollisionEnter(Collider col)
	{
		if (col.tag == "Car") 
		{
			Collect ();
		}
	}

	public void Collect()
	{
		collectSound.Play();
		Destroy(gameObject);
	}
}
