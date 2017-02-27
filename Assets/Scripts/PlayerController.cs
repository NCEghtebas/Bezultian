using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {


	public float speed = 6.0F;
	private Vector3 moveDirection = Vector3.zero;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update() {
		CharacterController controller = GetComponent<CharacterController>();
		Vector3 forMov = this.transform.forward * speed * Input.GetAxis ("Vertical") * Time.deltaTime;
		Vector3 sideMov = this.transform.right * speed * Input.GetAxis ("Horizontal") * Time.deltaTime;
		Vector3 forMovClamp = new Vector3 (forMov.x,0f , forMov.z);
		Vector3 sideMovClamp = new Vector3 (sideMov.x,0f ,sideMov.z);
		controller.Move (forMovClamp);
		controller.Move (sideMovClamp);
	}
}
