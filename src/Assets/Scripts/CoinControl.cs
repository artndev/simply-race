using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinControl : MonoBehaviour 
{
	// CoinControl.cs || @artndev 


	public bool rotate; 
	public float rotationSpeed;


	void Update () 
	{
		if (rotate)
			transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
	}


	void OnTriggerEnter(Collider col)
	{
		Destroy(gameObject);
	}
		
}
