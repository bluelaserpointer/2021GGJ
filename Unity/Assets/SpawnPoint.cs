using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public string fromScene;


    void Start()
    {
        if (fromScene == Player.lastScene)
        {
            Instantiate(Resources.Load("PlayerVer1"), transform, false);
        }
    }
}
