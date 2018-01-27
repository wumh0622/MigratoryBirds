using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUi : MonoBehaviour {
	public Image HpBarFull;

	public Button Pause;
	public Button Resume;

	public Button MainButton;
	public CanvasGroup GameOverCanvasGroup;

	public string MainSceneNmae;

	private void Awake()
	{
		Pause.gameObject.SetActive(false);
		Resume.gameObject.SetActive(false);
		GameOverCanvasGroup.alpha = 0;
	}

	private void Update()
	{
		float rate = GameManager.Instance.sp / 100;
		HpBarFull.fillAmount = Mathf.Lerp(0, 1, rate);
	}

	public void GoToMainScene()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene("Start");
	}
}
