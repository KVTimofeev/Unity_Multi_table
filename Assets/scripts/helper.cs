using UnityEngine;
using System.Collections;

public class helper {
	static string Tag="helper:";
	private static helper singleObj;
	public static helper TakeHelper(){
		if (singleObj == null) {
			singleObj=new helper();
		}
		return singleObj;
	}
	//данная функция создает пример наквадратике
	public void create_example(string example,int answer){
		//int a = Random.Range (1,9);
		//int b = Random.Range (1, 9);
		Summ sum = new Summ ();
		example= sum.StrExample();
		answer = sum.Answer ();
	}
/*
	public int[] ShuffleInts(int[] mass){
		int n = mass.Length;
		while (n>1) {
			n--;
			int r=Random.Range(0,n+1);
			int val=mass[r];
			mass[r]=mass[n];
			mass[n]=val;
			}
		return mass;
	}

*/

	public static int[] ShuffleInts2(int len){
		//int len = 15;
		int[] buff=new int[len] ;
		int[] ret_arr = new int[len];
		try{
			//заполняем массив буфера каждое знчаение по индексу
			for (int i=0; i<len; i++) {
				
				buff[i]=i;
			}
			int c = len;
			//мы создали вторую переменнну типа count чтобы ее можно было сокращать.
			/*после того как создали массив (0,1,2,3....)
		 * берем из них случайное число, записываем во второй маассив, которое впоследствии возвращаем,
		 * а в первом массиве делаем смещение влево, чтобы числа не повторялись
		 * 
		 */
			

			for (int i=0; i<len; i++) {
				Debug.Log(Tag+"Hello, world!"+i+" len= "+len+" c= "+c);
				int r=Random.Range(0,c);
				ret_arr[i]=buff[r];
				Debug.Log(Tag+"num= "+ret_arr[i]);
				for(int j=r;j!=c-1;j++){                
					buff[j]=buff[j+1];
				}
				c=c-1;
			}
		}catch(System.IndexOutOfRangeException e){
			Debug.Log(Tag+"exep");
		}
		return ret_arr;
		
	}



	/// <summary>
	/// функция которая перемешиват буквы в строке
	/// </summary>
	/// <param name="str">String.</param>
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
	//функция которая добавляет буквы в строку для последующего перемешивания;
	//str-входящее слово, которая обычно является в игре ответом, длина должна быть не боллее totalcounts
	//totalCounts - общее количество букв, которая должна получится, т.е. уже учитываются и количество букв в переменной str и уже добавленные буквы, которые в конечном итоге запутывают пользователя
	public string addedSimbols(string str, int totalCounts){
		int str_len = str.Length;
		//count_simbols_for_add колв-во симоволов которые будут добавлены
		int count_simbols_for_add = totalCounts - str_len;
		//char[] alphavet = {'А','Б','В','Г','Д','Е','Ё','Ж','З','И','К','Л','М','Н','О','П','Р','С','Т','У','Ф','К','Ц','Ч','Ш','Щ','Ъ','Ы','Ь','Э','Ю','Я'};
		//string alphavet_str = "АБВГДЕЁЖЗИКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ"; алфавит крупными
		string alphavet_str = "абвгдеёжзиклмнопрстуфхцчшщъыьэюя";
		int alphavetLen=alphavet_str.Length;
		//набираем массив рандомных букв
		char[] rand_simbols=new char[count_simbols_for_add];
		int i = 0; 
		//start
		while (i<count_simbols_for_add) {
			int r = Random.Range (0, alphavetLen);
			char random_char_from_alph = alphavet_str[r];
			//сюда желательно запихать функцию, которая уничтожит букву из алфавита, т.е. alphavet[r], чтобы не набирались одни и теже буквы в массив букв.
			alphavet_str=deleteSimbol(alphavet_str,r);
			//alphavet_str=alphavet_str.Remove(r,);

			//string s = "kuzenka";
			//char[] ar = {'z'};
			//string[] s_mass = s.Split (ar);
			//Debug.Log (s_mass[0]);
			//0-ku 1-enka



			//
			rand_simbols [i] = random_char_from_alph;
			i++;
			alphavetLen=alphavet_str.Length;
		}
	//string s = stringToChar(rand_simbols);
		return str + stringToChar(rand_simbols);

	}
	/// <summary>
	/// функция которая переводит char[] в string т.к. string тупит и не переводит!
	/// </summary>
	/// <returns>The to char.</returns>
	/// <param name="arr">Arr.</param>
	private string stringToChar(char[] arr){
		int len=arr.Length;
		string ret_str="";
		int i = 0;
		while (i<len) {
			ret_str=ret_str+arr[i];
			i++;
		}
		return ret_str;
	}



	//удаляет любой символ из строки
	public string deleteSimbol(string str,int simb){
		char[] ch_arr = {str[simb]};
		string[] strs = str.Split (ch_arr);
		return strs[0]+strs[1];
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



}
