using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent (typeof (Unit))]
public class Movement : MonoBehaviour, ITickable {

	bool toMove=false;
	public Queue<Pair<int,int>> path;
	Unit unit;
	Map map;
			
	public void addPath(Queue<Pair<int,int>> path){
		this.path = path;
	}
	public bool hasPath(){
		return (path != null && path.Count > 0);
	}

	/*public string pathToString(){
		string str = "[";
		foreach (Pair<int,int> pair in path) {
			str += pair.ToString ();
		}
		str+=
	}*/

	// Use this for initialization
	void Start () {
		unit=gameObject.GetComponent<Unit> ();
		map = GameObject.FindObjectOfType<Map> ();
		connectToClock ();
	}

	// Update is called once per frame
	void Update () {
		//Move one square along the path chosen.
		if (toMove && path!=null && path.Count>0) {
			Pair<int,int> newSquare=path.Dequeue ();
			map.moveUnit (unit, newSquare.First, newSquare.Second);
			toMove = false;
		}
	}

	public void connectToClock(){
		TimeMaster timeMaster=GameObject.FindObjectOfType<TimeMaster> ();
		timeMaster.subscribe (this);
	}

	public void discreteUpdate(){
		toMove = true;
	}
}
