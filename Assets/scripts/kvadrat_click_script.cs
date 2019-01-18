using UnityEngine;
using System.Collections;

public class kvadrat_click_script : MonoBehaviour {
	public GameObject okno_calc;

	// Use this for initialization
	void Start () {
		//okno_calc = GameObject.Find ("okno_calc");
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnMouseDown(){

		if (!string.IsNullOrEmpty(tables.str_id)) {
			GameObject lastSquare = GameObject.Find (tables.str_id);
			SpriteRenderer sprite=(SpriteRenderer)lastSquare.GetComponent<SpriteRenderer> () as SpriteRenderer;
			sprite.sortingOrder = 1;
			//Debug.Log("sortLay");

		}
		tables.str_id = gameObject.name;
		gameObject.GetComponent<SpriteRenderer>().sortingOrder=0;
		GameObject okno_calc_inst;
		if(GameObject.Find("okno_calc (1)(Clone)")==null){
			okno_calc_inst=Instantiate (okno_calc);
		}else{
			okno_calc_inst=GameObject.Find("okno_calc (1)(Clone)");
		}
		TextMesh txtOnSolutOkno = (TextMesh)okno_calc_inst.GetComponentInChildren<TextMesh> () as TextMesh;
		TextMesh txtOnKvadradic = (TextMesh)gameObject.GetComponentInChildren<TextMesh> () as TextMesh;
		txtOnSolutOkno.text = txtOnKvadradic.text+"=";
		string name=tables.str_id;
		string s_answer = name.Substring (name.IndexOf("=")+1);
		tables.answer = int.Parse(s_answer);
	}
}
