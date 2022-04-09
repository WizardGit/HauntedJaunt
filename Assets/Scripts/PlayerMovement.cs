using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class PlayerMovement : MonoBehaviour
{
    public float turnSpeed = 20f;
    public TextMeshProUGUI displayPos;
    Vector3 ending;

    public Transform ghost0;
    public Transform ghost1;
    public Transform ghost2;
    public Transform ghost3;
    public AudioSource alarm;

    Animator m_Animator;
    Rigidbody m_Rigidbody;
    AudioSource m_AudioSource;
    Vector3 m_Movement;
    Quaternion m_Rotation = Quaternion.identity;
    public float gravityScale = 5;

    // Start is called before the first frame update
    void Start()
    {
        m_Animator = GetComponent<Animator>();
        m_Rigidbody = GetComponent<Rigidbody>();
        m_AudioSource = GetComponent<AudioSource>();

        ending = new Vector3(18f, 0.0f, 1.5f);
        setPosText();
    }

    void setPosText()
    {
        // Let's get the position of each ghost in relation to the player
        Vector3 playerPos = m_Rigidbody.position;
        Vector3 pos0 = playerPos - ghost0.position;
        Vector3 pos1 = playerPos - ghost1.position;
        Vector3 pos2 = playerPos - ghost2.position;
        Vector3 pos3 = playerPos - ghost3.position;

        // Get the distance of x + y (but only the absolute values
        float a = Math.Abs(pos0.x) + Math.Abs(pos0.z);        
        float b = Math.Abs(pos1.x) + Math.Abs(pos1.z);
        float c = Math.Abs(pos2.x) + Math.Abs(pos2.z);
        float d = Math.Abs(pos3.x) + Math.Abs(pos3.z);
        float z = Math.Min(a, b);
        z = Math.Min(z,c);
        z = Math.Min(z,d);

        // These colors will be used for our text, so let's use red for "danger," "white" for safe, and the 50% lerp of both for "warning
        Color red = new Color(1.0f, 0.0f, 0.0f, 1.0f);
        Color white = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        Color pink = Color.Lerp(red, white, 0.5f);

        // If we are in danger or warning, let's change the text color and start the alarm
        if ((z < 3) && (!alarm.isPlaying))
        {            
            alarm.Play();
            displayPos.color = red;
        }
        else if ((z < 5) && (z > 3))
        {
            displayPos.color = pink;
        }
        else if ((z > 5))
        {
            if  (alarm.isPlaying)
            {
                alarm.Stop();
            }            
            displayPos.color = white;
        }
        // Keep regularly updating the stats!
        displayPos.text = "Closest ghost: " + Math.Round(z,2).ToString() + "\nAngle between you and Ending: \n" + Math.Round(Vector3.Dot(playerPos.normalized, ending.normalized),2).ToString();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        m_Movement.Set(horizontal, 0f, vertical);
        m_Movement.Normalize();

        bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);
        bool hasVerticalInput = !Mathf.Approximately(vertical, 0f);

        bool isWalking = hasHorizontalInput || hasVerticalInput;
        m_Animator.SetBool("IsWalking", isWalking);
        if (isWalking)
        {
            if (!m_AudioSource.isPlaying)
            {
                m_AudioSource.Play();
            }            
        }
        else
        {
            m_AudioSource.Stop();   
        }

        Vector3 desiredForward = Vector3.RotateTowards(transform.forward, m_Movement, turnSpeed * Time.deltaTime, 0f);
        m_Rotation = Quaternion.LookRotation(desiredForward);

        setPosText();
    }

    void OnAnimatorMove()
    {
        m_Rigidbody.MovePosition(m_Rigidbody.position + m_Movement * m_Animator.deltaPosition.magnitude);
        m_Rigidbody.MoveRotation(m_Rotation);
    }
}
