using UnityEngine;

public class PlayerLadderController : MonoBehaviour
{
    public float climbSpeed = 3f; // Prêdkoœæ wspinania
    private Ladder ladder; // Odwo³anie do drabiny
    private bool isClimbing = false; // Flaga, czy gracz wspina siê po drabinie
    private bool isOnLadder = false; // Flaga, czy gracz jest na drabinie

    void Update()
    {
        // Sprawdzamy, czy gracz jest na drabinie i trzyma klawisz "E"
        if (isOnLadder && Input.GetKey(KeyCode.E))
        {
            isClimbing = true;
        }
        else
        {
            isClimbing = false;
        }

        // Jeœli gracz wspina siê, poruszamy go w górê
        if (isClimbing)
        {
            float verticalInput = Input.GetAxis("Vertical"); // Sprawdzamy wejœcie w górê/dó³
            if (verticalInput > 0) // Jeœli trzymamy "W" lub odpowiedni przycisk (do góry)
            {
                transform.Translate(Vector3.up * verticalInput * climbSpeed * Time.deltaTime);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Kiedy gracz wchodzi w strefê drabiny
        if (other.CompareTag("Ladder"))
        {
            ladder = other.GetComponent<Ladder>(); // £¹czymy z obiektem drabiny
            isOnLadder = true; // Gracz wszed³ na drabinê
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Kiedy gracz wychodzi ze strefy drabiny
        if (other.CompareTag("Ladder"))
        {
            ladder = null; // Usuwamy referencjê do drabiny
            isOnLadder = false; // Gracz opuœci³ drabinê
        }
    }
}
