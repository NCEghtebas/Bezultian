using UnityEngine;
using System.Collections;

public class Map : MonoBehaviour {

	public int x ;
	public int y ;
	public GameObject defaultObj;

	// Use this for initialization
	void Start () {
		Tile[,] tiles= new Tile[x,y];
		for (int x = 0; x < tiles.GetLength(0); x += 1) {
			for (int y = 0; y < tiles.GetLength(1); y += 1) {
				tiles [x, y] = new Tile (defaultObj, new Vector3 (x, y, 0));
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
