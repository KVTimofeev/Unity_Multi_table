using UnityEngine;
using System.Collections;

public class delete_script : MonoBehaviour {

	public GameObject simbol;
	public string pict_ans_wind="picture_answered_wind";
	//"picter_answered_wind"
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnMouseDown(){
		Debug.Log ("delete btn push");
		GameObject ans_wind = GameObject.Find (tables.HierarchyNames.pict_ans_wind);

		TextMesh txtOnAnswer = (TextMesh)ans_wind.GetComponentInChildren<TextMesh> () as TextMesh;
		if (txtOnAnswer.text.Length > 0) {
			string str = txtOnAnswer.text;
			char lastSimb=str[str.Length-1];

			SimbolsAnsw simb=tables.stack_delets_simbols_current_lev.Pop();
			GameObject simb_inst = Instantiate(simbol);

			TextMesh textOnSimbol=(TextMesh)simb_inst.GetComponentInChildren<TextMesh>() as TextMesh;
			simb_inst.name=simb.simb;
			textOnSimbol.text=simb.simb;
			simb_inst.transform.parent=ans_wind.transform;
			simb_inst.transform.position=new Vector2(simb.pos_x,simb.pos_y);


			txtOnAnswer.text = txtOnAnswer.text.Remove (txtOnAnswer.text.Length - 1);
			if(txtOnAnswer.text.Length==0){
				Destroy(gameObject);
			}

		} else {
			Destroy(gameObject);
		}


	}
}
