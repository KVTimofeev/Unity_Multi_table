using UnityEngine;
using System.Collections;


public class Sliders {
	public int[] means;
	private int summ;
	private int count;
	private int defoultCount=4;
	private int defoultSumm=16;
	public int difference=0;//разница между существующим и прошлым значением mean
	private int count_touch = 0;
	private int total_summ_exp;//экспериментальная сумма всех элементов массива
	private int exp_summ_left_elements;//экспериментальная сумма оставшихся элементов
	private int summ_left_elements;//тоже самое что и наверху, то толдько уже требуемая.

	private static Sliders array_means_sliders=null;
	/*
	public static Sliders openObjSliders(int count,int summ){
		if (array_means_sliders == null) {
			array_means_sliders=new Sliders(count,summ);
			return array_means_sliders;
		}
	}*/
	public static Sliders openObjSliders(){
		if (array_means_sliders == null) {
			array_means_sliders = new Sliders (tables.count_sliders, tables.total_summ_examples);
			return array_means_sliders;
		} else {
			return array_means_sliders;
		}
	}
	public static void DestroySingl(){
		if (array_means_sliders != null) {
			array_means_sliders=null;
		}
	}

	//исчисление значения слайдеров идет с нуля
	public int GetMeanOfSlider(int ind){
		return this.means [ind];
	}
	public void SetMeanInSlider(int index,int mean){
		this.means [index] = mean;
	}
	//вернет true если значение было увеличено
	public bool IncrementMean (int index){
		int current_mean = GetMeanOfSlider (index);
		if (current_mean < this.summ) {
			current_mean++;
			SetMeanInSlider (index, current_mean);
			return true;
		} 
			return false;

	}
	//вернет true если было уменьшено
	public bool DecrementMean(int index){
		int current_mean = GetMeanOfSlider (index);
		if (current_mean>0) {
			current_mean--;
			SetMeanInSlider(index,current_mean);
			return true;
		}
		return false;
	}

	public int GetCountOfSlider(){
		return this.count;
	}

	private Sliders(int count,int summ){
		this.count=count;
		this.summ=summ;
		means=new int[count];
		int x=0;
		int medium=summ/count;
		while(x<count){
			means[x]=medium;
			x++;
		}
	}
	//сумма абсолютно весх элементов массива arr
	public int summ_all_elems(int[] arr){
		int i = 0;
		int summ = 0;
		while (i<arr.Length) {
			summ+=arr[i];
			i++;
		}
		return summ;
	}
	//вычисляет обычную сумму оставшиеся элементов
	private int exp_summ_left_elements_f(int currentIndex){
		return this.total_summ_exp-this.GetMeanOfSlider(currentIndex);
	}

	//вычисляет осавшуюся Требуемую сумму элементов после изменения текущего слайдера
	private int summ_left_elements_f(int currentIndex){
		return this.summ - this.GetMeanOfSlider(currentIndex);
	}
	//возвращает разницу между ними, если ноль то все хорошо если больше или меньше надо выравнивать.
	private int difference_between_exp_and_require_summ_elem(int currentIndex){
		this.exp_summ_left_elements = this.exp_summ_left_elements_f (currentIndex);
		this.summ_left_elements =this.summ_left_elements_f(currentIndex);
		return this.summ_left_elements - this.exp_summ_left_elements;
	}


	public bool test3(){
		this.total_summ_exp=this.summ_all_elems (means);
		return this.summ == this.total_summ_exp;
	}
	public int changeMean(int indexOfSlider,int Mean,int last_indexOfSlider,bool last_ind_not_empty){//возвращает индекс полседнего изменившегося элемента
		int lastMean=this.GetMeanOfSlider(indexOfSlider);
		SetMeanInSlider (indexOfSlider,Mean);
		//means[indexOfSlider]=Mean;
		difference=Mean-lastMean;
		//будем увеличивать или уменьшать значения
		bool decrease;		
		if(difference<0){
			//defference отрицательный значит текущий слайдер уменьшился, 
			//остальные слайдеры должны увеличиваться
			difference=-difference;
			decrease=true;
			}else{
			decrease=false;
			}		
		//int i=0;
		int exeptionIndex=indexOfSlider;//exeptionindex - индекц элемента который ставим в качестве исключения, то есть это ползунок которым в текущий моменнт пользуется пользователь
		int retind = last_indexOfSlider;//retind это индекс элемента который менял свое значения в прошлый раз
		//int count_zero=0;// счетчик количества элементов массива равняющимся нулю
		//int j=-1;
		//difference равно одному когда пользователь смезает ползунок медленно
		if (difference == 1) {
			if(last_ind_not_empty){
				if(retind>=this.count){
					retind=0;
				}
				if(retind==exeptionIndex){
					retind++;
				}
				while(means [retind] == 0 && decrease==false){
					retind++;
					if(retind>=count-1){
						//если последующие значения равны нулю то возвращается -1
						return -1;
					}
				}	
				if (decrease) {
					this.IncrementMean(retind);
					//means [retind]++;
					retind++;
				} else {
					this.DecrementMean(retind);
					//means [retind]--;
					retind++;
				}
			}
			difference=0;
			/*if(this.test3()){
				Debug.Log ("true");
			}else{
				Debug.Log ("false  /");
				Debug.Log("diff= /"+difference);
			}*/
			return  retind;
		}
		//это схема хорошо работает если diff больше 2-3
		if (difference >1) {
			while (difference>0) {
				if (indexOfSlider == count) {
					indexOfSlider = 0;
					continue;
				}
				if (indexOfSlider == exeptionIndex) {
					indexOfSlider++;
					continue;
				}
				if(indexOfSlider==last_indexOfSlider){
					indexOfSlider++;
					continue;
				}
				while (means [indexOfSlider] == 0 && decrease==false) {
					indexOfSlider++;
					if(indexOfSlider>=count-1){
						return -1;
					}
					continue;

				}


				if (decrease) {
					this.IncrementMean(indexOfSlider);
					//means [indexOfSlider]++;
					indexOfSlider++;
					retind=indexOfSlider;
					difference--;
				} else {
					this.DecrementMean(indexOfSlider);
					//means [indexOfSlider]--;
					indexOfSlider++;
					retind=indexOfSlider;
					difference--;
				}

			}

		}//конец условия difference>1

		//функцию test желательно запускать если слайдер настроили на максимум или на минимум.
		if(this.test3()){
			Debug.Log ("true");
		}else{
			Debug.Log ("false  /");
			//при помощи других функций вычислить разницу между правильной суммой ост. элементов 
			//и ложной и узнать она отрицательная или положительная.
			//при работе со слайдерами происходит баг
			//в рез-те которого некоторый слайдеры по значению становятся излишне высокими или низкими
			//эта функция выравнивает это значение, так чтобы в сумме они все были вновь равны summ
			int d=difference_between_exp_and_require_summ_elem(exeptionIndex);
			//d - difference сама разница, то есть насколько уменьшаем или увеличиваем
			//int max_ind = search_max (means,exeptionIndex);//увеличивать или уменьшать мы будем 
			//максимальный элемент.
			conversion(exeptionIndex,d);	
		}
		return retind;
		
	}
	//проверка когда будем выходить из меню настроек
		public void Pre_convers(){
		if(this.test3()==false){

		}
	}
		public void Pre_convers(int exeptionIndex){

			
	}



	//в том случае если значения элементов массива в сумме будут меньше или больше нужного, то срабатывает эта функция, она находит самое большое или малое значение и именяет его для
	//в качестве аргумента - текущий изменяемый индекс, diference разница между ложными и истинными суммами
	void conversion(int exceptIndex,int difference){
		/*цель - эта функция долна сгладить значения так чтобы их сумма между собой 
		 * снова была равна 16, при этом все должно выглядеть равномерно и красиво.
		 * у нас уже есть:
		 * -сумма всех оставшихся эелементов требуемая
		 * -сумма всех оставшихся элементов ложная, т.е. то что у нас случайно получилась
		 * при перемещении слайдеров.
		 * total_summ_exp;//экспериментальная сумма всех элементов массива
		 * exp_summ_left_elements;экспериментальная сумма оставшихся элементов
		 * summ_left_elements;//тоже самое что и наверху, то толдько уже требуемая.
		 * difference- разница между ними.
		 * алгоритм:
		 * 1.проверить имеются ли элементы которые по случайности меньше нуля (баг который это 
		 * допускает пока не найден)
		 * 2. поиск максимального значения среди элемнтов исключая индекс текущего элемента
		 * 3.уменьшение максимального элемента до значения, чтобы сумма всех элементов равнялась требуемого count
		 */
		negative_means_to_zero(exceptIndex);
		int max_ind = search_max (means,exceptIndex);
		if (difference < 0) {
			means [max_ind] += difference;//то есть difference в этом случае оказался отрицательным (плюс на минус дает минус)т.к. экспериментальная и текущая сумма count-1 элементов, в нашем случае 3 из 4 оказалась больше требуемой (требуемая минус экспер.)
		} else {
			means [max_ind] -= difference;//тут значение уже больше нуля, а значит можно смело отнимать.
		}
	}

	//если авдруг в массиве случайно оказались отрицательные числа, то эта функция переведет их в нули
	private void negative_means_to_zero(int exceptInd){
		int i = 0;
		while (i<this.count) {
			if(i==exceptInd){
				i++;
				continue;
			}
			if(this.GetMeanOfSlider(i)<0){
				this.SetMeanInSlider(i,0);
			}
			i++;

		}
	}


	//return max index, except index current elem
	private int search_max(int[] arr, int exceptInd){
		int max_ind=0;

		//int len_left = arr.Length - 1;
		int tempExceptMean=arr[exceptInd];
		arr [exceptInd] = 0;
		int max_elem = arr [max_ind];
		for(int i=1;i<arr.Length;i++){
			if(arr[i]>max_elem){
				max_elem=arr[i];
				max_ind=i;
			}
		}
		arr [exceptInd] = tempExceptMean;
		return max_ind;
	}

	//return max index
	private int search_max(int[] arr){
		int max_ind = 0;
		int max_elem = arr[0];
		for (int i=1; i<arr.Length; i++) {
			if(arr[i]>max_elem){
				max_elem=arr[i];
				max_ind=i;
			}
		}
		return max_ind;
	}

	public void Print(){
		int x=0;
		while(x<count){
			Debug.Log(means[x]);
			x++;
		}
	}
	
}


