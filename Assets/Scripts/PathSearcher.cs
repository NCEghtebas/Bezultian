using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PathSearcher {
	Map map;
	Unit unit;

	public PathSearcher(Map map,Unit unit){
		this.map = map;
		this.unit = unit;
	}

	//input x,y as board coordinates
	//output a queue of x,y board coordinates that lead 
	//from the current board position of unit to the given x,y coordinate
	public Queue<Pair<int,int>> findPath(int x,int y){
		//A* or BFS goes here
		Queue<Pair<int,int>> path = new Queue<Pair<int,int>> ();
		path.Enqueue (new Pair<int,int> (0, 1));
		path.Enqueue (new Pair<int,int> (0, 2));
		path.Enqueue (new Pair<int,int> (0, 3));
		path.Enqueue (new Pair<int,int> (1, 3));
		path.Enqueue (new Pair<int,int> (2, 3));
		path.Enqueue (new Pair<int,int> (2, 4));
		return path;
	}
}
