using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class values : MonoBehaviour {

	Options opt;

	//public GameObject[] options;
	string[] list_elem_sliders = {
		"Slider1",
		"Slider2",
		"Slider3",
		"Slider4"
	};


	//Dictionary<string,GameObject>list_opts;
	// Use this for initialization
	void Start () {		   
		opt = Options.OpenOptions ();




	/*
	 *предположим что:
	 *0 элемент массива это "на умножение"
	 *1 на деление
	 *2 на сумму
	 *3 на разность
	 */
		//занесем в билтиотеку list_opts ассоциативный массив из строки, т.е. название объекта в иерархии и самого объекта
		/*list_opts = new Dictionary<string, GameObject> ();
		for (int i=0; i<options.Length; i++) {
			list_opts.Add(list_elem_options[i],options[i]);
		}

	*/
	}
	
	// Update is called once per frame
	void Update () {
	
	}




	public void OnSliderChanged(float val){

		Text txt = this.GetComponentInParent<Text> ();
		txt.text = ""+Mathf.Round(val);
		Slider slide = this.GetComponent<Slider>();

			opt=Options.OpenOptions();

			opt.Move (val, slide);
		opt.IncrementCounter ();

		//Debug.Log ("Slider"+s);

	}
}
