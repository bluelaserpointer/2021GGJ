using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float m_Speed = 12f;
    public float m_TurnSpeed = 180f;
    public AudioSource m_MovementAudio;
    public AudioClip m_MovementClip;
    public float m_PitchRange = 0.2f;


    private string m_HorizontalMovementAxisName;
    private string m_VerticalMovementAxisName;
    private Rigidbody m_Rigidbody;
    private float m_HorizontalMovementInputValue;
    private float m_VerticalMovementInputValue;
    private float m_OriginalPitch;


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

        m_OriginalPitch = m_MovementAudio.pitch;
    }


    private void Update()
    {
        // Store the player's input and make sure the audio for the movement is playing.

        m_HorizontalMovementInputValue = Input.GetAxis(m_HorizontalMovementAxisName);
        m_VerticalMovementInputValue = Input.GetAxis(m_VerticalMovementAxisName);

        Debug.Log("Audio is playing " + m_MovementAudio.isPlaying);

        MovementAudio();

    }


    private void MovementAudio()
    {
        // Play the correct audio clip based on whether or not the player is moving and what audio is currently playing.

        // Checks if the player is moving
        if (Mathf.Abs(m_HorizontalMovementInputValue) < 0.1f && Mathf.Abs(m_VerticalMovementInputValue) < 0.1f)
        {
            Debug.Log("Player is not moving");
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
    }


    private void Move()
    {
        // Adjust the position of the player based on the player's input.
        Vector3 movement = (transform.forward * m_HorizontalMovementInputValue + transform.right * m_VerticalMovementInputValue) * m_Speed * Time.deltaTime;

        m_Rigidbody.MovePosition(m_Rigidbody.position + movement);


    }


    private void Turn()
    {
        // Adjust the rotation of the player based on the player's input.

        float turn = m_VerticalMovementInputValue * m_TurnSpeed * Time.deltaTime;

        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);

        m_Rigidbody.MoveRotation(m_Rigidbody.rotation * turnRotation);
    }
}
