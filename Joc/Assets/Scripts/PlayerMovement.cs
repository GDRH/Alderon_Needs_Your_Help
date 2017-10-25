using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    //Speeds
    public float speed = 15f;
    public float rotatespeed = 2.5f;
    //Mouse Positions/Angles
    float RollVal;
    float mouseX;
    float mouseY;
    float CameraY = 0f;
    float CameraX = 0f;
    //Transforms
    public Transform Player;
    public Transform Camera;
    public Transform target;
    //Vectors 3 / Quaternions variables;
    Vector3 TarLastPos;
    //Camera flipping
    public int CameraMod = 1;
    // Use this for initialization
    void Start() {
        //this Object
        Player = this.transform;
        //Find Main Camera
        Camera = GameObject.Find("Main Camera").transform;
        //Find "target"
        target = Camera.GetChild(0);
        //Initiate Last Position
        TarLastPos = target.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //Check if player flipped
        if (Vector3.Dot(Player.up, Vector3.down) > 0f)
        {
            //Upside Down
            CameraMod = -1;
        }
        else
        {
            //Right Side Up
            CameraMod = 1;
        }
        //Get RigidBody
        Rigidbody rb = Camera.GetComponent<Rigidbody>();
        //Move Ship F/B , L/R , Roll
        if (Input.GetButton("Horizontal"))
        {
            //Left Right 
            rb.AddForce(Camera.right * Input.GetAxis("Horizontal")*speed);
        }
        if (Input.GetButton("Vertical"))
        {
            //Forward Backwards
            rb.AddForce(Camera.forward * Input.GetAxis("Vertical")*speed);
        }
        if(Input.GetButton("Roll"))
        {
            //Roll
            RollVal = (rotatespeed * 1.125f) * Input.GetAxis("Roll");
            Camera.RotateAround(Camera.position,Camera.forward,RollVal);
        }
        //Ship(Camera) follows mouse
        //GetAxis Mouse X or Y  mean the diffrence  of pixels/ distance between where the mouse was and is now
        //CameraMod if the player is upside down
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");
        //If it didn't move it is the same
        CameraY = mouseX * rotatespeed;
        CameraX = mouseY * rotatespeed;
        //Set the new rotation
        Camera.RotateAround(Camera.position, Camera.up, CameraY);
        Camera.RotateAround(Camera.position, Camera.right, -CameraX);
        //Now smooth it
        if (targetChanged(target, TarLastPos))
        {
            StartCoroutine(LerpPlayer(0.5f));
        }
        //Set player's rotation to Camera's
        Player.rotation = Camera.rotation;
    }
    //FUNCTIONS
    bool targetChanged(Transform target, Vector3 lastPos)
    {
        if (
            //Target moved a tad
            Mathf.Abs(target.position.x - lastPos.x) > 0.01f ||
            Mathf.Abs(target.position.y - lastPos.y) > 0.01f ||
            Mathf.Abs(target.position.z - lastPos.z) > 0.01f
            )
        {
            return true;
        }
        else
            return false;
    }
    //Move player so it is in fron of camera
    IEnumerator LerpPlayer(float duration)
    {
        Vector3 StartingPos = Player.transform.position;
        float StartTime = Time.time;
        float t = 0f;
        while (t < 1)
        {
            t = (Time.time - StartTime) / duration;
            this.transform.position = Vector3.Lerp(StartingPos, target.position, t);
            yield return null;
        }
        this.transform.position = target.position;
    }
}
