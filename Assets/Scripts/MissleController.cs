using UnityEngine;
using System.Collections;

public class MissleController : MonoBehaviour {

    public float missleSpeed = 1.0f, missleAcceleration = 1.0f;
    public RaycastHit hit;
    bool left;
    public ParticleSystem explosion;

    // Use this for initialization
    void Start () {
        StartCoroutine(AutoDestruct(10));
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.Translate(this.transform.up * missleSpeed * Time.deltaTime, Space.World);
        missleSpeed += missleAcceleration * Time.deltaTime;
        Debug.DrawRay(this.gameObject.transform.position, Vector3.up);

        if(Physics.Raycast(this.gameObject.transform.position + new Vector3(-15, 0, 0), this.gameObject.transform.up, out hit, 1.0f))
        {
            Explosion();
        }
	}

    void Explosion()
    {
        Instantiate(explosion, this.transform.position, Quaternion.Euler(90, 90, 0));
        Destroy(this.gameObject);
    }

    public IEnumerator AutoDestruct(int time)
    {
        yield return new WaitForSeconds(time);
    }
}
