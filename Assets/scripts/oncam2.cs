﻿using UnityEngine;
using System.Collections;

public class oncam2 : MonoBehaviour {
	string Tag="oncam2:";
	//PictureGo - переменная в которой хранится массив спрайтов картинок которые угадывает пользователь, т.е. является меняемым фоном в current_fon
	public Sprite[] PictureGo;
	//current спрайт который является текущим фоном, т.к. когда пользователь угадывает картинку эта переменная менятся на другую картинку из PictureGo
	public Sprite[] AnimalsPicters;
	public Sprite[] CartoonsPicters;
	public Sprite[] CountriesPicters;
	//current переменная при помощи которой будет менятся картинка происходит на 59
	//public Sprite current;
	public GameObject current;//он же lighthouse
	public TextMesh Question;
	//kvadrat это спрайт на которм пишется математический пример (квадритик в двумерном массиве), который вычисляет пользователь при его нажатии
	public GameObject kvadrat; //он же kubik2
	//okno_calc - составной объект, который появляется при нажатии пользователя на kvadrat. в окне также отображается как okno_calc;
	public GameObject Okno_calc;
	//simbol - буква, принажатии которой набирается текст ответа.
	public GameObject simbol;
	int currentIndexQuest=0;
	
	
	// Use this for initialization
	void Start () {
		Question.text="works";


		//не хватает появлениея ответа при угадывании всех примеров!!!!!!!!!!!!!!!!
		//если категория не выбрана то..
		if (tables.PictureGo == null) {

			//в stat string category хранится строковое значения категории которая была выбрана в меню

			switch(tables.Category){
			case tables.Categories.ANIMALS:tables.PictureGo=AnimalsPicters; 
				tables.answers_PicturesGo=tables.answers_PictureGo_Animals;
				break;
			case tables.Categories.COUNTRIES:tables.PictureGo=CountriesPicters;
				tables.answers_PicturesGo=tables.answers_PictureGo_Contries;
				break;
				default:
					tables.PictureGo=PictureGo; break;
				
			}
			//если нужно тестировать эту сценку без меню игры, то можно снять комментарий
			//в результате верхний алгоритм необязателен.
			//tables.PictureGo = PictureGo;
			tables.currentQuestIndex = 0;
			//tables.answers_PicturesGo = new string[]{"домик","пустыня","коала","пингвины"};
			//Sprite curSpr=current.GetComponent<SpriteRenderer>().sprite;
			//curSpr=tables.PictureGo[currentIndexQuest];

		//другой случай, т.е. если picturego уже чему то равен	
		} else {
			//Debug.Log("zoom "+currentIndexQuest);
			tables.currentQuestIndex++;
			//tables.currentQuestIndex = 0;
			
		}
		/*
		 * 
		 */

		//для эксперимента пока закомментирую данный отрывок внизу
		//SpriteRenderer currentFon = (SpriteRenderer)GameObject.Find ("current_fon").GetComponent<SpriteRenderer>() as SpriteRenderer;

		current.GetComponent<SpriteRenderer>().sprite=tables.PictureGo[tables.currentQuestIndex];
		//currentFon.sprite = current.GetComponent<SpriteRenderer>().sprite;
		currentIndexQuest = tables.currentQuestIndex;


		//вставленный скрипт из creat cubiks2 начало
		//block start

		//создание массива локальных координат для x y
		float[] coords_x =new float[4];
		float[] coords_y=new float[4];
		float coord_x = -3.85f,coord_y=-2.85f;
		for (int x=0; x<4; x++) {
			coords_x[x]=coord_x;
			coords_y[x]=coord_y;
			coord_x+=2.55f;
			coord_y+=1.9f;
		}
		
		
		/*создание таблицы (двухмерного массива клеточек 4 на 4 из Объекта kvadrat
		 * присвоение каждому эксземляру родителя.
		 * назначение каждому созданному экземляру отображаемый пример из ExampleList
		 * который также гегерируется отдельно
		 * и запись имени name состоящий из exNum и ans которые будут отображаться в окне 
		 * иерархии в качестве дочерних элемента в виде списка. exNum (example number) - это индекс по строке от 0 до 3
		 * ans (answer)-  это ответ на каждый пример для удобного последовательного 
		 * считывании другими объектами
		 * 
		 */
		ArrayList ExamplesList = creat_examples2();
		int i = 0,j=0,queque=0;
		while(j<4){
			while(i<4){
				GameObject element = Instantiate (kvadrat);
				//в прошлом слыае переменная currentPicture означал спрайт в котором хранится картинка, которую нужно угадать, и которая являлась родителем
				//в новом скрипте ее предположительное название просто current поэтому заменим
				//element.transform.SetParent (currentPicture.transform); //на
				SpriteRenderer sprite=(SpriteRenderer)element.GetComponent<SpriteRenderer> () as SpriteRenderer;
				sprite.sortingOrder = 0;
				element.transform.SetParent (current.transform);
				//однако переменная current имеет теперь тип sprite а мне нужен transform т.к. только этот тип мб родительским в unity
				element.transform.localPosition = new Vector2 (coords_x[i], coords_y[j]);
				TextMesh textLabelOnElement=(TextMesh)element.GetComponentInChildren<TextMesh>() as TextMesh;

				Example summa=ExamplesList[queque] as Example;				
				textLabelOnElement.text=summa.StrExample();
				element.name="exNum"+queque+"ans="+summa.Answer();
				queque++;
				i++;
			}
			j++;
			i=0;
		}


		//конец вставленного скрипта creat cubiks2










		/*
		//okno_calc ();
		float x_src_pos = -4.65f;
		float float_x = x_src_pos;//-6.4
		float float_y = 3.34f;//4.2
		int i = 1;
		tables.countSquares = 0;
		while (float_y>0f) {
			int queque=0;
			ArrayList ExamplesList = new ArrayList();
			ExamplesList.Add(new Summ());
			ExamplesList.Add(new DifferenceEx());
			ExamplesList.Add(new Multiplication());
			ExamplesList.Add(new Division());
			ExamplesList.Add(new Multiplication());
			ExamplesList.Add(new Multiplication());
			ExamplesList.Add(new Multiplication());
			ExamplesList.Add(new Multiplication());
			helper helperCreateExample = helper.TakeHelper();
			int[] seqExamples={0,1,2,3,4,5,6,7};
			seqExamples=helperCreateExample.ShuffleInts(seqExamples);
			while (float_x<1.5) {
				tables.countSquares++;
				GameObject go = Instantiate (kvadrat) as GameObject;
				
				go.transform.position = new Vector2 (float_x, float_y);
				TextMesh txtOnKvadratik=(TextMesh)go.GetComponentInChildren<TextMesh>() as TextMesh;
				//helper helperCreateExample = helper.TakeHelper();
				
				//сюда вставить функцию которая будет взаимоменять примеры между собой example summ differecne
				//example ex=func(queque);
				
				Example summa=ExamplesList[seqExamples[queque]] as Example;
				queque++;
				
				
				txtOnKvadratik.text=summa.StrExample();
				//Summ summa = new Summ();
				//txtOnKvadratik.text=Summ.StrExample();
				
				go.name="exNum"+i+"ans="+summa.Answer();
				
				i++;
				float_x += 1.7f;
			}
			float_x=x_src_pos;
			float_y-=0.9f;
		}*/
		
		//okno_enter_answer ();
	}

	//из вставленного скрипта creat_cubiks2 то что небыло внутри start
	//start



	//конец вставленного скрипта create_cubiks2

	//начало новой функции createexamples()
	ArrayList creat_examples2(){
		ArrayList ExamplesList = new ArrayList();

		int[] counts_examples = {
			tables.count_examples_for_summ,
			tables.count_examples_for_subvision,
			tables.count_examples_for_multiply,
			tables.count_examples_for_division
		};
		//int[] counts_examples = {5,3,6,2};
		int all_examples = 16;
		tables.countSquares = all_examples;
		int i = 0,j=0;
		Example[] exmls=new Example[all_examples];
		while (i<tables.count_sliders) {
			int countEx=counts_examples[i];

			while(countEx>0){
				//exmls[countEx-1]=MakeExample(i);
				exmls[j]=MakeExample(i);
				j++;
				//ExamplesList.Add(MakeExample(i));
				countEx--;
			}
			i++;
		}
		int[] rand_indexes = helper.ShuffleInts2 (all_examples);
		for(int x=0;x<all_examples;x++){
			ExamplesList.Add(exmls[rand_indexes[x]]);
		}
		return ExamplesList;
	}

	public Example MakeExample(int i){
		Example ex=new Summ();
		switch (i) {
		case 0:ex=new Summ();break;
		case 1:ex=new DifferenceEx ();break;
		case 2:ex=new Multiplication ();break;
		case 3:ex=new Division (); break;
		}
		return ex;
	}













	
	void okno_calc(){
		float float_x = Okno_calc.transform.position.x;
		float float_y = Okno_calc.transform.position.y;
		Okno_calc.transform.position = new Vector3 (float_x, float_y, tables.zone_unvisible_z);
	}
	/*
	void okno_enter_answer(){
		float bukv_x = -5f;
		float bukv_y = -1.8f;
		tables.answer_current_fon = tables.answers_PicturesGo[currentIndexQuest];
		string str = tables.answer_current_fon;
		helper helpForAnswerStr = helper.TakeHelper ();
		int countSimbs = 8;
		int ost = countSimbs - str.Length;
		str = helpForAnswerStr.addedSimbols (str, str.Length + ost);
		str = helpForAnswerStr.Shuffle (str);
		int str_len = str.Length;
		while (str_len>0) {
			GameObject simb = Instantiate (simbol) as GameObject;
			simb.transform.position = new Vector3 (bukv_x,bukv_y,tables.zone_visible_z);
			simb.transform.parent=GameObject.Find ("picter_answered_wind").transform;
			TextMesh charSimb=simb.GetComponentInChildren<TextMesh>() as TextMesh;
			
			charSimb.text=str[str_len-1]+"";
			simb.name=str[str_len-1]+"";
			
			str_len--;
			bukv_x+=1.5f;
		}
	}
	*/
	
	/*
	public string Shuffle(string str)
	{
		char[] array = str.ToCharArray();
		//Random rng = new Random();
		int n = array.Length;
		while (n > 1)
		{
			n--;
			int k = Random.Range(0,n + 1);
			var value = array[k];
			array[k] = array[n];
			array[n] = value;
		}
		return new string(array);
	}
*/
	
	
	// Update is called once per frame
	void Update () {
		
	}
}
