using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManger : MonoBehaviour {

    [SerializeField] AudioClip[] clips;
    AudioSource AS;
    bool isChild;

    // Use this for initialization
    void Start () {
		if(GetComponent<AudioSource>() != null)
        	AS = GetComponent<AudioSource>();
        else
        {
            AS = GetComponentInChildren<AudioSource>();
            isChild = true;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

	public void play(int clipIndex)
	{
		if(!isChild)
        	AS.PlayOneShot(clips[clipIndex]);
        else
        {
            AS.transform.parent = null;
            AS.PlayOneShot(clips[clipIndex]);
        }
    }
}
