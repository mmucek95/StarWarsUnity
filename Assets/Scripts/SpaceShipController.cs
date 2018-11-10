using UnityEngine;
using System.Collections;

public class SpaceShipController : MonoBehaviour {

    public MissleController missle;
    private float axisX = 0f, axisY = 0f;
    public float maxForce = 0f;
    public ParticleSystem upperLeft, upperRight, upperMiddleLeft, upperMiddleRight,
        downMiddleLeft, downMiddleRight, downLeft, downRight;

    
	// Use this for initialization
	void Start () {
        upperLeft.enableEmission = false;
        upperRight.enableEmission = false;
        upperMiddleLeft.enableEmission = false;
        upperMiddleRight.enableEmission = false;
        downMiddleLeft.enableEmission = false;
        downMiddleRight.enableEmission = false;
        downLeft.enableEmission = false;
        downRight.enableEmission = false;
    }
	
	// Update is called once per frame
	void Update () {
        axisX = Input.GetAxisRaw("Horizontal") * Time.deltaTime;
        axisY = Input.GetAxisRaw("Vertical") * Time.deltaTime;

        if(axisX == 0 || axisY == 0)
        {
            this.GetComponent<Rigidbody>().AddForce(new Vector3(axisX, axisY, 0) * maxForce);
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            upperMiddleRight.enableEmission = true;
            downMiddleRight.enableEmission = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            upperMiddleRight.enableEmission = false;
            downMiddleRight.enableEmission = false;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            upperMiddleLeft.enableEmission = true;
            downMiddleLeft.enableEmission = true;
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            upperMiddleLeft.enableEmission = false;
            downMiddleLeft.enableEmission = false;
        }


        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            downLeft.enableEmission = true;
            downRight.enableEmission = true;
        }
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            downLeft.enableEmission = false;
            downRight.enableEmission = false;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            upperLeft.enableEmission = true;
            upperRight.enableEmission = true;
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            upperLeft.enableEmission = false;
            upperRight.enableEmission = false;
        }

        if(Input.GetKeyDown(KeyCode.T))
        {
            Instantiate(missle, this.transform.position + new Vector3(0,50, 0), Quaternion.Euler(0, 0, 0));
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            Instantiate(missle, this.transform.position + new Vector3(0, -50, 0), Quaternion.Euler(180, 90, 0));
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            Instantiate(missle, this.transform.position + new Vector3(50, 0, 0), Quaternion.Euler(90, 90, 0));
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            Instantiate(missle, this.transform.position + new Vector3(-50, 0, 0), Quaternion.Euler(270, 90, 0));
        }
    }
}
