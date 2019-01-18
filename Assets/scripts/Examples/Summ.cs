using UnityEngine;
using System.Collections;

public class Summ : Example {
	public Summ(int firstSlag,int secondSlag) 
	:base(firstSlag,secondSlag)
	{
		sign='+';

	}
	public Summ() 

	{
		sign='+';
		
	}
	public override int Answer(){
		return this.FirstSlag + this.SecondSlag;
	}


}
