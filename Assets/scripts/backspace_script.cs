using UnityEngine;
using System.Collections;

public class backspace_script : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnMouseDown(){

		GameObject go = GameObject.Find ("solut_okno");
		TextMesh txtOnSolutOkno = (TextMesh)go.GetComponentInChildren<TextMesh> () as TextMesh;

		int inndex_ravno=txtOnSolutOkno.text.IndexOf("=");
		//Debug.Log (txtOnSolutOkno.text+"");
		int strLenSolutOnkno = txtOnSolutOkno.text.Length;
		txtOnSolutOkno.text=txtOnSolutOkno.text.Remove (inndex_ravno+1);
		tables.enter_answer = "";
	}
}
