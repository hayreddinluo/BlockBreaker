using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public void LoadLevel(string name){
		Debug.Log ("Start pressed with" + name);
		Brick.brickCount = 0;
		Application.LoadLevel (name);
	}

	public void QuitRequest(){
		Debug.Log ("Quit");
	}	

	public void LoadNextLevel(){
		Brick.brickCount = 0;
		Application.LoadLevel (Application.loadedLevel + 1);
	}

	public void AllDestoryed(){
		if (Brick.brickCount <= 0) {
			LoadNextLevel();
		}
	}
}
