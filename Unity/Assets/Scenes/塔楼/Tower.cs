using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class Tower : MonoBehaviour
{
    private static Tower instance;
    public GameObject[] floors = new GameObject[5];

    public static int floor;
    private void Awake()
    {
        if(instance != null)
            instance = this;
        switch(Player.lastScene)
        {
            case "阴暗森林":
                floor = 1;
                break;
            case "监狱":
                floor = 3;
                break;
            case "MainRoom":
                floor = 2;
                break;
            default:
                floor = 0;
                break;
        }
        instance.floors[floor].SetActive(true);
    }
    public static void GoUp()
    {
        instance.floors[floor].SetActive(false);
        floor = floor == 4 ? 0 : floor + 1;
        instance.floors[floor].SetActive(true);
    }
    public static void GoDown()
    {
        instance.floors[floor].SetActive(false);
        floor = floor == 0 ? 4 : floor - 1;
        instance.floors[floor].SetActive(true);
    }
}
