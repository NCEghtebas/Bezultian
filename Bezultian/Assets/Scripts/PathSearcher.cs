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


	// public Queue<Pair<int, int>> findPathHelper(int x, int y, int currentx, int currenty){
	// 	List<Pair<int, int>> children = new List<Pair<int, int>>();



	// }

	public string listToString(List<Pair<int, int>> adjacents){
		string result = "";
		foreach(Pair<int, int> i in adjacents){
			result+= i.ToString();
		}
		return result;
	}

	//input x,y as board coordinates
	//output a queue of x,y board coordinates that lead 
	//from the current board position of unit to the given x,y coordinate
	public Queue<Pair<int,int>> findPath(int x,int y, int currentx, int currenty){

		// take first node and get children
		// put children in list 
		// take node and get children
		// end condition : loose if children is empty or win if current node is goal node (x,y)
		//A* or BFS goes here
		List<Pair<int, int>> adjacent = map.findAdjacentTile(currentx, currenty);

		Debug.Log(listToString(adjacent));
		// test this on different positions, 
		// if I ask what is adjacent, we dont want the black cubes. 
		// make toAdjacent aware what is not adjacent.

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
