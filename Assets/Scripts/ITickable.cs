using UnityEngine;
using System.Collections;

public interface ITickable {
	void discreteUpdate ();
	void connectToClock ();
}
