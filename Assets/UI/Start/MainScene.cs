using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScene : MonoBehaviour {
	public string GameSceneName = "MainLevel";
	public void GameStart()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene(GameSceneName);
	}
	public void End()
	{
		Application.Quit();
	}
}
