using System.Collections;
using System.Collections.Generic;
using UnityEditor.MemoryProfiler;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static float speed;

    public int hp;

    public bool activeAttack;
    public int activeAttackBirds;
    public int activeAttackSP;

    public int passiveAttackSP;
    public int cureSP;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
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
        
        if (activeAttack && other.tag == "DangerZone")
        {
            var gameManager = GameManager.Instance;

            gameManager.killBirds(activeAttackBirds);
            gameManager.hurtSP(activeAttackSP);
        }
    }

    bool isPress;
    void OnMouseDown()
    {
        if (!isPress)
        {
            isPress = true;
            Debug.Log("OnMouseDown");
            var gameManager = GameManager.Instance;
            if (gameObject.tag == "Enemy")
            {
                gameManager.attack(gameObject);
                BirdsManger.instence.DoAttack(gameObject);
            }
            else if (gameObject.tag == "Food")
            {
                gameManager.Cure(cureSP);
                Destroy(gameObject);
            }
        }

    }
}
