using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Island : MonoBehaviour {

	public static float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame


	void Update()
	{
		Camera mainCamera = Camera.main;
		transform.Translate(0, speed*-1, 0);
		if(transform.position.y < -2f * mainCamera.orthographicSize)
		{
            Destroy(gameObject);
        }
	}

    bool isPress = false;
    void OnMouseDown()
    {
        if (!isPress)
        {
            if (gameObject.tag == "GoodIsland")
            {
                Debug.Log("Press");
                Time.timeScale = 0;
                LevelGenerate.instence.PauseScroll();
                LevelUi.Instance.ShowBreakImage();
                isPress = true;
            }
			else if(gameObject.tag == "BadIsland")
			{
                GameManager.Instance.hurtSP(50);
                GameManager.Instance.killBirds(10);
            }
        }

    }

}
