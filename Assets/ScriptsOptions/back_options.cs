using UnityEngine;
using System.Collections;

public class back_options : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void TransToMainMenu(){
		Sliders sliders = Sliders.openObjSliders ();


		Sliders.DestroySingl ();//разыменовать экземпляр
	}
}
