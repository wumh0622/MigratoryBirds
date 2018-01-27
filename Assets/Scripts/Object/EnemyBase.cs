using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour {

    public static float speed;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	public virtual void Update () {
		Camera mainCamera = Camera.main;
		transform.Translate(0, speed*-1, 0);
		if(transform.position.y < -2f * mainCamera.orthographicSize)
		{
            Destroy(gameObject);
        }
	}
}
