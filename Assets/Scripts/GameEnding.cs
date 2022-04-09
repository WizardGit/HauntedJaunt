using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameEnding : MonoBehaviour
{
    public float displayImageDuration = 1f;
    public float fadeDuration = 1f;
    public GameObject player;
    bool m_IsPlayerAtExit;
    bool m_IsPlayerCaught;    

    float m_Timer;
    bool m_HasAudioPlayed;
    public TextMeshProUGUI displayPos;
    public CanvasGroup exitBackgroundImageCanvasGroup;
    public AudioSource exitAudio;
    public CanvasGroup caughtBackgroundImageCanvasGroup;
    public AudioSource caughtAudio;
    public AudioSource alarm;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            m_IsPlayerAtExit = true;
        }
    }

    public void CaughtPlayer()
    {
        m_IsPlayerCaught = true;
    }

    void Update()
    {
        if (m_IsPlayerAtExit)
        {
            // If we reach the end, we need to end the game but also stop the alarm and get rid of the displayed text
            displayPos.text = " ";
            alarm.Stop();
            EndLevel(exitBackgroundImageCanvasGroup, false, exitAudio);
        }
        else if (m_IsPlayerCaught)
        {
            // If we get caught, we need to restart the level but also stop the alarm and get rid of the displayed text during the image display
            displayPos.text = " ";
            alarm.Stop();
            EndLevel(caughtBackgroundImageCanvasGroup, true, caughtAudio);
        }
    }
    void EndLevel(CanvasGroup imageCanvasGroup, bool doRestart, AudioSource audioSource)
    {
        if (!m_HasAudioPlayed)
        {
            audioSource.Play();
            m_HasAudioPlayed = true;
        }
        m_Timer += Time.deltaTime;
        imageCanvasGroup.alpha = m_Timer / fadeDuration;

        if (m_Timer > fadeDuration + displayImageDuration)
        {
            if (doRestart)
            {
                SceneManager.LoadScene(0);
            }
            else
            {
                Application.Quit();
            }
        }
    }
}
