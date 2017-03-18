using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//This class needs refactoring real bad. Lets ignore it until its a real problem :)
public class Map : MonoBehaviour {

	private GameObject[,] tiles;
	private ITileType[,] tileTypes;
	public GameObject defaultObj;
	public GameObject defaultUnit;
	float SPACING=1;

	public Map (){
	}

	public void Update(){
		if (Input.GetKeyDown (KeyCode.R)) {
			printMap ();
		}
		if (Input.GetKeyDown (KeyCode.T)) {
			Movement mov = ((Movement)FindObjectOfType (typeof(Movement)));
			if (!mov.hasPath()) {
				Queue<Pair<int,int>> path = new Queue<Pair<int,int>> ();
				path.Enqueue (new Pair<int,int> (0, 1));
				path.Enqueue (new Pair<int,int> (0, 2));
				path.Enqueue (new Pair<int,int> (0, 3));
				path.Enqueue (new Pair<int,int> (1, 3));
				path.Enqueue (new Pair<int,int> (2, 3));
				path.Enqueue (new Pair<int,int> (2, 4));
				mov.addPath (path);
			}
		}
	}

	public void Start(){
		defaultObj= (GameObject)Resources.Load("Prefabs/DefaultTile");
		defaultUnit = (GameObject)Resources.Load ("Prefabs/DefaultUnit");
		designMap();
		createMap ();
		drawGrid ();
		addUnits ();
	}
		
	public void addUnits(){
		addUnit (0, 0);
	}

	private void addUnit(int x, int y){
		GameObject go=(GameObject)GameObject.Instantiate (defaultUnit, new Vector3 (x*SPACING, y*SPACING, 0),Quaternion.identity);
		tiles [x, y].GetComponent<Tile> ().addUnit (go.GetComponent<Unit>());
		go.GetComponent<Unit> ().setGround (tiles [x, y].GetComponent<Tile> ());
	}

	public void moveUnit(Unit unit, int newX,int newY){
		unit.gameObject.transform.position = new Vector3 (newX * SPACING, newY * SPACING, 0);
		unit.getGround ().removeUnit(unit);
		unit.setGround (tiles [newX, newY].GetComponent<Tile> ());
		tiles [newX, newY].GetComponent<Tile> ().addUnit (unit);
	}

	public void printMap(){
		for(int x=0; x< tiles.GetLength(0); x += 1) {
			for (int y = 0; y < tiles.GetLength(1); y += 1) {
				Debug.Log("("+x+","+y+"):"+tiles[x,y].GetComponent<Tile>().units.Count);
			}
		}
	}

	public static E[,] FlippidyFlop<E>(E[,] matrix){
		E[,] toReturn =new E[matrix.GetLength(1),matrix.GetLength(0)];
		for (int y = 0; y < matrix.GetLength (1); y += 1) {
			for (int x = 0; x < matrix.GetLength(0); x += 1) {
				toReturn [y, matrix.GetLength(0)-x-1] = matrix [x, y];
			}
		}
		return toReturn;
	}

	public void designMap(){
		ITileType v = new Grass ();
		ITileType X = new Wall (); 
		tileTypes = new ITileType[,] 
		   {{ v, v, v, v, v },
			{ v, v, v, v, v },
			{ v, v, X, v, v },
			{ v, v, v, v, v },
			{ X, v, v, X, v },
			{ v, v, v, v, v }
		};
		//This makes the above image 1:1 with what comes out in unity
		tileTypes = FlippidyFlop<ITileType> (tileTypes);
	}

	public void createMap(){
		tiles = new GameObject[tileTypes.GetLength (0), tileTypes.GetLength (1)];
		for (int x = 0; x < tiles.GetLength(0); x += 1) {
			for (int y = 0; y < tiles.GetLength(1); y += 1) {
				//The spacing allows us to auto-pack the sprites together
				GameObject go=(GameObject)GameObject.Instantiate (defaultObj, new Vector3 (x*SPACING, y*SPACING, 0),Quaternion.identity);
				go.gameObject.AddComponent<Tile>();
				go.GetComponent<Tile> ().setType (tileTypes [x, y]);
				go.name="["+x+","+y+"]";
				tiles [x, y] = go;
				if (SPACING == 1) {
					SPACING = tiles [0, 0].GetComponent<Tile>().getSize ();
				}
			}
		}
	}
	public LineRenderer createLine(Vector3 fromPos,Vector2 toPos,int index){
		GameObject child = new GameObject ();
		child.name = "Renderer " + index.ToString ();
		child.transform.SetParent (transform);

		LineRenderer line = child.AddComponent<LineRenderer> ();
		line.material=new Material(Shader.Find("Sprites/Default"));
		line.material.color = Color.black;	
		line.sortingOrder = 1;
		line.SetWidth (0.02F, 0.02F);
		line.SetVertexCount (2);
		line.SetPosition (0, fromPos);
		line.SetPosition (1, toPos);
		return line;
	}

	public void drawGrid(){
		int index = 0;
		for (int x = 0; x < tiles.GetLength (0) + 1; x += 1) {
			float xPos = x * SPACING-SPACING/2;
			float yPos = tiles.GetLength (1) * SPACING-SPACING/2;
			Vector3 fromPos = new Vector3 (xPos, -SPACING/2, 0);
			Vector3 toPos = new Vector3 (xPos,yPos , 0);
			createLine (fromPos, toPos,index);
		}
		for (int y = 0; y < tiles.GetLength (1) + 1; y += 1) {
			float xPos = tiles.GetLength (0) * SPACING-SPACING/2;
			float yPos = y * SPACING - SPACING/2;
			Vector3 fromPos = new Vector3 (-SPACING/2, yPos, 0);
			Vector3 toPos = new Vector3 (xPos,yPos, 0);
			createLine (fromPos, toPos,index);
		}
	}
}
