using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Put this on the camera
/// </summary>
public class BackgroundParallax : MonoBehaviour
{
    private Vector3 originalPosition;
    private List<SpriteRenderer> backgrounds;
    private Dictionary<SpriteRenderer, Vector3> originalPositions;
    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.position;
        backgrounds = new List<SpriteRenderer>();
        originalPositions = new Dictionary<SpriteRenderer, Vector3>();
        foreach (SpriteRenderer sr in FindObjectsOfType<SpriteRenderer>())
        {
            if (sr.sortingLayerName.Contains("Background")
                || sr.sortingLayerName == "Foreground")
            {
                backgrounds.Add(sr);
                originalPositions.Add(sr, sr.transform.position);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = (transform.position - originalPosition);
        foreach (SpriteRenderer sr in backgrounds)
        {
            sr.transform.position = (dir * (-1 * sr.sortingOrder) / 100) + originalPositions[sr];
        }
    }
}
