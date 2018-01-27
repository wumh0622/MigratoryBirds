using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageUiController : MonoBehaviour {
	public Image Icon;
	public Text Title;
	public Text InfoText;
	public Image Background;
	public CanvasGroup canvasGroup;
	public bool Active = false;
	public MessageUiManager.MessageData messageData = new MessageUiManager.MessageData();

	float toAlpah;
	float fromAlpha;
	float fadeOverTtime;
	float ShowTime = 0;

	void Awake(){
		Icon = transform.Find ("Icon").GetComponent<Image>();
		Title = transform.Find ("Title").GetComponent<Text>();
		InfoText = transform.Find ("Info").GetComponent<Text>();
		Background = GetComponent<Image> ();
		canvasGroup = GetComponent<CanvasGroup> ();

		canvasGroup.alpha = 0;
	}
	public void Show(){
		Debug.Log ("MessageUiController Show! " + gameObject.name);
		Active = true;
		canvasGroup.alpha = 0;
		toAlpah = 1;
		fromAlpha = 0;
		fadeOverTtime = 0;

		Title.text = messageData.title;
		InfoText.text = messageData.info;
		Icon.sprite = messageData.Icon;
	}
	public void Hide(){
		canvasGroup.alpha = 1;
		toAlpah = 0;
		fromAlpha = 1;
		fadeOverTtime = 0;
	}

	public void End(){
		Active = false;
		if (messageData.End != null) {
			messageData.End.Invoke();
		}
		Destroy (gameObject);
	}

	void Update(){
		if (!Active) {
			return;
		}
		if (canvasGroup.alpha != toAlpah) 
		{
			float rate = Mathf.Clamp (fadeOverTtime, 0, messageData.FadeTime) / messageData.FadeTime;
			canvasGroup.alpha = Mathf.Lerp (fromAlpha, toAlpah, rate);
			//Debug.Log ("rate("+rate+"), fromAlpha("+fromAlpha+"), toAlpah("+toAlpah+"), canvasGroup.alpha("+canvasGroup.alpha+")");
			fadeOverTtime += Time.deltaTime;
			if (canvasGroup.alpha == toAlpah) 
			{
				if (toAlpah == 1) 
				{
					ShowTime = 0;
				} 
				else 
				{
					End ();
				}
			}
		} 
		else 
		{
			if (ShowTime < messageData.ShowMessageTime) 
			{
				ShowTime += Time.deltaTime;
				if (ShowTime >= messageData.ShowMessageTime) {
					Hide ();
				}
			}
		}
	}
}
