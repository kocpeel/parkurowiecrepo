using UnityEngine;

public class Ladder : MonoBehaviour
{
    public bool isPlayerOnLadder = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerOnLadder = true; 
        }

        if (other.CompareTag("coin"))
        {
            Destroy(gameObject); 
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerOnLadder = false; 
        }
    }
}



