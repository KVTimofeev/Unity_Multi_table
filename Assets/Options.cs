using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Options {
	public static Options pOptions=null;
	public GameObject Texts;
	//всего слайдеров
	public int count_sliders=5;
	//переменная которая хранит максимальное значение для любого слайдера
	public int MaxValue=100;
	//переменная которая хранит максимальное значение для всех слайдеров
	public int MaxValues;
	//массив прошлых позиций каждого слайда
	public float[] lasts_positions;//0 до 3 => sl1 sl2 sl3 sl4;

	//индекс счетчика
	static int current_count;
	//счетчик
	public int Counter{
		set{
			if(value==count_sliders){
				current_count=1;
			}
		}
		get{
			return current_count;
		}
	}
	private List<Slider> list_Sliders;


	Options(){
		Counter = 1;
		lasts_positions=new float[]{50,50,50,50};
		MaxValues = MaxValue * count_sliders;
		list_Sliders=new List<Slider>();

	}


	public static Options OpenOptions(){
		if (pOptions == null) {
			pOptions = new Options ();
			return pOptions;
		} else {
			return pOptions;
		}
	}

	public int IncrementCounter(){
		Counter += 1;
		return Counter;
	}

	public void Move(float val, Slider slide){
		//Debug.Log (list_Sliders.Count);

		//Counter++;
		/*название слайда в окне иерархии именуется как slide1 или slide2.
		 * то есть последний символ это число. поэтому мы и возьмем это последнее число
		 * чтобы было легче обращаться к слайдам.
		 * 
		 */

		int index_last_simb = slide.name.Length - 1;
		string lSimb=""+slide.name[index_last_simb];
		int number_of_slide = int.Parse (lSimb);

		//Debug.Log ("number_of_slide"+number_of_slide);
		//не стоит забывать что массив измениний каждого слайда идет с нуля, а названия самих слайдов с еденицы
		//lasts_positions - речь идет об этом массиве, т.е. в на нулевом индексе хранится value 1-го слайда т.е. slide1



		pOptions = Options.OpenOptions ();
		float fMaxValues = (float)MaxValues;
		float new_value = (fMaxValues - val)/3;
		Debug.Log ("Counter="+pOptions.Counter);
		GameObject.Find ("Slider" + pOptions.Counter).GetComponent<Slider> ().value = 1f;

		










			//что сделать если number_of_slide - 1 слайдер перемещен налево
			
			/*for(int i=0;i<count_sliders;i++){
				if(i!=number_of_slide-1){
					int num=i+1;
					GameObject.Find("Slider"+num).GetComponent<Slider>().value++;
				}
			}*/

			//lasts_positions[number_of_slide - 1]=val;


		}




	public int GetNewCoordForSlide(){
		return 0;
	}


}
