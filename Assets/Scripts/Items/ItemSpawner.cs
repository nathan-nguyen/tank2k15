using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemSpawner : MonoBehaviour {

	private string item;

	private List<GameObject> spawnerList = new List<GameObject>();

	// Use this for initialization
	void Start () {
	
	}

	public void SetSpawnerList(List<GameObject> spawnerList) {
		this.spawnerList = spawnerList;
	}

	// Update is called once per frame
	void Update () {
	
	}

	public void Respawn(Vector3 position){
		this.transform.position = position;
	}

	public void SetItem(string item){
		this.item = item;
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "ai") {
			col.GetComponent<AI>().AddItem(item);
			spawnerList.Remove (this.gameObject);
			Destroy (this.gameObject);
		}
	}

}
