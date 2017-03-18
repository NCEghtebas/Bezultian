using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TimeMaster : MonoBehaviour {

	public float tickIntervalTime;
	private long ticks=0;

	List<ITickable> subscribed=new List<ITickable>(); //will call the discreteUpdate function of all objects in this list on every tick.

	private IEnumerator tick(){
		while (true) {
			yield return new WaitForSeconds(tickIntervalTime);
			Debug.Log ("Tick " + ticks);
			ticks += 1;
			evalSubscribed ();
		}
	}

	public void subscribe(ITickable subscriber){
		subscribed.Add (subscriber);
	}

	public void unsubscribe(ITickable subscriber){
		subscribed.Remove (subscriber);
	}

	private void evalSubscribed(){
		for (int i = 0; i < subscribed.Count; i += 1) {
			ITickable subscriber = subscribed [i];
			subscriber.discreteUpdate ();
		}
	}

	// Use this for initialization
	void Start () {
		StartCoroutine (tick ());
	}
}
