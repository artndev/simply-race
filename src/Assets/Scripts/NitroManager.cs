using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NitroManager : MonoBehaviour
{
	// NitroManager.cs || @artndev 


	public float nitroPower;
	public GameObject nitroEffects;

	Rigidbody carRigidbody;


	void Start()
	{
		carRigidbody = GetComponent<Rigidbody>();
	}


    void FixedUpdate()
    {
		ManageNitro();
    }


	void ManageNitro()
	{
		if(Input.GetKey(KeyCode.LeftShift) && Input.GetAxis("Vertical") > 0.01f)
		{
			carRigidbody.AddForce(transform.forward * nitroPower); // добавляем силу
			nitroEffects.SetActive(true);
		}
		else
		{
			if(nitroEffects.activeSelf)
			{
				nitroEffects.SetActive(false);
			}
		}
	}
		

}
