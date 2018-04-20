using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

public float speed=15.0f;
public GameObject bulletprefab;
float health = 200f;
float xmin;
float xmax;

public AudioClip firesound;

	// Use this for initialization
	void Start () {
	float distance= transform.position.z-Camera.main.transform.position.z;

	Vector3 left=	Camera.main.ViewportToWorldPoint(new Vector3(0,0,distance));
	Vector3 right= Camera.main.ViewportToWorldPoint(new Vector3(1,0,distance));

	xmin=left.x + 1f;
	xmax=right.x -1f;

	}
	
	// Update is called once per frame
	void Update ()
	{
		if (health <= 0f) {
			Destroy (gameObject);
			LevelManager man = new LevelManager();
			man.LoadLevel("Win Screen");
		}	
		float newX = Mathf.Clamp (transform.position.x, xmin, xmax);
		transform.position = new Vector3 (newX, transform.position.y, transform.position.z);

		if (Input.GetKey (KeyCode.LeftArrow)) {
			transform.position += Vector3.left * speed * Time.deltaTime;

		} else if (Input.GetKey (KeyCode.RightArrow)) {
			transform.position += Vector3.right * speed * Time.deltaTime;
		}

		if (Input.GetKeyDown (KeyCode.Space)) {

			InvokeRepeating ("FireBullets", 0.01f, .2f);

		}
		if (Input.GetKeyUp (KeyCode.Space)) {
		CancelInvoke();}

	}
	void FireBullets()
	{
			GameObject bullet=Instantiate(bulletprefab, new Vector3(transform.position.x, transform.position.y+1f, 0.0f), Quaternion.identity) as GameObject;
			Rigidbody2D bulletrb=bullet.GetComponent<Rigidbody2D>();

			bulletrb.velocity=new Vector2(0f, speed);
			AudioSource.PlayClipAtPoint(firesound,transform.position);
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		BulletScript bullet = other.gameObject.GetComponent<BulletScript> ();

		if (bullet) {
			print ("Hit by a bulllet!");
			health -= bullet.damagevalue;
		}
	}

}
