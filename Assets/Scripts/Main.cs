using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour {

	// Use this for initialization
	void Start () {
        LevelGenerate.instence.GenerateBackGround();
        LevelGenerate.instence.InvokeRepeating("GenerateIsland", .5f, .5f);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
