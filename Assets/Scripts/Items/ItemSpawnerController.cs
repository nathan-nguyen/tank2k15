using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemSpawnerController : MonoBehaviour {
	private const int MAX_ITEM_RESPAWN_MAP = 10;
	private const int MAX_ITEM_RESPAWN_LOCATION = 20;

	private Vector3[] spawnLocation = new Vector3[MAX_ITEM_RESPAWN_LOCATION];
	private List<Vector3> occupiedLocation = new List<Vector3>();

	private const int PREFAB_NUMBER = 5;

	public GameObject[] prefabs = new GameObject[PREFAB_NUMBER];
	private List<GameObject> spawner = new List<GameObject>();


	// Use this for initialization
	void Start () {
		spawnLocation [0] = new Vector3(-4, -1, 0);
		spawnLocation [1] = new Vector3 (-3.7f, -31.5f, 0);
		spawnLocation [2] = new Vector3(-32.5f, -12.5f, 0);
		spawnLocation [3] = new Vector3 (-19, -24, 0);
		spawnLocation [4] = new Vector3(9.1f, 3.7f, 0);
		spawnLocation [5] = new Vector3 (21, -10, 0);
		spawnLocation [6] = new Vector3(-4.7f, 15.1f, 0);
		spawnLocation [7] = new Vector3(-27.5f, 34, 0);
		spawnLocation [8] = new Vector3(5.8f, 27.6f, 0);
		spawnLocation [9] = new Vector3(23.4f, 31.8f, 0);
		spawnLocation [10] = new Vector3(-25f, -28f, 0);
		spawnLocation [11] = new Vector3 (-10f, 30.5f, 0);
		spawnLocation [12] = new Vector3(1f, 34.42f, 0);
		spawnLocation [13] = new Vector3(9f, 32.4f, 0);
		spawnLocation [14] = new Vector3(0.8f, 8.5f, 0);
		spawnLocation [15] = new Vector3(10.6f, -25.2f, 0);
		spawnLocation [16] = new Vector3(10.3f, -9.5f, 0);
		spawnLocation [17] = new Vector3(32.21f, -7.17f, 0);
		spawnLocation [18] = new Vector3(22.2f, 1.5f, 0);
		spawnLocation [19] = new Vector3(26f, -24f, 0);


	}
	
	// Update is called once per frame
	void Update () {
		if (spawner.Count < MAX_ITEM_RESPAWN_MAP) {
			ResetOccupiedStatus ();
			SpawnItemSpawner ();
		}
	}

	private void SpawnItemSpawner(){
		int randomLocation;

		while (spawner.Count < MAX_ITEM_RESPAWN_MAP) {

			randomLocation = Random.Range (0, MAX_ITEM_RESPAWN_LOCATION);
			if (occupiedLocation.Contains(spawnLocation[randomLocation]))
				continue;

			occupiedLocation.Add (spawnLocation[randomLocation]);
			GameObject g = Instantiate(prefabs[Random.Range(0,PREFAB_NUMBER)], spawnLocation[randomLocation], Quaternion.identity) as GameObject;
			g.GetComponent<ItemSpawner>().SetSpawnerList(spawner);
			spawner.Add(g);
		}


	}

	private void ResetOccupiedStatus(){
		occupiedLocation.RemoveRange (0, occupiedLocation.Count);

		for (int i = 0; i < spawner.Count; i++) {
			occupiedLocation.Add(spawner[i].transform.position);
		}
	}
}
