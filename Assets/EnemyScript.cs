using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

public GameObject bulletprefab;
	float health = 200f;
	public float speed =25f;
	public float shotsPerSeconds=.5f;
	private ScoreKeeper scorekeeper;
	public int scorevalue = 100;
	public AudioClip firesoundenemy;

	void Start()
	{
	scorekeeper = GameObject.Find("Score").GetComponent<ScoreKeeper>();
	}

void Update ()
	{
		float probability = shotsPerSeconds * Time.deltaTime;
		if (Random.value < probability) {
			Fire ();
		}

		if (health <= 0) {
			Destroy (gameObject);
			scorekeeper.Score(scorevalue);
		}
	}
void OnTriggerEnter2D (Collider2D other)
	{
		BulletScript bullet = other.gameObject.GetComponent<BulletScript> ();

		if (bullet) {
			print ("Hit by a bulllet!");
			health -= bullet.damagevalue;
		}
	}
		void Fire()
		{
			GameObject bullet=Instantiate(bulletprefab, new Vector3(transform.position.x, transform.position.y-.9f, 0.0f), Quaternion.identity) as GameObject;
			Rigidbody2D bulletrb=bullet.GetComponent<Rigidbody2D>();

			bulletrb.velocity=new Vector2(0f, -speed);
			AudioSource.PlayClipAtPoint(firesoundenemy,transform.position);
		}


}
