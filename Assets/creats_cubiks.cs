using UnityEngine;
using System.Collections;


public class creats_cubiks : MonoBehaviour {
	public GameObject Kubik;
	public GameObject Kartinka;
	// Use this for initialization
	void Start () {
		//Kubik.transform.localScale = new Vector2 ((Kartinka.transform.localScale.x)/4,(Kartinka.transform.localScale.y)/4);
		GameObject instKub = Instantiate (Kubik);
		instKub.transform.SetParent (Kartinka.transform);
		var pos_x = Mathf.Round((Kartinka.transform.localScale.x * 10) / 2);
		var pos_y = Mathf.Round((Kartinka.transform.localScale.y * 10) / 2);
		Debug.Log (pos_x + " " + pos_y);
		instKub.transform.localPosition = new Vector2 (
			-pos_x,pos_y);
		GameObject instKub2 = Instantiate (Kubik);
		instKub2.transform.SetParent (Kartinka.transform);
		instKub2.transform.localPosition = new Vector2 (
			-pos_x+Kubik.transform.localScale.x,pos_y
			);
		GameObject instKub3 = Instantiate (Kubik);
		instKub3.transform.SetParent (Kartinka.transform);
		instKub3.transform.localPosition = new Vector2 (
			pos_x-Kubik.transform.localScale.x,pos_y
			);
		GameObject instKub4 = Instantiate (Kubik);
		instKub4.transform.SetParent (Kartinka.transform);
		instKub4.transform.localPosition = new Vector2 (
			pos_x,pos_y
			);

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
