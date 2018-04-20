using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {


public float damagevalue;



Rigidbody2D rb;

public float speed =25f;

		// Use this for initialization
			void Start () {
			damagevalue=100f;
		//rb = GetComponent<Rigidbody2D>();
//rb.velocity=new Vector2(0f, speed);	

}
void OnTriggerEnter2D(Collider2D collision)
{
Destroy(gameObject);
}
}
