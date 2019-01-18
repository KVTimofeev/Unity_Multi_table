using UnityEngine;
using System.Collections;

public abstract class Example : Object{
	public int FirstSlag{ get; set; }
	public int SecondSlag{get;set;}
	public char sign { get; set;}
	public int answer { get; set;}
	public Example(int a,int b){
		FirstSlag = a;
		SecondSlag = b;
		this.sign = ' ';
		this.answer = 0;
	}
	public Example(){
		FirstSlag = Random.Range (1, 9);
		SecondSlag = Random.Range (1, 9);
		this.sign = ' ';
		this.answer = 0;
	}
	public string StrExample(){
		return string.Format ("{0}{1}{2}",FirstSlag,sign,SecondSlag);
	}
	public virtual int Answer(){
		return 0;
	}

}
