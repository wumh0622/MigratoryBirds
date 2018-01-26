using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerate : MonoBehaviour {

	public static LevelGenerate instence;

	void Awake()
	{
		if(instence == null)
		{
            instence = this;
        }
		else
		{
            Destroy(gameObject);
        }
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//背景圖片生成
    [SerializeField] GameObject backGround;
    [SerializeField] float scrollingSpeed;

    public void GenerateBackGround()
	{
        BackGroundScrollDown.speed = scrollingSpeed;
        for (int i = 1; i <= 2; i++)
        {
            Camera mainCamera = Camera.main;
            GameObject clone = Instantiate(backGround);
            clone.transform.position = new Vector3(0, 2f * i * mainCamera.orthographicSize, 0);
            clone.transform.localScale = new Vector3(2f * mainCamera.orthographicSize * mainCamera.aspect, 2f * mainCamera.orthographicSize, 0);
        }
    }

    //島嶼生成

    [SerializeField] GameObject[] Island;

    public void GenerateIsland()
	{
		
	} 
}
