using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class option_count_examples_for_types{
	public int procent_ex_for_summ;
	public int procent_ex_for_division;
	public int procent_ex_for_multiply;
	public int procent_ex_for_difference;
	public int count_examples_enter;
	public float max_procent=100;
	public option_count_examples_for_types(){

	}
	public void main_function(){


	}/*
	public ArrayList GetList(int summ,int diff,int divs,int multi){
		if (summ + diff + divs + multi == this.count_examples_enter) {
			ArrayList listExamples=new ArrayList();
			int count_horizontal_columns=Mathf.Sqrt(this.count_examples_enter);
			Example[][] exasmples_array=new Example[count_horizontal_columns][count_horizontal_columns];
			for(int y=0;y<count_horizontal_columns;y++){
				for(int x=0;x<count_horizontal_columns;x++){
					switch(x){
					case 0: exasmples_array[x][y]=new Summ(); summ--;break;
					case 1: exasmples_array[x][y]=new DifferenceEx(); diff--;break;
					case 2: exasmples_array[x][y]=new Multiplication(); multi--;break;
					}
				}
			}
			return null;

		

		} else {
			throw new UnityException("Сумма всех типов приеров не равна итоговой сумме");
		}

	}*/
}
