using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpeceShipController : MonoBehaviour {
    static float horizontalDim = 30.0f;
    static float verticalDim = 15.0f;
    public ParticleSystem upperLeft, upperRight, upperMiddleLeft, upperMiddleRight,
    downMiddleLeft, downMiddleRight, downLeft, downRight;
    public float maxForce = 2f;
    public float maxSpeed = 0.5f;
    Vector2 destination = new Vector2(horizontalDim, verticalDim);
    bool moveHorizontaly = true;

    private Vector2 speed = new Vector2(0, 0);
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        StopEngines();
        MoveToDestination();
	}

    void StopEngines()
    {
        upperLeft.enableEmission = false;
        upperRight.enableEmission = false;
        upperMiddleLeft.enableEmission = false;
        upperMiddleRight.enableEmission = false;
        downMiddleLeft.enableEmission = false;
        downMiddleRight.enableEmission = false;
        downLeft.enableEmission = false;
        downRight.enableEmission = false;
    }

    void MoveLeft()
    {
        if (speed[0] > -maxSpeed)
        {
            upperMiddleRight.enableEmission = true;
            downMiddleRight.enableEmission = true;
            speed[0] -= Time.deltaTime;
            this.GetComponent<Rigidbody>().AddForce(new Vector3(speed[0] * maxForce * Time.deltaTime, 0f, 0f));
        }
        else
        {
            speed[0] += Time.deltaTime;
            this.GetComponent<Rigidbody>().AddForce(new Vector3(speed[0] * maxForce * Time.deltaTime, 0f, 0f));
        }
    }

    void MoveRight()
    {
        if (speed[0] < maxSpeed)
        {
            upperMiddleLeft.enableEmission = true;
            downMiddleLeft.enableEmission = true;
            speed[0] += Time.deltaTime;
            this.GetComponent<Rigidbody>().AddForce(new Vector3(speed[0] * maxForce * Time.deltaTime, 0f, 0f));
        }
        else
        {
            speed[0] -= Time.deltaTime;
            this.GetComponent<Rigidbody>().AddForce(new Vector3(speed[0] * maxForce * Time.deltaTime, 0f, 0f));
        }
    }

    void MoveUp()
    {
        if (speed[1] < maxSpeed)
        {
            upperMiddleLeft.enableEmission = true;
            downMiddleLeft.enableEmission = true;
            speed[1] += Time.deltaTime;
            this.GetComponent<Rigidbody>().AddForce(new Vector3(0f, speed[1] * maxForce * Time.deltaTime, 0f));
        }
        else
        {
            speed[1] -= Time.deltaTime;
            this.GetComponent<Rigidbody>().AddForce(new Vector3(0f, speed[1] * maxForce * Time.deltaTime, 0f));
        }
    }

    void MoveDown()
    {
        if (speed[1] > -maxSpeed)
        {
            upperMiddleRight.enableEmission = true;
            downMiddleRight.enableEmission = true;
            speed[1] -= Time.deltaTime;
            this.GetComponent<Rigidbody>().AddForce(new Vector3(0f, speed[1] * maxForce * Time.deltaTime, 0f));
        }
        else
        {
            speed[1] += Time.deltaTime;
            this.GetComponent<Rigidbody>().AddForce(new Vector3(0f, speed[1] * maxForce * Time.deltaTime, 0f));

        }
    }

    void randomDirection()
    {
        int random = Random.Range(0, 1);
        //if(random != 1)
        {
            moveHorizontaly = !moveHorizontaly;
        }
    }

    void MoveToDestination()
    {
        double distance;
        if (moveHorizontaly)
            distance = Mathf.Abs(destination[0] - this.transform.position.x);
        else
            distance = Mathf.Abs(destination[1] - this.transform.position.y);
        if (distance < 30)
        {
            speed[0] = -speed[0] * maxForce * Time.deltaTime;
            speed[1] = -speed[1] * maxForce * Time.deltaTime;
             randomDirection();

            if (moveHorizontaly)
                destination[0] = -destination[0];
            else
                destination[1] = -destination[1];
        }
        if (destination[0] < 0 && moveHorizontaly)
        {
            MoveLeft();
        }
        else if (destination[0] > 0 && moveHorizontaly)
        {
            MoveRight();
        }
        else if (destination[1] > 0 && !moveHorizontaly)
        {
            MoveUp();
        }
        else if(destination[1] < 0 && !moveHorizontaly)
        {
            MoveDown();
        }
    }
}
