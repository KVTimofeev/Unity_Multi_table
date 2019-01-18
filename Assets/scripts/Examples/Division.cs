using UnityEngine;
using System.Collections;

public class Division : Example {


	public Division(int firstSlag,int secondSlag) 
		:base(firstSlag,secondSlag)
	{
		sign='/';
		Fun ();

	}
	public Division() 
	{
		sign='/';
		Fun ();
		
	}
	void Fun(){
		this.answer = this.FirstSlag* this.SecondSlag;
		int r = Random.Range (1, 2);
		int temp;
		switch (r) {
			//2*3=6
			//6/3=2
			//6/2=3
		case 1:temp = this.FirstSlag;//temp=2
			this.FirstSlag = this.answer;//first=6 inplace 2  6/3=6
			this.answer=temp;//answer=2 6/3=2
			break;

		case 2:
			temp=this.FirstSlag;//temp=2
			this.FirstSlag=this.answer;//first=6 6/3=6
			this.SecondSlag=temp;//answer=3 6/2=3
			break;

	



		}

	}
	

	public override int Answer(){
		return this.answer;
	}


}
