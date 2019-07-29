using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class value : MonoBehaviour {
	public GameObject text;
	Text txt;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {	
	}
	public void OnSliderChanged(float val,int index){
		txt=text.GetComponent<Text>() as Text;
		var a = Mathf.Round(val);
		txt.text = ""+a;
	}
	public void transToMenu(){
		Application.LoadLevel (0);
	}
}
