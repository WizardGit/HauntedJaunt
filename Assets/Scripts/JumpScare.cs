using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class JumpScare : MonoBehaviour
{
    public GameObject player;
    bool m_IsPlayerAtScare;
    public VideoPlayer video;
    public CanvasGroup can;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            m_IsPlayerAtScare = true;
        }
    }
    void Update()
    {
        if (m_IsPlayerAtScare)
        {
            can.alpha = 1;
            video.Play();
        }
    }
}
