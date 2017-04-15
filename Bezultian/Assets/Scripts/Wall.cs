using UnityEngine;
using System.Collections;

public class Wall : ITileType {
	public bool allowsMovement(){
		return false;
	}
	public Color backgroundColor(){
		return Color.black;
	}
}
