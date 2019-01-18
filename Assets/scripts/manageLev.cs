using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;
public class manageLev : MonoBehaviour {
	public GameObject Next;



	public GameObject Picture_answer;
	// Use this for initialization
	void Start () {
		Sprite spr = new Sprite ();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void DoItInvisible(GameObject go){

		float x = go.transform.position.x;
		float y = go.transform.position.y;
		go.transform.position = new Vector3 (x,y,tables.zone_unvisible_z);
	}
	public void DoItVisible(GameObject go){
		float x = go.transform.position.x;
		float y = go.transform.position.y;
		go.transform.position = new Vector3 (x,y,tables.zone_visible_z);
	}

	public void EndLevel(){
		GameObject calc = GameObject.Find ("okno_calc");
		GameObject pict_answ = GameObject.Find ("picter_answered_wind");
		if (calc != null) {
			Destroy(calc);
		}
		if (pict_answ != null) {
			Destroy(pict_answ);
		}
		Instantiate (Next);
		Debug.Log ("endLevel");

	}
}
