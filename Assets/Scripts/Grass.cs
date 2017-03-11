using UnityEngine;
using System.Collections;

public class Grass : ITileType {
	public bool allowsMovement(){
		return true;
	}
	public Color backgroundColor(){
		return Color.green;
	}
}
