using UnityEngine;
using System.Collections;

public class btn_calc_script : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){

		GameObject solut_okno = GameObject.Find ("solut_okno");
		TextMesh txtSolut_okno = (TextMesh)solut_okno.GetComponentInChildren<TextMesh>() as TextMesh;
		TextMesh txtBtn = (TextMesh)gameObject.GetComponentInChildren<TextMesh>() as TextMesh;
		txtSolut_okno.text += txtBtn.text;
		//enter_answer также используется в test_btn
		tables.enter_answer += txtBtn.text;
	}
}
