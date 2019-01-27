using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCVoiceLines : MonoBehaviour
{
    public List<string> voiceTexts = new List<string>();

    public List<AudioClip> voiceLines = new List<AudioClip>();

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (audioSource.clip != null)
        {
            if (audioSource.isPlaying)
            {
            }
            else
            {
                audioSource.clip = null;
                if (onVoiceLineActivate != null)
                {
                    onVoiceLineActivate(false);
                }
            }
        }
    }

    public void playVoiceLine(int index)
    {
        audioSource.clip = voiceLines[index];
        audioSource.Play();
        if (onVoiceLineActivate != null)
        {
            onVoiceLineActivate(true);
        }
    }

    public delegate void OnVoiceLineActivate(bool activate);
    public OnVoiceLineActivate onVoiceLineActivate;
}
