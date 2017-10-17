using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZeroLib;

public class LaserMove : MonoBehaviour {
    public float LaserSpeed = 2f;
    public float FlareIntensety;
    LensFlare LaserFlare;
    // Use this for initialization
    void Start () {
        LaserFlare = this.GetComponent<LensFlare>();
        FlareIntensety = LaserFlare.brightness;
    }
	
	// Update is called once per frame
	void Update () {
        float lerpFac = Vector3.Distance(GameObject.Find("Player").transform.position, this.transform.position);
        this.transform.position += this.transform.forward * Time.deltaTime * LaserSpeed;
        FlareIntensety = Mathf.Lerp(0.5f, 0.0f, ZeroMaths.Map(lerpFac,0f,1000f,0f,1f));
        LaserFlare.brightness = FlareIntensety;
        if(lerpFac > 1100)
        {
            GameObject.Destroy(this.gameObject);
        }
	}
    private void OnCollisionEnter(Collision collision)
    {
        print("HIT");
        if(collision.gameObject.tag == "Player")
        {
            print("DED");
            GameObject.Destroy(this.gameObject);
        }
    }
    //float Map(float ValueMin,float ValueMax)
}
