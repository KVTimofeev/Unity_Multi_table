using UnityEngine;
using System.Collections;

public class Multiplication : Example {
	public Multiplication(int firstSlag,int secondSlag) 
		:base(firstSlag,secondSlag)
	{
		sign='*';
		
	}
	public Multiplication() 
	{
		sign='*';
	}
	public override int Answer(){
		return this.FirstSlag*this.SecondSlag;
	}


}
