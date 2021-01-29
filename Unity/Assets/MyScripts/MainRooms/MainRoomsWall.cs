using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainRoomsWall : MonoBehaviour
{
    // Start is called before the first frame update
    public MainRooms.MainRoomType roomType;

    public bool hit = false;
    public float hitTimeLimit = 2f;
    public float currHitTime = 0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other) {
    }

    void OnCollisionStay(Collision other) {
        if(hit)
        {
            currHitTime += Time.deltaTime;
            if(currHitTime >= hitTimeLimit)
            {
                MainRooms.Rotate();
                hit = false;
                currHitTime = 0f;
            }
        }

    }

    private void OnCollisionExit(Collision other) {
        currHitTime = 0f;
    }
}
