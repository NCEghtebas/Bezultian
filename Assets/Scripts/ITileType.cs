using UnityEngine;
using System.Collections;

public interface ITileType {
	bool allowsMovement();
	Color backgroundColor ();
}
