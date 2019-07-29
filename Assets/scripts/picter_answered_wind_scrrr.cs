using UnityEngine;
using System.Collections;

public class picter_answered_wind_scrrr : MonoBehaviour {

	public GameObject simbol;
	//название окна ввода ответа, отображается в иерархии
	string enter_answer_wind="picture_answered_wind";

	// Use this for initialization
	void Start () {

		//скопировано из oncam.cs 
		/*данный скрипт создан для окна где вводится название картинки, в
		 * которую пользователь вводит буквы. 
		 * Данный скрипт создает символы букв под данным окошком.
		 * 
		 */
		//void okno_enter_answer(){
		//x=-0.226
		//y=-0.72 это новые координаты каждого символа
			//float bukv_x = -5f;
			//float bukv_y = -1.8f;
		float bukv_x = -0.226f;
		float bukv_y = -0.72f;
		tables.answer_current_fon = tables.answers_PicturesGo[tables.currentQuestIndex];
			string str = tables.answer_current_fon;
			helper helpForAnswerStr = helper.TakeHelper ();
			int countSimbs = 8;
			int ost = countSimbs - str.Length;
			str = helpForAnswerStr.addedSimbols (str, str.Length + ost);
			str = helpForAnswerStr.Shuffle (str);
			int str_len = str.Length;
			while (str_len>0) {
				GameObject simb = Instantiate (simbol) as GameObject;
				

				simb.transform.parent=this.transform;
			simb.transform.localPosition = new Vector2 (bukv_x,bukv_y);
			simb.transform.localScale=new Vector2(0.05f,0.20f);

				TextMesh charSimb=simb.GetComponentInChildren<TextMesh>() as TextMesh;
				
				charSimb.text=str[str_len-1]+"";
				simb.name=str[str_len-1]+"";
				
				str_len--;
				bukv_x+=0.1f;
			}
		//}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
