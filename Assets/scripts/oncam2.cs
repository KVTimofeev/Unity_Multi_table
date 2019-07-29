using UnityEngine;
using System.Collections;

public class oncam2 : MonoBehaviour {
	//PictureGo - переменная в которой хранится массив спрайтов картинок которые угадывает пользователь, т.е. является меняемым фоном в current_fon
	public Sprite[] PictureGo;
	//current спрайт который является текущим фоном, т.к. когда пользователь угадывает картинку эта переменная менятся на другую картинку из PictureGo
	public Sprite[] AnimalsPicters;
	public Sprite[] CartoonsPicters;
	public Sprite[] CountriesPicters;
	//current переменная при помощи которой будет менятся картинка происходит на 59
	//public Sprite current;
	public GameObject current;
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
		ArrayList ExamplesList = creat_examples ();
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

	//начало функции create_examples
	ArrayList creat_examples(){
		ArrayList ExamplesList = new ArrayList();
		Example[] stroka = {
			new Summ (),
			new DifferenceEx (),
			new Multiplication (),
			new Division ()
		};
		
		Example[] AllExamples = new Example[16];
		int x = 0;
		for (int i=0; i<4; i++) {
			for(int j=0;j<4;j++){
				//ExamplesList.Add(stroka[j]);
				AllExamples[x]=stroka[j];
				x++;
			}
		}
		
		//перемешивение примеров между собой и расстваление порядка.
		helper helperCreateExample = helper.TakeHelper();
		int[] seqExamples_indexes1={0,1,2,3,4,5,6,7};
		int[] seqExamples_indexes2={8,9,10,11,12,13,14,15};
		
		/*массив перемешивается не весь сразу а по кусочкам.
		 * поскольку изначально у нас 16 клеток с примерами
		 * то во избежание примеров которые могут не премешаться и находящиеся
		 * в конце мы берем сначала первые 8 примеров, перемешиваем затем следующие 8
		 * поэтому в seqExamples будет внесено первые 8 числе, которые в последствии
		 * будут индексами
		 */
		
		x = 0;
		seqExamples_indexes1=helperCreateExample.ShuffleInts(seqExamples_indexes1);//Shuffleints-перемешивание массива
		seqExamples_indexes2=helperCreateExample.ShuffleInts(seqExamples_indexes2);
		int[] totalSeqExamples_indexes = new int[seqExamples_indexes1.Length + seqExamples_indexes2.Length];
		seqExamples_indexes1.CopyTo (totalSeqExamples_indexes, 0);//arguments: array, index
		seqExamples_indexes2.CopyTo (totalSeqExamples_indexes, seqExamples_indexes1.Length);
		while (x<totalSeqExamples_indexes.Length) {
			ExamplesList.Add(AllExamples[totalSeqExamples_indexes[x]]);
			x++;
		}
		return ExamplesList;
	}//конец функции create examples

	//конец вставленного скрипта create_cubiks2







	
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
