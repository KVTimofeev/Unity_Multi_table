using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class SliderChange : MonoBehaviour {
	Slider slide;
	float len=100f;
	// Use this for initialization
	void Start () {
		slide = GetComponent<Slider> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnSlider2Changed(float val){
		//slide.value = val;
		var value = val;
		float delta = len - value;
		slide.value = delta;
	}
	public void OnSliderChanged(float val){
		Debug.Log (val);
	}
}
