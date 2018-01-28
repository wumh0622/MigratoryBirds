using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    //public int numberOfBirds = 100;
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
		if(BirdsManger.instence.GetBirdAmount() <= 0)
        {
            LevelUi.Instance.ShowGameOver();
        }
	}

    public void killBirds(int birds)
    {
        if (BirdsManger.instence.GetBirdAmount() < birds)
            birds = BirdsManger.instence.GetBirdAmount();

        //numberOfBirds -= birds;
        for (int i = 0; i < birds; i++)
            {
                BirdsManger.instence.KillBird();
            }

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

    public void Cure(int cureAmount)
    {
        sp += cureAmount;
        if(sp > 100)
        {
            sp = 100;
        }
    }
}
