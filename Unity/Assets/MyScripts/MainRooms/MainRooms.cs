using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainRooms : MonoBehaviour
{
    // Start is called before the first frame update
    public static MainRooms instance;
    public enum MainRoomType{
        WARM,
        HEALTHY,
        SAD,
        DESPERATE,
        HAPPY,
        LONELY

    };

    public float rotateAngle = 90;

    void Start()
    {
    }

    private void Awake() {
        if (instance == null)
                instance = this;   
    }

    // Update is called once per frame
    void Update()
    {
    }


    public static void Rotate()
    {
        Vector3 direction = Vector3.right;

        float verticalValue = Input.GetAxis("Vertical");
        float horizontalValue = Input.GetAxis("Horizontal");

        if( Mathf.Abs(horizontalValue) < Mathf.Abs(verticalValue))
        {
            
            if(verticalValue < 0)
            {
                direction = Vector3.left;
            }else{
                direction = Vector3.right;
            }
        }else
        {
            if(horizontalValue < 0)
            {
                direction = Vector3.forward;
            }else{
                direction = Vector3.back;
            }
        }

        instance.transform.Rotate(direction, instance.rotateAngle, Space.World);
    }

}
