using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class MessageUiManager : MonoBehaviour {
	static MessageUiManager _Instance;
	public static MessageUiManager Instance
	{
		get {
			if (_Instance == null) 
			{
				MessageUiManager manager = Resources.Load<MessageUiManager> ("MessageUiManager");
				Instantiate (manager.gameObject);
				manager.gameObject.transform.position = Vector3.zero;
				manager.gameObject.transform.localScale = Vector3.one;
				_Instance = manager;
			}
			return _Instance;
		}
	}

	public GameObject MessageUiElementSample;
	Queue<MessageData> messages = new Queue <MessageData>();
	public List<MessageData> messageDataList = new List<MessageData>();
	Dictionary<string, MessageData> messageDataDictionary = new Dictionary<string, MessageData>();
	public bool IsOnShow = false;

	void Awake () {
		if (_Instance == null) {
			_Instance = this;
		}
		MessageUiElementSample = transform.Find ("MessageUISample").gameObject;
		messageDataDictionary.Clear();
		for (int i = 0; i < messageDataList.Count; i++)
		{
			messageDataDictionary.Add(messageDataList[i].ID, messageDataList[i]);
		}
	}
	
	// Update is called once per frame
	void Update () {
		//if (Input.GetKeyDown (KeyCode.F12)) {
		//	MessageData testdata = new MessageData();
		//	testdata.info = "test info";
		//	testdata.title = "test title";
		//	AddMessage (testdata);
		//}
		//if (Input.GetKeyDown(KeyCode.F1))
		//{
		//	MessageData testdata = new MessageData();
		//	AddMessage("1");
		//}
		//if (Input.GetKeyDown(KeyCode.F2))
		//{
		//	MessageData testdata = new MessageData();
		//	AddMessage("2");
		//}

		if (messages.Count > 0 && !IsOnShow) {
			IsOnShow = true;
			MessageData data = messages.Dequeue ();
			data.End += (() => {
				IsOnShow = false;	
			});
			GameObject go = Instantiate (MessageUiElementSample) as GameObject;
			MessageUiController tmpMessageUiController = go.GetComponent<MessageUiController> ();
			tmpMessageUiController.messageData = data;
			go.transform.SetParent (transform);
			((RectTransform)go.transform).anchoredPosition3D = ((RectTransform)MessageUiElementSample.transform).anchoredPosition3D;
			go.transform.localScale = Vector2.one;
			tmpMessageUiController.Show ();
		}
	}

	public void AddMessage(MessageData data){
		messages.Enqueue (data);
	}

	public void AddMessage(string ID)
	{
		if (messageDataDictionary.ContainsKey(ID))
		{
			AddMessage(messageDataDictionary[ID]);
		}
	}

	[System.Serializable]
	public class MessageData
	{
		public string ID;
		public string type;
		public string title;
		public string info;
		public Sprite Icon;
		public float FadeTime = 0.5f;
		public System.Action End;
		public float ShowMessageTime = 3;
	}
}

