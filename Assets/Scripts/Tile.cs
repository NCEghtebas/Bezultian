using UnityEngine;
using System.Collections;

public class Tile{

	GameObject container;

	public Tile(GameObject type,Vector3 pos){
		this.container=(GameObject)GameObject.Instantiate (type, pos,Quaternion.identity);
	}
}
