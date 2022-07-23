using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundControl : MonoBehaviour
{
	// SoundControl.cs || @artndev 


	[Header("AudioClips")]
	public AudioClip coinSound;
	public AudioClip barrierSound;
	public AudioClip tiresSound;

	[Header("AudioSource for AudioClips")]
	// AudioSource для воспроизведения AudioClips
	public AudioSource audioSrc;
    

	void OnCollisionEnter(Collision col)
	{
		if(col.gameObject.tag == "Barrier")
		{
			audioSrc.PlayOneShot(barrierSound);
		}

		else if(col.gameObject.tag == "Tires")
		{
			audioSrc.PlayOneShot(tiresSound);
		}
	}


	void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.tag == "Coin")
		{
			audioSrc.PlayOneShot(coinSound);
		}
	}
		
}
