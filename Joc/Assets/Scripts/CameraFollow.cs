using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    Vector3 offset;
    Vector3 TOffset;
    Transform Target;	
    // Use this for initialization
	void Start () {
        //Target = this.transform.GetChild(0).transform;
        offset = this.transform.position - GameObject.Find("Player").transform.position;
        //TOffset = this.transform.position - Target.position;
	}
	
	// Update is called once per frame
	void Update () {
        offset = this.transform.position - GameObject.Find("Player").transform.position;
        transform.position = offset + GameObject.Find("Player").transform.position;
        //Target.position = offset - transform.position;
    }
}
