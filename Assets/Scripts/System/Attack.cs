using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{

    public Transform attackPoint;
    public bool attacking;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (attacking)
        {
            Vector3 diff = attackPoint.position - transform.position;
            diff.Normalize();

            float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f, 0f, rot_z - 90), .1f);
            transform.Translate(transform.up * 0.09f);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (attacking && other.transform == attackPoint)
        {
            GameManager.Instance.killBirds(1);
            GameManager.Instance.hurtSP(other.GetComponent<Enemy>().passiveAttackSP);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
