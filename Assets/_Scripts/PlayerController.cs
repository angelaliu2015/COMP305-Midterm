///-----------------------------------------------------------------
///   Namespace:      COMP305-F2016-Midterm
///   Class:          PlayerController
///   Description:    This controls the player behavior 
///   Author:         Angela Liu                    Date: October 22,2016
///   Notes:          Player controller
///   Revision History: V1.0
///   Name: Angela          Date: Oct 22,2016        Description:
///-----------------------------------------------------------------
using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	// PUBLIC INSTANCE VARIABLES +++++++++++++++++++++++++++++++++++++++
	public float speed;
	public Boundary boundary;

    // PUBLIC INSTANCE VARIABLES (TESTING ONLY)
    public GameController gameController;

    [Header("Sounds")]
    public AudioSource thunderSound;
    public AudioSource yaySound;


    // get a reference to the camera to make mouse input work
    public Camera camera; 
	
	// PRIVATE INSTANCE VARIABLES
	private Vector2 _newPosition = new Vector2(0.0f, 0.0f);
	
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		this._CheckInput ();

	}

	private void _CheckInput() {
		this._newPosition = gameObject.GetComponent<Transform> ().position; // current position

		//movement by keyboard
		if (Input.GetAxis ("Horizontal") > 0) {
			this._newPosition.x += this.speed; // add move value to current position
		}
	
		
		if (Input.GetAxis ("Horizontal") < 0) {
			this._newPosition.x -= this.speed; // subtract move value to current position
		}
		

		// movement by mouse
		Vector2 mousePosition = Input.mousePosition;
		this._newPosition.x = this.camera.ScreenToWorldPoint (mousePosition).x;

		this._BoundaryCheck ();

		gameObject.GetComponent<Transform>().position = this._newPosition;
	}

	private void _BoundaryCheck() {
		if (this._newPosition.x < this.boundary.xMin) {
			this._newPosition.x = this.boundary.xMin;
		}

		if (this._newPosition.x > this.boundary.xMax) {
			this._newPosition.x = this.boundary.xMax;
		}
	}

     private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Enemy"))
        {
            this.thunderSound.Play();
            this.gameController.LivesValue -= 1;
        }

    }


}
