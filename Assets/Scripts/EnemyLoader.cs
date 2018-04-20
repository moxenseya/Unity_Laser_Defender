using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLoader : MonoBehaviour {
public float width=5f;
public float height=2f;
public GameObject enemy;
bool movingright=false;
public float speed = 2f;
Vector3 rightEdge;
Vector3 leftEdge;
private float xmax;
private float xmin;
float leftedgeofformation;
float rightedgeofformation;


			// Use this for initialization
	void Start () {
	float distance = transform.position.z - Camera.main.transform.position.z;
	rightEdge=Camera.main.ViewportToWorldPoint(new Vector3(1,0,distance));
	leftEdge=Camera.main.ViewportToWorldPoint(new Vector3(0,0,distance));
	xmax=rightEdge.x;
	xmin=leftEdge.x;
	spawnuntilfull();
	}

	void OnDrawGizmos ()
	{

	Gizmos.DrawWireCube(transform.position,new Vector3(width,height));
	}

	
	// Update is called once per frame
	void Update ()
	{
		leftedgeofformation = transform.position.x - (0.5f * width);
		rightedgeofformation = transform.position.x + (0.5f * width);

		if (leftedgeofformation < xmin || rightedgeofformation > xmax) {
			movingright = !movingright;
		}
		if (movingright) {
			transform.position += Vector3.right * speed * Time.deltaTime;
		} else {
			
			transform.position += Vector3.left * speed * Time.deltaTime;
		}

		if (allenemiesdead()) {
spawnuntilfull();				}
		}

		bool allenemiesdead ()
	{
		foreach (Transform childpositionGameObject in transform) {
		if(childpositionGameObject.childCount>0)
		return false;
		}
		return true;
	}

	Transform NextFreePosition ()
	{
		foreach (Transform childposition in transform) {
		if(childposition.GetChildCount()<=0)
		return childposition;
		}
			return null;
	}

	void respawn ()
	{
		foreach (Transform child in transform) {
			GameObject enemyinstance=Instantiate(enemy, child.position,Quaternion.identity) as GameObject;
	enemyinstance.transform.parent=child;		}
	}

	void spawnuntilfull ()
	{
		Transform freepos = NextFreePosition ();
		if (freepos) {
			GameObject enemyinstance = Instantiate (enemy, freepos.position, Quaternion.identity) as GameObject;
			enemyinstance.transform.parent = freepos;		
		}
		if (NextFreePosition ()) {
		Invoke("spawnuntilfull",.5f);
		}
	}
	}

