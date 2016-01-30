using UnityEngine;
using System.Collections;

public class Lose : MonoBehaviour {
	private LevelManager levelManager;

	void Start () {
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
	}

	void OnTriggerEnter2D(Collider2D trigger){
		levelManager.LoadLevel ("Lose");
	}
}
