using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrawkController : MonoBehaviour
{
    public float eyeBlinkDelay = 5;//how many seconds between eye blinks
    public float mouthMoveDelay = 0.2f;//how many seconds between changing mouth state when frawk is talking

    public Animator eyeAnimator;
    public GameObject mouthSprite;

    //Runtime vars
    private bool talking = false;
    private float lastBlinkTime = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > lastBlinkTime + eyeBlinkDelay)
        {
            eyeAnimator.SetBool("shouldBlink", true);
            lastBlinkTime = Time.time;
        }
        else
        {
            eyeAnimator.SetBool("shouldBlink", false);
        }
    }
}
