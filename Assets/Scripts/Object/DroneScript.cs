using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        InvokeRepeating("turn", 1, 1);
    }

    // Update is called once per frame

    bool toLeft;
    void Update () {
        if (!toLeft)
        {
            FlyRight();
        }
		else
		{
            FlyLeft();
        }
    }

	void FlyRight()
	{
		Vector3 newPosition = Vector3.Lerp(transform.position, transform.position + new Vector3(0.1f,0,0), 0.3f);
        transform.position = newPosition;
	}

	void FlyLeft()
	{
		Vector3 newPosition = Vector3.Lerp(transform.position, transform.position - new Vector3(0.1f,0,0), 0.3f);
        transform.position = newPosition;
	}

	void turn()
	{
		if(toLeft)
            toLeft = false;
        else
            toLeft = true;
    }
}
