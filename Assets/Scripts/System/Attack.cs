using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{

    [SerializeField] int attackBirdAmount;
    [SerializeField] Transform attackPoint;
    Camera camera;


    // Use this for initialization
    void Start()
    {
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
		if(Input.GetMouseButtonDown(0))
		{
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray,out hit,1000))
			{
				if(hit.collider.tag == "Enemy")
				{
                    print("hit");
                }
			}
        }
         Vector3 diff = attackPoint.position - transform.position;
         diff.Normalize();
 
         float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f, 0f, rot_z - 90), .1f);
        transform.Translate(transform.up*0.09f);
    }

	void OnCollisionEnter2D(Collision2D other)
	{
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
