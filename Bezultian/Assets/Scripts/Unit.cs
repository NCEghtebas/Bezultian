using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour {

	public Tile ground;

	public void setGround(Tile ground){
		this.ground=ground;
	}
	public Tile getGround(){
		return ground;
	}
}
