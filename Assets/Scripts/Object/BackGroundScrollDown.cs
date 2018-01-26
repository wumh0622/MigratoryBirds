using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundScrollDown : MonoBehaviour {

    public static float speed;

    // Use this for initialization
    void Start () {
		Camera mainCamera = Camera.main;
		transform.localScale = new Vector3(2f * mainCamera.orthographicSize * mainCamera.aspect, 2f * mainCamera.orthographicSize, 0);
	}
	
	// Update is called once per frame

    void Update()
	{
		Camera mainCamera = Camera.main;
		if(transform.position.y <= -2f * mainCamera.orthographicSize)
		{
            transform.position =  transform.position + new Vector3(0, 6f * mainCamera.orthographicSize, 0);
        }
        transform.Translate(0, speed*-1, 0);
    }
}
