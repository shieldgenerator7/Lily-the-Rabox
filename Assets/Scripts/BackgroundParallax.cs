using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Put this on the camera
/// </summary>
public class BackgroundParallax : MonoBehaviour
{
    private List<SpriteRenderer> backgrounds;
    private Dictionary<SpriteRenderer, Vector3> offsets;
    // Start is called before the first frame update
    void Start()
    {
        backgrounds = new List<SpriteRenderer>();
        offsets = new Dictionary<SpriteRenderer, Vector3>();
        foreach (SpriteRenderer sr in FindObjectsOfType<SpriteRenderer>())
        {
            if (sr.sortingLayerName.Contains("Background")
                || sr.sortingLayerName == "Foreground")
            {
                backgrounds.Add(sr);
                offsets.Add(sr, sr.transform.position - transform.position);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach (SpriteRenderer sr in backgrounds)
        {
            sr.transform.position = (transform.position * (-1 * sr.sortingOrder) / 100) + offsets[sr];
        }
    }
}
