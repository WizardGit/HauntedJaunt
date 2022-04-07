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
            can.alpha = 1;
            video.Play();            
        }
    }
    void Update()
    {
        if (video.isPlaying == false)
            can.alpha = 0;
    }
}
