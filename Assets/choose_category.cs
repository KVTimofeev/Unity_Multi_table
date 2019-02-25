using UnityEngine;
using System.Collections;

public class choose_category : MonoBehaviour {
	string result;
	// Use this for initialization
	void Start () {

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){
		var name = gameObject.name;
		switch (name) {
		case "Animals":tables.Category=tables.Categories.ANIMALS;
			break;
		case "Cartoons":tables.Category=tables.Categories.CARTOONS;
			break;
		case "Contries":tables.Category=tables.Categories.COUNTRIES;
			break;

		}
		Application.LoadLevel (2);


		}


}
