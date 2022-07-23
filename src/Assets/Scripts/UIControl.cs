using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.UI;

public class UIControl : MonoBehaviour
{
	// UIControl.cs || @artndev 


	[Header("Statistic text")]
	public Text currentTimeText;
	public Text earnedCoinsText;

	[Header("End game text")]
	public Text endEarnedCoinsText;
	public Text endTotalTimeText;

	[Header("Countdown text")]
	public Text Countdown;

	[Header("Canvas GameObjects")]
	public GameObject Stats;
	public GameObject endMenu;

	[Header("Countdown left")]
	public float countdownLeft = 11f;

	float earnedCoins = 0;
	float currentTime;


	void Start()
	{
		StartCoroutine(StartCountdown());
		StartCoroutine(StartTimer());
	}


	public IEnumerator StartCountdown()
	{
		Stats.SetActive(false);
		while (countdownLeft > 0)
		{
			countdownLeft--;
			Countdown.text = countdownLeft.ToString();
			yield return new WaitForSeconds(1.0f);
		}
		Stats.SetActive(true);
		Countdown.text = " ";
	}


	public IEnumerator StartTimer()
	{
		for(;;) // аналог while(true), только быстрее
		{
			if(countdownLeft == 0)
			{
				currentTime += 1f;
				currentTimeText.text = currentTime.ToString();
			}
			yield return new WaitForSeconds(1.0f);
		}
	}
		

	void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.tag == "Coin")
		{
			earnedCoins += 1f;
			earnedCoinsText.text = earnedCoins.ToString();
		}

		else if(col.gameObject.tag == "End")
		{
			Stats.SetActive(false);
			endMenu.SetActive(true);

			endEarnedCoinsText.text = earnedCoins.ToString();
			endTotalTimeText.text = currentTime.ToString();

			Time.timeScale = 0;
		}
	}
}
