using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int numberOfBirds = 100;
    public int sp = 100;

    void Awake()
    {
        Instance = this;
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void killBirds(int birds)
    {
        numberOfBirds -= birds;
        //birds die animation
    }

    public void hurtSP(int numberOfSP)
    {
        sp -= numberOfSP;
    }

    public void attack(GameObject enemy)
    {
        //call birds attack
    }
}
