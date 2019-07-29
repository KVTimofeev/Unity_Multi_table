using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class ChangeSliders : MonoBehaviour {
	public GameObject[] go_txts;//массив label_num
	List<Text> listTxts;//лист для хранения текстовых люъектов внутри label_num
	List<Slider> listSliders;//лист для хранения объектов slider которые является дочерними объектами текста
	Sliders sliders;
	public int current_mean_changing_slider;
	public int last_mean_of_changed_slider;
	public bool yet_changed=false;
	int counter_change=0;
	// Use this for initialization
	void Start () {
		listTxts = new List<Text>();
		listSliders=new List<Slider>();
		foreach(GameObject go in go_txts){
			Text t=go.GetComponent<Text> ();
			Slider slider=go.GetComponentInChildren<Slider>();
			listTxts.Add(t);
			listSliders.Add(slider);
		}
		//в таблице tables имеются данные о количестве слайдеров
		//при помощи синглетона берем объект Sliders отвечающий за то какое числот в каждом слайдере
		//и как они будут менятся при изменении одного из них.
		sliders = Sliders.openObjSliders ();

	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void SliderChanged1(float value){
		var a = Mathf.Round(value);
		current_mean_changing_slider = 0;
		listTxts [current_mean_changing_slider].text = "" + a;
		int mean = int.Parse (a+"");
		RaspredMeans (current_mean_changing_slider, mean);
	}
	public void SliderChanged2(float value){
		
		var a = Mathf.Round(value);
		listTxts [1].text = "" + a;
		int mean = int.Parse (a+"");
		RaspredMeans (1, mean);
	}
	public void SliderChanged3(float value){
		
		var a = Mathf.Round(value);
		listTxts [2].text = "" + a;
		int mean = int.Parse (a+"");
		RaspredMeans (2, mean);
	}
	public void SliderChanged4(float value){
		
		var a = Mathf.Round(value);
		listTxts [3].text = "" + a;
		int mean = int.Parse (a+"");
		RaspredMeans (3, mean);;
	}
	void RaspredMeans(int index,int mean){
		last_mean_of_changed_slider=sliders.changeMean (index,mean,last_mean_of_changed_slider,yet_changed);
		//last_mean_of_changed_slider-индекс последнего изменившегося элемента (не путать с текущим)
		if (last_mean_of_changed_slider == -1) {
			yet_changed = false;
			last_mean_of_changed_slider=0;
		} else {
			yet_changed = true;
		}
		int i = index;
		i++;
		int count = sliders.means.Length - 1;
		while (count>0) {
				if(i>=sliders.means.Length){
					i=0;
				}
				if(i==index){
					i++;
				}
				listTxts [i].text=""+sliders.means[i];
				listSliders[i].value=sliders.means[i];
				i++;
				count--;
			}//конец while
		}//конец RaspredMeans

	public void TransToMainMenu(){
		//передаем данные в таблицу о количестве примеров на 0-умножение
			//1 delenie, 2 summma,3 vichit
		if (sliders.test3 ()) {
			tables.count_examples_for_multiply = sliders.GetMeanOfSlider (0);
			tables.count_examples_for_division = sliders.GetMeanOfSlider (1);
			tables.count_examples_for_summ = sliders.GetMeanOfSlider (2);
			tables.count_examples_for_subvision = sliders.GetMeanOfSlider (3);
			Application.LoadLevel (0);
		} else {
			Debug.Log ("не совпадает");
		}
	}


	}
