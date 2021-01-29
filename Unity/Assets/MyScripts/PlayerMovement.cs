﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float m_Speed = 12f;
    public AudioSource m_MovementAudio;

    private string m_HorizontalMovementAxisName;
    private string m_VerticalMovementAxisName;
    private Rigidbody m_Rigidbody;
    public float m_HorizontalMovementInputValue;
    public float m_VerticalMovementInputValue;
    private Vector3 movementDirection;
    public float m_RaycastRange = 50f;
    private GameObject lastHitWall;

    private void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }


    private void OnEnable()
    {
        m_Rigidbody.isKinematic = false;
        m_HorizontalMovementInputValue = 0f;
        m_VerticalMovementInputValue = 0f;
    }


    private void OnDisable()
    {
        m_Rigidbody.isKinematic = true;
    }


    private void Start()
    {
        m_HorizontalMovementAxisName = "Vertical";
        m_VerticalMovementAxisName = "Horizontal";
    }


    private void Update()
    {
        // Store the player's input and make sure the audio for the movement is playing.

        m_HorizontalMovementInputValue = Input.GetAxis(m_HorizontalMovementAxisName);
        m_VerticalMovementInputValue = Input.GetAxis(m_VerticalMovementAxisName);

        MovementAudio();

    }


    private void MovementAudio()
    {
        // Play the correct audio clip based on whether or not the player is moving and what audio is currently playing.

        // Checks if the player is moving
        if (!CheckMovement())
        {
            m_MovementAudio.Stop();
        }
        else
        {
            if (!m_MovementAudio.isPlaying)
            {
                m_MovementAudio.Play();

            }

        }
    }


    private void FixedUpdate()
    {
        // Move and turn the player.

        Move();
        Turn();
        Raycast();
    }


    private void Move()
    {
        // Adjust the position of the player based on the player's input.
        if (CheckMovement())
        {
            movementDirection = m_Rigidbody.position + (Vector3.forward * m_HorizontalMovementInputValue + Vector3.right * m_VerticalMovementInputValue) * m_Speed * Time.deltaTime;

            m_Rigidbody.MovePosition(movementDirection);
        }



    }


    private void Turn()
    {
        if (CheckMovement())
        {
            transform.LookAt(movementDirection);
        }
    }

    private void Raycast()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.forward, out hit, m_RaycastRange))
        {
            if(lastHitWall == null)
            {
                lastHitWall = hit.transform.gameObject;
                lastHitWall.GetComponent<MainRoomsWall>().hit = true;
            }

            if(hit.transform.gameObject != lastHitWall)
            {
                lastHitWall.GetComponent<MainRoomsWall>().hit = false;
                lastHitWall = hit.transform.gameObject;
                lastHitWall.GetComponent<MainRoomsWall>().hit = true;
            }

        }
    }

    private bool CheckMovement()
    {
        if (Mathf.Abs(m_HorizontalMovementInputValue) > 0.0f || Mathf.Abs(m_VerticalMovementInputValue) > 0.0f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


   
}
