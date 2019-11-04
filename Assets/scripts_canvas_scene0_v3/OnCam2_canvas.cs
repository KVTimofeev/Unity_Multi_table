using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class OnCam2_canvas : MonoBehaviour {

	string Tag="OnCam2_canvas: ";
	//PictureGo - переменная в которой хранится массив спрайтов картинок которые угадывает пользователь, т.е. является меняемым фоном в current_fon
	//public Sprite[] PictureGo;
	//current спрайт который является текущим фоном, т.к. когда пользователь угадывает картинку эта переменная менятся на другую картинку из PictureGo
	//public Sprite[] AnimalsPicters;
	//public Sprite[] CartoonsPicters;
	//public Sprite[] CountriesPicters;
	//current переменная при помощи которой будет менятся картинка происходит на 59
	//public Sprite current;
	public RawImage MainPictRawImg;//он же lighthouse
	public Text Question;
	public Button kletka;
	//kvadrat это спрайт на которм пишется математический пример (квадритик в двумерном массиве), который вычисляет пользователь при его нажатии
	public Image Cell; //он же kubik2
	//okno_calc - составной объект, который появляется при нажатии пользователя на kvadrat. в окне также отображается как okno_calc;
	//public GameObject Okno_calc;
	//simbol - буква, принажатии которой набирается текст ответа.
	//public GameObject simbol;
	int currentIndexQuest=0;



	
	// Use this for initialization
	void Start () {
		Question.text="worksC";

		
		Texture textureForMainPictRawImg = Resources.Load<Texture> ("crocodile");
		if (textureForMainPictRawImg == null) {
			Debug.Log (Tag + " texture for MainPictRawImg не назначен");
		} else {
			MainPictRawImg.texture = textureForMainPictRawImg;
		}

		//текущий индекс задания или вопроса.
		currentIndexQuest = tables.currentQuestIndex;

		
		//вставленный скрипт из creat cubiks2 начало
		//block start

		//создание массива локальных координат для x y для canvas
		//для UI
		//float[] coords_x =new float[4];
		//float[] coords_y=new float[4];

		//возьмем размеры нашего lighthouse, сейчас он назыв MainPictRawImg, размеры хранятся в объекте rectTransform rect
		Rect rect = MainPictRawImg.rectTransform.rect;
		float widthRawImg = rect.width;//ширина окошка lighthouse
		float heightRawImg = rect.height;//высота окошка lighthouse

		create_2Darray_cells (4, 4);

		/*
		Image CloneCell = Instantiate (Cell);
		CloneCell.rectTransform.parent=MainPictRawImg.rectTransform;
		float s = widthRawImg / 8;
		float sVert = heightRawImg / 8;
		float sizeCellX = 3.2f;
		float sizeCellY = 1.8f;
		CloneCell.GetComponentInChildren<Text>().text="-s";
		CloneCell.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal,sizeCellX);
		CloneCell.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical,sizeCellY );
		CloneCell.rectTransform.localPosition = new Vector3 ((float)(-s),0f,0f);



		Image CloneCell2 = Instantiate (Cell);
		CloneCell2.rectTransform.parent=MainPictRawImg.rectTransform;
		CloneCell2.GetComponentInChildren<Text>().text="-s*3";
		CloneCell2.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal,sizeCellX);
		CloneCell2.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical,sizeCellY);
		CloneCell2.rectTransform.localPosition = new Vector3 ((float)(-s*3),0f,0f);


		Image CloneCell3 = Instantiate (Cell);
		CloneCell3.rectTransform.parent=MainPictRawImg.rectTransform;
		CloneCell3.GetComponentInChildren<Text>().text="s -sVert";
		float sign = -1;
		CloneCell3.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal,sizeCellX);
		CloneCell3.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical,sizeCellY);
		CloneCell3.rectTransform.localPosition = new Vector3 ((float)(s),(float)(sign*sVert),0f);
		Debug.Log ("-sVert"+(-sVert));
		Image CloneCell4 = Instantiate (Cell);
		CloneCell4.GetComponentInChildren<Text>().text="s sVert";
		CloneCell4.rectTransform.parent=MainPictRawImg.rectTransform;
		CloneCell4.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal,sizeCellX);
		CloneCell4.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical,sizeCellY);
		CloneCell4.rectTransform.localPosition = new Vector3 ((float)(s),(float)(sVert),0f);

		Image CloneCell5 = Instantiate (Cell);
		CloneCell5.rectTransform.parent=MainPictRawImg.rectTransform;
		CloneCell5.GetComponentInChildren<Text>().text="s sVert*3";
		CloneCell5.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal,sizeCellX);
		CloneCell5.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical,sizeCellY);
		CloneCell5.rectTransform.localPosition = new Vector3 ((float)(s),(float)(sVert*3),0f);

*/




		/*старая версия для спрайтовой версии
		float[] coords_x =new float[4];
		float[] coords_y=new float[4];
		float coord_x = -3.85f,coord_y=-2.85f;
		for (int x=0; x<4; x++) {
			coords_x[x]=coord_x;
			coords_y[x]=coord_y;
			coord_x+=2.55f;
			coord_y+=1.9f;
		}
		*/
		
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
				//GameObject element = Instantiate (kvadrat);
				//в прошлом слыае переменная currentPicture означал спрайт в котором хранится картинка, которую нужно угадать, и которая являлась родителем
				//в новом скрипте ее предположительное название просто current поэтому заменим
				//element.transform.SetParent (currentPicture.transform); //на
				//SpriteRenderer sprite=(SpriteRenderer)element.GetComponent<SpriteRenderer> () as SpriteRenderer;
				//sprite.sortingOrder = 0;
				//element.transform.SetParent (current.transform);
				//однако переменная current имеет теперь тип sprite а мне нужен transform т.к. только этот тип мб родительским в unity
				//element.transform.localPosition = new Vector2 (coords_x[i], coords_y[j]);
				//TextMesh textLabelOnElement=(TextMesh)element.GetComponentInChildren<TextMesh>() as TextMesh;
				
				Example summa=ExamplesList[queque] as Example;				
				//textLabelOnElement.text=summa.StrExample();
				//element.name="exNum"+queque+"ans="+summa.Answer();
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
	
	//создание массива клеточек
	void create_2Darray_cells(int oborot,int extern_oborot){
		//возьмем размеры нашего lighthouse, сейчас он назыв MainPictRawImg, размеры хранятся в объекте rectTransform rect
		Rect rect = MainPictRawImg.rectTransform.rect;
		float widthRawImg = rect.width;//ширина окошка lighthouse
		float heightRawImg = rect.height;//высота окошка lighthouse
		float sizeCellX = 3.2f;
		float sizeCellY = 1.8f;
		float koef_1=1f,koef_2=1f;
		//hor_coord координата по горизонтали. замена s
		float hor_coord = widthRawImg / 8;
		float vert_coord = heightRawImg / 8;
		int koeff = 1;//коэффициент;
		for (int i=0; i<extern_oborot; i++) {
			switch(i){
			case 0: koef_1=1f; koef_2=1f;break;
			case 1: koef_1=3f; koef_2=3f;break;
			case 2: koef_1=1f; koef_2=3f;break;
			case 3: koef_1=3f; koef_2=1f;break;
			}
			creat_oborot_cells(oborot,sizeCellX,sizeCellY,hor_coord,vert_coord,koef_1,koef_2);
		}
	}
	private void creat_oborot_cells(int oborot,float sizeCellX,float sizeCellY,float hor_coord,float vert_coord,float koef_1,float koef_2){
		float sign_1 = 1f, sign_2 = 1f;
		for(int j=0;j<oborot;j++){
			switch(j){
			case 0: sign_1=1f;sign_2=1f;break;
			case 1: sign_1=1f;sign_2=-1f;break;
			case 2: sign_1=-1f;sign_2=1f;break;
			case 3: sign_1=-1f;sign_2=-1f;break;
			}
			//create_clone_cell(sizeCellX,sizeCellY,hor_coord,vert_coord,sign_1, sign_2);
			Image CloneCell = Instantiate (Cell);
			//Rect rectCell = CloneCell.rectTransform.rect;
			CloneCell.rectTransform.parent=MainPictRawImg.rectTransform;
			CloneCell.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal,sizeCellX);
			CloneCell.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical,sizeCellY );
			CloneCell.rectTransform.localPosition = new Vector3 ((float)(sign_1*hor_coord*koef_1),(float)(sign_2*vert_coord*koef_2),0f);

		}
	}



	private void create_clone_cell(float sizeCellX,float sizeCellY,float hor_coord,float vert_coord,
	                               float sign_1, float sign_2){
		Image CloneCell = Instantiate (Cell);
		//Rect rectCell = CloneCell.rectTransform.rect;
		CloneCell.rectTransform.parent=MainPictRawImg.rectTransform;
		CloneCell.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal,sizeCellX);
		CloneCell.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical,sizeCellY );
		CloneCell.rectTransform.localPosition = new Vector3 ((float)(sign_1*hor_coord),(float)(sign_2*vert_coord),0f);
	}
	
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
	
	
	
	
	
	
	
	
	
	
	
	
	
	/*
	void okno_calc(){
		float float_x = Okno_calc.transform.position.x;
		float float_y = Okno_calc.transform.position.y;
		Okno_calc.transform.position = new Vector3 (float_x, float_y, tables.zone_unvisible_z);
	}

*/

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
