using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    //Speeds
    public float speed = 15f;
    public float rotatespeed = 2.5f;
    //Mouse Positions/Angles
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
        //Distance between camera and  player
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
        //Move Ship
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
        //Ship(Camera) follows mouse
        //GetAxis Mouse X or Y  mean the diffrence  of pixels/ distance between where the mouse was and is now
        //CameraMod if the player is upside down
        mouseX = Input.GetAxis("Mouse X")*CameraMod;
        mouseY = Input.GetAxis("Mouse Y");
        //If it didn't move it is the same
        CameraY += mouseX * rotatespeed;
        CameraX -= mouseY * rotatespeed;
        //LOcal or not, doesn't really matter
        //Set the new rotation
        Camera.localRotation = Quaternion.Euler(CameraX, CameraY, 0f);
        //Now smooth it
        if (targetChanged(target, TarLastPos))
        {
            StartCoroutine(LerpPlayer(0.5f));
        }
        Player.rotation = Camera.rotation;
        //
        //Player.position = Camera.position - CamOffset;
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
    /*IEnumerator FlipCamera(Transform Camera)
    {
        fliping = true;
        yield return new WaitForSeconds(0.1f);
        if (
            /*((Camera.degreeAngles().x >= 0 && Camera.degreeAngles().x <= 20) && (LastRot <= 360 && LastRot >=340)) || //Camera came from 360 towards 0
            ((Camera.degreeAngles().x <= 360 && Camera.degreeAngles().x >= 340) && (LastRot >= 0 && LastRot <= 20))  || //Camera came from 0 towards 360
            (Camera.degreeAngles().x > 180 && LastRot <= 180)  || //Camera came from under 180 towards 180
            (Camera.degreeAngles().x < 180 && LastRot >= 180)  //Camera came from over 180 towards 180
            ((Camera.degreeAngles().x >= 90 && LastRot < 90) && !((Camera.degreeAngles().x <= 20 && LastRot >= 340) || (Camera.degreeAngles().x >= 340 && LastRot <= 20))) ||
            ((Camera.degreeAngles().x < 90 && LastRot >= 90) && !((Camera.degreeAngles().x <= 20 && LastRot >= 340) || (Camera.degreeAngles().x >= 340 && LastRot <= 20))) ||
            ((Camera.degreeAngles().x >= 270 && LastRot < 270) && !((Camera.degreeAngles().x <= 20 && LastRot >= 340) || (Camera.degreeAngles().x >= 340 && LastRot <= 20))) ||
            ((Camera.degreeAngles().x < 270 && LastRot >= 270) && !((Camera.degreeAngles().x <= 20 && LastRot >= 340) || (Camera.degreeAngles().x >= 340 && LastRot <= 20)))
            
            Vector3.Dot(Player.up, Vector3.down) > 0f
          )
        {
            Debug.LogWarning("FLIPPED");
            if (CameraMod > 0)
            {
                CameraMod = -1;
            }
            else
            {
                CameraMod = 1;
            }
        }
        fliping = false;
        yield return null;
    }*/
    IEnumerator LerpPlayer(float duration)
    {
        Vector3 StartingPos = Player.transform.position;
        // Quaternion StartingOr = Player.transform.rotation;
        float StartTime = Time.time;
        float t = 0f;
        while (t < 1)
        {
            t = (Time.time - StartTime) / duration;
            this.transform.position = Vector3.Lerp(StartingPos, target.position, t);
            //this.transform.rotation = Quaternion.Lerp(StartingOr, Camera.rotation, t*3);
            yield return null;
        }
        this.transform.position = target.position;
        //this.transform.rotation = Camera.rotation;
    }
}
