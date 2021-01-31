using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PrisonCamera : MonoBehaviour
{
    public GameObject[] detections;
    private GameObject player;
    private CinemachineFreeLook currFreeLook;
    private Camera mainCam;
    // Start is called before the first frame update
    void Start()
    {
        mainCam = Camera.main;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        else
        {
            Vector3 trans = player.transform.position;
            float zCoord = trans.z;
            
            foreach (GameObject obj in detections)
            {
                Transform obj1 = obj.transform.GetChild(0);
                Transform obj2 = obj.transform.GetChild(1);

                float zMax = obj1.transform.position.z;
                float zMin = obj2.transform.position.z;

                float zMid = (zMax + zMin) / 2;

                if(zCoord > zMid && zCoord < zMax)
                {
                    // activate 1
                    
                    currFreeLook.Priority = 15;
                    return;
                }
                else
                {
                    // activate 2
                    return;
                }


            }

        }
    }

    void SetCurrent(CinemachineFreeLook setFreeLook)
    {
        if(currFreeLook != setFreeLook)
        {
            currFreeLook.Priority = 10;
            setFreeLook.Priority = 15;
        }
    }
}
