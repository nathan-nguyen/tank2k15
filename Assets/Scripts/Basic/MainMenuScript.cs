using UnityEngine;
using System.Collections;

public class MainMenuScript : MonoBehaviour {

	public Canvas canvas;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnClickExitButton(){
		Application.Quit ();
	}

	public void OnClickNewGameButton(){
		canvas.enabled = false;
		Application.LoadLevel ("Main Game");
	}
}
