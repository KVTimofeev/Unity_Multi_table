﻿using UnityEngine;
using System.Collections;

public class btn_test_script : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnMouseDown(){
		int enter_ans = int.Parse (tables.enter_answer);
		GameObject parent = gameObject.transform.parent.gameObject;
		if (enter_ans == tables.answer) {
			GameObject square=GameObject.Find(tables.str_id);
			GameObject okno_calc = GameObject.Find ("okno_calc");
			tables.enter_answer="";
			tables.answer=0;
			Destroy(square);
			Destroy (parent);
			tables.countSquares--;
			if(tables.countSquares<1){
				manageLev manager=GameObject.Find("ManagerLevel").GetComponent<manageLev>();
				manager.EndLevel();
			}
			Debug.Log ("верно");
		} else {
			Debug.Log("neverno");
		}

	}
}