using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdsManger : MonoBehaviour {

    List<Attack> birds;
    //Attack[] birds;
    public static BirdsManger instence;


    void Awake()
	{
        instence = this;
    }

    // Use this for initialization
    void Start () {
        birds = new List<Attack>();
        Attack[] attackArr = GetComponentsInChildren<Attack>();
        Debug.Log(attackArr.Length);
        foreach (var item in attackArr)
		{
			Debug.Log(item.name);
            birds.Add(item);
            
        }
        //birds = GetComponentsInChildren<Attack>();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

	public void DoAttack(GameObject target)
	{
        int randomIndex = Random.Range(0, birds.Count);
        birds[randomIndex].attackPoint = target.transform;
        birds[randomIndex].attacking = true;
        birds.RemoveAt(randomIndex);
    }

	public void KillBird()
	{
		int randomIndex = Random.Range(0, birds.Count);
        birds[randomIndex].Die();
		birds.RemoveAt(randomIndex);
    }

	public int GetBirdAmount()
	{
        return birds.Count;
    }
}
