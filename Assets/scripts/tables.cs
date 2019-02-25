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
	public static string[] answers_PictureGo_Animals=new string[]{
		"белка",
		"рысь",
		"лев",
		"крокодил"
	};
	public static string[] answers_PictureGo_Contries=new string[]{
		"англия",
		"италия",
		"австралия",
		"антарктика",
		"африка"
	};

	public static int currentQuestIndex=0;
	public static int countSquares = 0;
	public static string Category="";

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
	public static class Categories{
		public const string ANIMALS="Animals";
		public const string COUNTRIES="Countries";
		public const string CARTOONS="Cartoons";
	}


}
