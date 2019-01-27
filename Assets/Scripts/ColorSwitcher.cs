using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSwitcher : MonoBehaviour
{
    public List<Color> colors = new List<Color>();
    public int startingColor = 0;
    public float duration = 2;

    private int curColor = 0;
    private float lastColorChangeTime = 0;

    private SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        curColor = startingColor % colors.Count;
        sr.color = colors[curColor];
        lastColorChangeTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > lastColorChangeTime + duration)
        {
            lastColorChangeTime = Time.time;
            curColor--;
            curColor = (curColor+ colors.Count) % colors.Count;
            sr.color = colors[curColor];
        }
    }
}
