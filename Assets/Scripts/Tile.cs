using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tile : MonoBehaviour {

	private ITileType type;
	public IList<Unit> units= new List<Unit>();

	public void addUnit(Unit unit){
		units.Add(unit);
	}
	public void removeUnit(Unit unit){
		units.Remove (unit);
	}

	public void setType(ITileType newType){
		type = newType;
		onTypeChange ();
	}

	private void onTypeChange(){
		GetComponent<SpriteRenderer>().color=type.backgroundColor();
	}

	public float getSize(){
		return gameObject.GetComponent<SpriteRenderer>().sprite.bounds.size.x;
	}

	public bool allowsMovement(){
		return type.allowsMovement();
	}
}
