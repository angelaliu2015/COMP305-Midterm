///-----------------------------------------------------------------
///   Namespace:      COMP305-F2016-Midterm
///   Class:          RoadController
///   Description:    This controls the road behavior 
///   Author:         Angela Liu                    Date: October 22,2016
///   Notes:          Road controller
///   Revision History: V1.0
///   Name: Angela          Date: Oct 22,2016        Description:
///-----------------------------------------------------------------
using UnityEngine;
using System.Collections;

public class RoadController : MonoBehaviour {
	// PUBLIC INSTANCE VARIABLES
	public float speed=3f;

    // Use this for initialization
    void Start () {
		this._Reset ();
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 currentPosition = gameObject.GetComponent<Transform> ().position;
		currentPosition.y -= speed;
		gameObject.GetComponent<Transform> ().position = currentPosition;

		// Check bottom boundary
		if (currentPosition.y <= -480) {
			this._Reset();
		}
	}

	private void _Reset() {
		Vector2 resetPosition = new Vector2 (0.0f, 480f);
		gameObject.GetComponent<Transform> ().position = resetPosition;
	}
}
