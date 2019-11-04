﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class simbol_script : MonoBehaviour {
	GameObject enterText;
	public GameObject deleteBtn;
	GameObject picture_ans_wind;
	private manageLev manager;
	// Use this for initialization
	void Start () {

		picture_ans_wind = GameObject.Find ("picture_answered_wind");
			//GameObject ManagerLevel = GameObject.Find ("ManagerLevel");
			//manager=ManagerLevel.GetComponent<manageLev>();


	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnMouseDown(){
		enterText = GameObject.Find ("for_entered_text_answer");


		TextMesh txtSimbol = (TextMesh)gameObject.GetComponentInChildren<TextMesh> () as TextMesh;
		TextMesh txt_enterText = (TextMesh)enterText.GetComponent<TextMesh> () as TextMesh;
		manageLev manager=(manageLev)GameObject.Find(tables.Managerlevel).GetComponent<manageLev>() as manageLev;


		if (tables.stack_delets_simbols_current_lev == null) {
			tables.stack_delets_simbols_current_lev =new Stack<SimbolsAnsw>();
		}

		SimbolsAnsw simb_ans = new SimbolsAnsw ();
		simb_ans.pos_x = gameObject.transform.position.x;
		simb_ans.pos_y = gameObject.transform.position.y;
		simb_ans.pos_z = gameObject.transform.position.z;

		simb_ans.simb = txtSimbol.text;
		tables.stack_delets_simbols_current_lev.Push (simb_ans);
		Debug.Log (gameObject.name+"");

		Destroy (gameObject);
		txt_enterText.text += txtSimbol.text;

		if (GameObject.Find ("delete(Clone)") == null) {
			GameObject del=Instantiate(deleteBtn);
			//del.transform.position=new Vector3(deleteBtn.transform.position.x,deleteBtn.transform.position.y,
			  //                                 tables.zone_visible_z);
			del.transform.localPosition=new Vector2(3.3f,-1.33f);
			del.transform.localScale=new Vector2(1.6f,0.91f);
			del.transform.parent=picture_ans_wind.transform;
		}
		if (txt_enterText.text == tables.answer_current_fon) {
			Debug.Log ("ты угадал");
			GameObject[] squares = GameObject.FindGameObjectsWithTag ("square");
			if (squares.Length > 0) {
				Debug.Log ("squares найдены");
				for (int i=0; i<squares.Length; i++) {
					Destroy (squares [i]);
				}
				tables.stack_delets_simbols_current_lev.Clear ();
				manager.EndLevel ();
			}else {
				Debug.Log ("squares не найдены");
		} 
		}

	}
}
