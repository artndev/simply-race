using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
	// MenuManager.cs || @artndev 


	public void Start()
	{
		Time.timeScale = 0;
	}


	// смена сцены
	public void ChangeScene(int numberScene)
	{
		SceneManager.LoadScene(numberScene);
		Time.timeScale = 1;
	}


	// выход из приложения
	public void Exit()
	{
		Application.Quit();
	}
}
