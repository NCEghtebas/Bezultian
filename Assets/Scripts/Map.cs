using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Map : MonoBehaviour {

	private GameObject[,] tiles= new GameObject[5,5];
	public GameObject defaultObj;
	float SPACING=1;

	public Map (){
	}

	public void Start(){
		defaultObj= (GameObject)Resources.Load("Prefabs/DefaultObj");
		createMap ();
		drawGrid ();
	}

	public void createMap(){
		for (int x = 0; x < tiles.GetLength(0); x += 1) {
			for (int y = 0; y < tiles.GetLength(1); y += 1) {
				//The spacing allows us to auto-pack the sprites together
				tiles [x, y]=(GameObject)GameObject.Instantiate (defaultObj, new Vector3 (x*SPACING, y*SPACING, 0),Quaternion.identity);
				tiles [x, y].gameObject.AddComponent<Tile>();
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
			LineRenderer line = createLine (fromPos, toPos,index);
		}
		for (int y = 0; y < tiles.GetLength (1) + 1; y += 1) {
			float xPos = tiles.GetLength (0) * SPACING-SPACING/2;
			float yPos = y * SPACING - SPACING/2;
			Vector3 fromPos = new Vector3 (-SPACING/2, yPos, 0);
			Vector3 toPos = new Vector3 (xPos,yPos, 0);
			LineRenderer line = createLine (fromPos, toPos,index);
		}
	}
}
