using System.Collections;
using System.Collections.Generic;
//using UnityEditor.MemoryProfiler;
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
    public int cureSP;
    AudioManger audioManger;

    // Use this for initialization
    void Start()
    {
        if(GetComponent<AudioManger>()!= null)
            audioManger = GetComponent<AudioManger>();
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
        if(audioManger!=null && GetComponentInChildren<AudioSource>().isPlaying == false)
        {
            audioManger.play(Random.Range(3, 7));
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (activeAttack && other.tag == "DangerZone")
        {
			if (!string.IsNullOrEmpty(MessageId))
			{
				MessageUiManager.Instance.AddMessage(MessageId);
			}

            var gameManager = GameManager.Instance;

            gameManager.killBirds(activeAttackBirds);
            gameManager.hurtSP(activeAttackSP);
            if(audioManger!= null)
            {
                audioManger.play(Random.Range(0, 3));
            }
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
                if(audioManger!= null)
                {
                    audioManger.play(Random.Range(7,9));
                    GetComponentInChildren<AudioSource>().transform.parent = null;
                }
            }
            else if (gameObject.tag == "Food")
            {
                gameManager.Cure(cureSP);
                Destroy(gameObject);
            }
        }

    }
}
