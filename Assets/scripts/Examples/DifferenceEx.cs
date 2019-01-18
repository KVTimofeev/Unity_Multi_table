using UnityEngine;
using System.Collections;

public class DifferenceEx : Example{
	public DifferenceEx(int firstSlag,int secondSlag) 
		:base(firstSlag,secondSlag)
	{
		sign='-';
		if (this.SecondSlag > this.FirstSlag) {
			int temp=this.SecondSlag;
			this.SecondSlag=this.FirstSlag;
			this.FirstSlag=temp;
		}
	}

	public DifferenceEx(){
		this.sign = '-';
		if (this.SecondSlag > this.FirstSlag) {
			int temp=this.SecondSlag;
			this.SecondSlag=this.FirstSlag;
			this.FirstSlag=temp;
		}
	}
	public override int Answer(){
		return this.FirstSlag - this.SecondSlag;
	}


}
