using System.Collections;
using System.Collections.Generic;
using UnityEditor.MemoryProfiler;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static float speed;

    public int hp;

	public string MessageId;

    public bool activeAttack;
    public int activeAttackBirds;
    public int activeAttackSP;

    public int passiveAttackSP;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    public virtual void Update()
    {
        Camera mainCamera = Camera.main;
        transform.Translate(0, speed * -1, 0);
        if (transform.position.y < -2f * mainCamera.orthographicSize)
        {
			Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (activeAttack)
        {
			if (!string.IsNullOrEmpty(MessageId))
			{
				MessageUiManager.Instance.AddMessage(MessageId);
			}

            var gameManager = GameManager.Instance;

            gameManager.killBirds(activeAttackBirds);
            gameManager.hurtSP(activeAttackSP);
        }
    }

    void OnMouseDown()
    {
        var gameManager = GameManager.Instance;
        gameManager.attack(gameObject);
    }
}
