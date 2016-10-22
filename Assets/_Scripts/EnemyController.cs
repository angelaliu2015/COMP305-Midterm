///-----------------------------------------------------------------
///   Namespace:      COMP305-F2016-Midterm
///   Class:          EnemyController
///   Description:    This controls the enemy behavior 
///   Author:         Angela Liu                    Date: October 22,2016
///   Notes:          Enemy controller
///   Revision History: V1.0
///   Name: Angela          Date: Oct 22,2016        Description:
///-----------------------------------------------------------------
using UnityEngine;
using System.Collections;

[System.Serializable]
public class Speed
{
    public float minSpeed, maxSpeed;
}

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, yMin, yMax;
}


public class EnemyController : MonoBehaviour
{
    // PUBLIC INSTANCE VARIABLES
    public Speed speed;
    public Boundary boundary;

    // PRIVATE INSTANCE VARIABLES
    private float _CurrentSpeed;
    private float _CurrentDrift;


    // PUBLIC INSTANCE VARIABLES (TESTING ONLY)
    public GameController gameController;

    [Header("Sounds")]
    public AudioSource yaySound;

    // Use this for initialization
    void Start()
    {
        this._Reset();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 currentPosition = gameObject.GetComponent<Transform>().position;
        currentPosition.y -= this._CurrentSpeed;
        gameObject.GetComponent<Transform>().position = currentPosition;

        // Check bottom boundary
        if (currentPosition.y <= boundary.yMin)
        {
            this._Reset();
            this.yaySound.Play();
            this.gameController.ScoreValue += 10;

        }
    }



    // resets the gameObject
    private void _Reset()
    {
        this._CurrentSpeed = Random.Range(speed.minSpeed, speed.maxSpeed);
        Vector2 resetPosition = new Vector2(Random.Range(boundary.xMin, boundary.xMax), boundary.yMax);
        gameObject.GetComponent<Transform>().position = resetPosition;
    }
}
