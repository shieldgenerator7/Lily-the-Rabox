using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransition : MonoBehaviour
{
    public string nextLevelName;

    private bool transitioning = false;
    private GameObject playerObject;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void Update()
    {
        if (transitioning)
        {
            if (!playerObject.GetComponent<Renderer>().isVisible)
            {
                SceneManager.LoadScene(nextLevelName);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<CameraController>().setFollowTarget(null, true);
            playerObject = collision.gameObject;
            playerObject.GetComponent<PlayerController>().overrideControls(false, Vector2.right);
            transitioning = true;
        }
    }
}
