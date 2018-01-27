using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour {

	// Use this for initialization
	void Start () {
        LevelGenerate.instence.GenerateBackGround();
        LevelGenerate.instence.InvokeRepeating("GenerateIsland", 1, 1);
        LevelGenerate.instence.InvokeRepeating("GenerateEnemy", 2, 2);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
