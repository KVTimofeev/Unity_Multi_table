using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class tables  {

	// Use this for initialization
	//public static int a;
	//public static int b;
	public static int answer;
	public static string Managerlevel="ManagerLevel";
	public static string enter_answer;
	public static string str_id;
	public static float zone_unvisible_z=-30f;
	public static float zone_visible_z=-1f;
	public static string answer_current_fon;
	public static Sprite[] PictureGo;
	public static Sprite current_s_srite;
	public static string[] answers_PicturesGo =new string[]{"домик","пустыня","коала","пингвины"};
	public static int currentQuestIndex=0;
	public static int countSquares = 0;

	public static Stack<SimbolsAnsw>stack_delets_simbols_current_lev;



	public static int GetCurrentIndex{
		set{
			if(value==PictureGo.Length){
				currentQuestIndex=0;
			}

		}
		get{
			return currentQuestIndex;
		}
	}


}
