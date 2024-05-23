/*
This script toggles the alpha property of the ExitImageBackground when the player passes through the GameEndingTrigger. 
It is a component of the GameEndingTrigger.
- IKA
- May 2, 2024
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
public class GameEnding : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private CanvasGroup exitBackgroundImageCanvasGroup;
    [SerializeField] private CanvasGroup caughtBackgroundImageCanvasGroup;
    [SerializeField] private bool isPlayerCaught;

    private float fadeDuration = 1.0f;
    private float displayImageDuration = 1.0f;
    private float timer;
    private bool isPlayerAtExit;

    void Start()
    {
        fadeDuration = 1.0f;
        displayImageDuration = 1.0f;
    }

    void Update()
    {
        if (isPlayerAtExit)
        {
            EndLevel(exitBackgroundImageCanvasGroup, false);
        }
        else if (isPlayerCaught)
        {
            EndLevel(caughtBackgroundImageCanvasGroup, true);
        }
    }

    void EndLevel(CanvasGroup image, bool restartGame) 
    {
        timer += Time.deltaTime;

        image.alpha = timer / fadeDuration; 

        if (timer > fadeDuration + displayImageDuration)
        {
            if (restartGame) 
            {
                SceneManager.LoadScene(0);
            }
            else 
            {
                Application.Quit();
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            isPlayerAtExit = true;
        }
    }

    
    public void CaughtPlayer()
    {
        isPlayerCaught = true;
    }
}

