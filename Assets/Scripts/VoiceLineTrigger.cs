using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceLineTrigger : MonoBehaviour
{
    public NPCVoiceLines voiceBox;
    public List<int> voiceLineIndices = new List<int>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            int voiceLineIndex = voiceLineIndices[Random.Range(0, voiceLineIndices.Count)];
            voiceBox.playVoiceLine(voiceLineIndex);
            Destroy(gameObject);
        }
    }
}
