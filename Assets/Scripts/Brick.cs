using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {
	public Sprite[] hitSprites;
	public static int brickCount = 0;
	public AudioClip crack;
	public GameObject smoke;

	private int maxHit;
	private int timesHit;
	private LevelManager levelManager;
	private bool isBreakable;
	// Use this for initialization
	void Start () {
		isBreakable = this.tag == "Breakable";
		if (isBreakable) {
			brickCount++;
		}
		timesHit = 0;
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter2D(Collision2D col){
		AudioSource.PlayClipAtPoint (crack, transform.position);
		if(isBreakable){
			timesHit++;
			int maxHit = hitSprites.Length + 1;
			if (timesHit >= maxHit) {
				brickCount--;
				levelManager.AllDestoryed();
				GameObject smokePuff = Instantiate(smoke, transform.position, Quaternion.identity) as GameObject;
				smokePuff.GetComponent<ParticleSystem>().startColor = gameObject.GetComponent<SpriteRenderer>().color;
				Destroy (gameObject);
			} else {
				this.GetComponent<SpriteRenderer>().sprite = hitSprites[timesHit - 1];
			}
		}
	}
}
