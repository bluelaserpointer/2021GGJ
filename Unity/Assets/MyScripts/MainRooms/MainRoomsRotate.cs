using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainRoomsRotate : MonoBehaviour
{
    // Start is called before the first frame update

    public enum MainRoomType{
        WARM,
        HEALTHY,
        SAD,
        DESPERATE,
        HAPPY,
        LONELY

    }

    public MainRoomType currRoomType = MainRoomType.WARM;

    public float pushWallTimeLimit = 2f;

    public float currPushWallTime = 0f;

    public Transform rooms;
    public float pushOffset = 5f;


    void Start()
    {
        
    }

    // private void FixedUpdate() {
    //     Vector3 currentAngle = new Vector3 (
    //     Mathf.LerpAngle(transform.rotation.eulerAngles.x, currentRotation.eulerAngles.x, rotationSpeed),
    //     Mathf.LerpAngle(transform.rotation.eulerAngles.y, currentRotation.eulerAngles.y, rotationSpeed),
    //     Mathf.LerpAngle(transform.rotation.eulerAngles.z, currentRotation.eulerAngles.z, rotationSpeed));
    //     transform.eulerAngles = currentAngle;    
    // }

    // Update is called once per frame
    void Update()
    {


        Rotate();
    }



    private void HandleCollision()
    {

        if(Input.GetKeyDown(KeyCode.W))
            HandlePushWall();
    }

    private void OnCollisionEnter(Collision other) {
        Debug.Log("OnCollisionEnter");
    }

    void OnCollisionStay(Collision other) {
        Debug.Log("Collided");
        if(other.gameObject.name == "PlayerVer1")
        {
            Debug.Log("Colliding!");
        }
    }

    private void HandlePushWall()
    {
        float currDir = transform.rotation.y;

        if(-90 - pushOffset <= currDir && currDir <= -90 + pushOffset)
        {

        }else if(90 - pushOffset <= currDir && currDir <= 90 + pushOffset)
        {

        }else if(-180 - pushOffset <= currDir && currDir <= -180 + pushOffset)
        {

        }else{

        }
    }

    void Rotate()
    {
        int degrees = 0;
        Vector3 direction = Vector3.right;

        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            direction = Vector3.right;
            degrees = 90;
        }

        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            direction = Vector3.left;
            degrees = 90;
        }

        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            direction = Vector3.back;
            degrees = 90;
        }

        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            direction = Vector3.forward;
            degrees = 90;
        }

        transform.Rotate(direction, degrees, Space.World);
    }

}
