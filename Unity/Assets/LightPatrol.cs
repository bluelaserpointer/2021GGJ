using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightPatrol : MonoBehaviour
{
    public float patrolSpeed;
    public float lerpOffset;
    List<Vector3> patrolPositions;
    int currPosIdx = 0;
    // Start is called before the first frame update
    void Start()
    {
        patrolPositions = new List<Vector3>();

        int childCount = transform.childCount;
        for(int i = 0; i < childCount; i++)
        {
            Transform child = transform.GetChild(i);
            Debug.Log(child.name);

            patrolPositions.Add(child.position);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, patrolPositions[currPosIdx], patrolSpeed * Time.deltaTime);
        if(Vector3.Distance(transform.position, patrolPositions[currPosIdx]) < lerpOffset)
        {
            currPosIdx++;
            if(currPosIdx == patrolPositions.Count)
                currPosIdx = 0;
        }
    }
}
