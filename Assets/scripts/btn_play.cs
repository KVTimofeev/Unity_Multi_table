using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class btn_play : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnMouseDown()
	{

		Application.LoadLevel(1);
	}
}
