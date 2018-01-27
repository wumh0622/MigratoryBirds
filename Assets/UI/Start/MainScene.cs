using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScene : MonoBehaviour {


	void Start()
	{
        Screen.SetResolution(360, 640, true);
    }
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
