using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUi : MonoBehaviour {
	public static LevelUi Instance = null;
	public Image HpBarFull;
    public Image BreakTimeImage;

    public Button Pause;
	public Button Resume;

	public Button MainButton;
	public CanvasGroup GameOverCanvasGroup;

	public string MainSceneNmae;
    bool isBreakTime = false;


    private void Awake()
	{
		Instance = this;
		Pause.gameObject.SetActive(false);
		Resume.gameObject.SetActive(false);
		GameOverCanvasGroup.alpha = 0;
	}

	private void Update()
	{
		
		float rate = GameManager.Instance.sp / 100.0f;
        //Debug.Log(rate + "    " + GameManager.Instance.sp);
        HpBarFull.fillAmount = Mathf.Lerp(0, 1, rate);
		/* if(isBreakTime)
		{
			if(Input.GetMouseButtonDown(0))
			{
                HideBreakImage();
                
                isBreakTime = false;
            }
		} */
	}

	public void GoToMainScene()
	{
        Time.timeScale = 1;
        UnityEngine.SceneManagement.SceneManager.LoadScene("Start");
	}

	public void ShowGameOver()
	{
        GameOverCanvasGroup.gameObject.SetActive(true);
        GameOverCanvasGroup.alpha = 1;
	}

	public void ShowBreakImage()
	{
        BreakTimeImage.gameObject.SetActive(true);
        isBreakTime = true;
        //Invoke("HideBreakImage", 1);

    }

	public void HideBreakImage()
	{
        Debug.Log("PPPP");
        LevelGenerate.instence.ContinueScroll();
		BreakTimeImage.gameObject.SetActive(false);
		foreach (var item in GameObject.FindGameObjectsWithTag("typhoon"))
		{
            Destroy(item);
        }

        GameManager.Instance.sp = 100;

    }
}
