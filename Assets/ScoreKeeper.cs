using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreKeeper : MonoBehaviour {

public int score=0;
private Text scoretext;

void Start()
{
scoretext=GetComponent<Text>();
Reset();
}

public void Score (int points)
	{
	score+= points;
	scoretext.text=score.ToString();
	}

	void Reset ()
	{
	score=0;
	scoretext.text=score.ToString();
	}


}
