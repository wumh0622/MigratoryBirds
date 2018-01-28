using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    float timer = 0;
    // Update is called once per frame
    void Update () {
        timer += Time.deltaTime;
        if(BirdsManger.instence.GetBirdAmount() <= 0)
        {
            Time.timeScale = 0;
            LevelUi.Instance.ShowGameOver();
        }
        if(timer > 0.1f)
        {
            hurtSP(1);
            timer = 0;
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
        if(sp <= 0)
        {
            killBirds(9999);
        }
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

    public void IsWin()
    {
        if(sp > 0 && BirdsManger.instence.GetBirdAmount() <= 5)
        {
            SceneManager.LoadScene("Finish");
        }
    }
}
