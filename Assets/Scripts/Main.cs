using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Screen.SetResolution(360, 640, true);
        //LevelGenerate.instence.GenerateBackGround();
        LevelGenerate.instence.InvokeRepeating("GenerateIsland", 1f, 1f);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
