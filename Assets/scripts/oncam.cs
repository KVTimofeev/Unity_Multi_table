using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class oncam : MonoBehaviour {
	//PictureGo - переменная в которой хранится массив спрайтов картинок которые угадывает пользователь, т.е. является меняемым фоном в current_fon
	public Sprite[] PictureGo;
	//current спрайт который является текущим фоном, т.к. когда пользователь угадывает картинку эта переменная менятся на другую картинку из PictureGo
	public Sprite[] AnimalsPicters;
	public Sprite[] CartoonsPicters;
	public Sprite[] CountriesPicters;

	public Sprite current;
	//kvadrat это спрайт на которм пишется математический пример (квадритик в двумерном массиве), который вычисляет пользователь при его нажатии
	public GameObject kvadrat;
	//okno_calc - составной объект, который появляется при нажатии пользователя на kvadrat. в окне также отображается как okno_calc;
	public GameObject Okno_calc;
	//simbol - буква, принажатии которой набирается текст ответа.
	public GameObject simbol;
	int currentIndexQuest=0;


	// Use this for initialization
	void Start () {
		//не хватает появлениея ответа при угадывании всех примеров!!!!!!!!!!!!!!!!

		if (tables.PictureGo == null) {

			switch(tables.Category){
			case tables.Categories.ANIMALS:tables.PictureGo=AnimalsPicters; 
				tables.answers_PicturesGo=tables.answers_PictureGo_Animals;
				break;
			case tables.Categories.COUNTRIES:tables.PictureGo=CountriesPicters;
				tables.answers_PicturesGo=tables.answers_PictureGo_Contries;
				break;
			//default:
			//	tables.PictureGo=PictureGo; break;

			}
			//tables.PictureGo = PictureGo;
			tables.currentQuestIndex = 0;
			//tables.answers_PicturesGo = new string[]{"домик","пустыня","коала","пингвины"};
			current=tables.PictureGo[currentIndexQuest];


		} else {
			//Debug.Log("zoom "+currentIndexQuest);
			tables.currentQuestIndex++;


		}
		SpriteRenderer currentFon = (SpriteRenderer)GameObject.Find ("current_fon").GetComponent<SpriteRenderer>() as SpriteRenderer;
		current=tables.PictureGo[tables.currentQuestIndex];
		currentFon.sprite = current;
		currentIndexQuest = tables.currentQuestIndex;

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
		}

		okno_enter_answer ();
	}

	void okno_calc(){
		float float_x = Okno_calc.transform.position.x;
		float float_y = Okno_calc.transform.position.y;
		Okno_calc.transform.position = new Vector3 (float_x, float_y, tables.zone_unvisible_z);
		}

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
