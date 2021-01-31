﻿using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Collider))]
public class TowerUp : MonoBehaviour
{
    public Transform fromUpPos;
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            other.transform.position = fromUpPos.position;
            Tower.GoUp();
        }
    }
}
