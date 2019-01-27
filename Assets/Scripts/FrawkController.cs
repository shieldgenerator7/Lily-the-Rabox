using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrawkController : MonoBehaviour
{
    public float eyeBlinkDelay = 5;//how many seconds between eye blinks
    public float mouthMoveDelay = 0.2f;//how many seconds between changing mouth state when frawk is talking

    public Animator eyeAnimator;
    public GameObject mouthSprite;
    private List<EyeController> eyes = new List<EyeController>();

    //Runtime vars
    private float lastBlinkTime = 0;
    public bool talking = false;
    private float lastMouthMoveTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<NPCVoiceLines>().onVoiceLineActivate += startTalking;
        foreach (EyeController eye in GetComponentsInChildren<EyeController>())
        {
            eyes.Add(eye);
        }
        //Get player, if exists
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player)
        {
            foreach (EyeController eye in eyes)
            {
                eye.trackObject(player);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Blinking
        if (Time.time > lastBlinkTime + eyeBlinkDelay)
        {
            eyeAnimator.SetBool("shouldBlink", true);
            lastBlinkTime = Time.time;
        }
        else
        {
            eyeAnimator.SetBool("shouldBlink", false);
        }
        //Talking
        if (talking)
        {
            if (Time.time > lastMouthMoveTime + mouthMoveDelay)
            {
                mouthSprite.SetActive(!mouthSprite.activeSelf);
                lastMouthMoveTime = Time.time;
            }
        }
    }

    public void startTalking(bool talking)
    {
        this.talking = talking;
        mouthSprite.SetActive(talking);
        lastMouthMoveTime = Time.time;
        //Get player, if exists
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player)
        {
            foreach (EyeController eye in eyes)
            {
                eye.trackObject(player);
            }
        }
    }
}
