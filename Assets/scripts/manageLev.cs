using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;
public class manageLev : MonoBehaviour {
	public string Tag="manageLev:";
	public GameObject Next;
	public GameObject Answer;
	/*next - окошко с надписью next в интерфейсе, появляется справа при угадывании или разгадки картинки
	 * при нажатии на нее мы переходим к следующей картинке.
	 * 
	 * 
	 */

	public GameObject Picture_answer;//окно ответа
	// Use this for initialization
	void Start () {
		Sprite spr = new Sprite ();

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void Won(){


	}
	/*
	public void DoItInvisible(GameObject go){

		float x = go.transform.position.x;
		float y = go.transform.position.y;
		go.transform.position = new Vector3 (x,y,tables.zone_unvisible_z);
	}
	public void DoItVisible(GameObject go){
		float x = go.transform.position.x;
		float y = go.transform.position.y;
		go.transform.position = new Vector3 (x,y,tables.zone_visible_z);
	}
*/

	public void EndLevel(){

		GameObject calc = GameObject.Find (tables.HierarchyNames.NUMS_WIND_CALC);
		//GameObject pict_answ = GameObject.Find ("picter_answered_wind");
		if (calc != null) {
			Destroy (calc);
		} else {
			Debug.Log(Tag+"окно клавиатуры для ввода ответа не найден");
		}
		if (Picture_answer!= null) {
			Picture_answer.GetComponentInChildren<TextMesh> ().text = "";
			Picture_answer.SetActive (false);
		} else {
			Debug.Log(Tag+"picture_for_answer не найден и невозможно деактивировать");
		}
		GameObject next_go=Instantiate (Next);
		GameObject main_cam = GameObject.Find ("Main Camera");
		if (main_cam == null) {
			Debug.Log (Tag+" Будущий родительский объект main camera для объекта next не найден в иерархии");
		} else {
			next_go.transform.SetParent (main_cam.transform);
		}
		if (Answer != null) {
			Answer.SetActive (true);
			Answer.GetComponent<TextMesh>().text="Верно, молодец!\n Ответ:'"+tables.answer_current_fon+"'";
		} else {
			Debug.Log(Tag+"Окно answer не найдено ");
		}

	}
}
