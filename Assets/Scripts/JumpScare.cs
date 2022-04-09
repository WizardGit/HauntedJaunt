using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class JumpScare : MonoBehaviour
{
    public GameObject player;
    public VideoPlayer video;
    public CanvasGroup can;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            // Here we, make sure the video canvas is opaque, then we can play our video!
            can.alpha = 1;
            video.Play();            
        }
    }
    void Update()
    {
        // Once our video has finished playing, we need to set our canvas to transparent again
        if (video.isPlaying == false)
            can.alpha = 0;
    }
}
