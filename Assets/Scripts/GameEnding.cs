/*
This script toggles the alpha property of the ExitImageBackground when the player passes through the GameEndingTrigger. 
It is a component of the GameEndingTrigger.
- IKA
- May 2, 2024
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnding : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private CanvasGroup exitBackgroundImageCanvasGroup;

    // Additional fields
    private float fadeDuration = 1.0f;
    private float displayImageDuration = 1.0f;
    private float timer;
    private bool isPlayerAtExit;

    // Start is called before the first frame update
    void Start()
    {
        fadeDuration = 1.0f;
        displayImageDuration = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerAtExit)
        {
            EndLevel();
        }
    }

    void EndLevel()
    {
        timer += Time.deltaTime;

        exitBackgroundImageCanvasGroup.alpha = timer / fadeDuration;

        if (timer > fadeDuration + displayImageDuration)
        {
            Application.Quit();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            isPlayerAtExit = true;
        }
    }
}
