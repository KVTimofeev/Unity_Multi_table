using UnityEngine;
using System.Collections;

public class creat_cubiks2 : MonoBehaviour {
	public GameObject kvadrat;
	public GameObject currentPicture;


	// Use this for initialization
	void Start () {
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

				//GameObject currentPict = (GameObject)currentPicture as GameObject;
				//экспериментальная замена currentPicture на currentPict с gameobject на sprite
				element.transform.SetParent (currentPicture.transform);
				element.transform.localPosition = new Vector2 (coords_x[i], coords_y[j]);
				TextMesh textLabelOnElement=(TextMesh)element.GetComponentInChildren<TextMesh>() as TextMesh;
				Example summa=ExamplesList[++queque] as Example;				
				textLabelOnElement.text=summa.StrExample();
				element.name="exNum"+i+"ans="+summa.Answer();	
				i++;
			}
			j++;
			i=0;
		}
	}//end Start()


	/*генерирование 4 примеров из которых будут создаваться вся таблица
	 * 
	 * */

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
	
	// Update is called once per frame
	void Update () {
	
	}
}
