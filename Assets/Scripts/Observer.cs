using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{
    [SerializeField] private Transform player; 
    [SerializeField] private GameEnding gameEnding; 
    [SerializeField] private bool isPlayerInRange; 

    
    void Update()
    {
        CanGargoyleSeePlayer(); 
    }

    
    private void CanGargoyleSeePlayer()
    {
        if (isPlayerInRange)
        {
            Vector3 direction = player.position - transform.position + Vector3.up;
            Ray ray = new Ray(transform.position, direction);
            RaycastHit raycastHit;

            if (Physics.Raycast(ray, out raycastHit))
            {
                if (raycastHit.collider.transform == player)
                {
                    gameEnding.CaughtPlayer();
                }
            }
        }
    }

    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player.gameObject)
        {
            isPlayerInRange = true;
        }
    }

   
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player.gameObject)
        {
            isPlayerInRange = false;
        }
    }
}
