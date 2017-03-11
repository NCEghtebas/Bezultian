using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour {

	public Tile(GameObject type,Vector3 pos){
	}

	public float getSize(){
		return gameObject.GetComponent<SpriteRenderer>().sprite.bounds.size.x;
	}
}
