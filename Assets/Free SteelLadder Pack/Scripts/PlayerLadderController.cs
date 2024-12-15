using UnityEngine;

public class PlayerLadderController : MonoBehaviour
{
    public float climbSpeed = 3f; // Pr�dko�� wspinania
    private Ladder ladder; // Odwo�anie do drabiny
    private bool isClimbing = false; // Flaga, czy gracz wspina si� po drabinie
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

        // Je�li gracz wspina si�, poruszamy go w g�r�
        if (isClimbing)
        {
            float verticalInput = Input.GetAxis("Vertical"); // Sprawdzamy wej�cie w g�r�/d�
            if (verticalInput > 0) // Je�li trzymamy "W" lub odpowiedni przycisk (do g�ry)
            {
                transform.Translate(Vector3.up * verticalInput * climbSpeed * Time.deltaTime);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Kiedy gracz wchodzi w stref� drabiny
        if (other.CompareTag("Ladder"))
        {
            ladder = other.GetComponent<Ladder>(); // ��czymy z obiektem drabiny
            isOnLadder = true; // Gracz wszed� na drabin�
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Kiedy gracz wychodzi ze strefy drabiny
        if (other.CompareTag("Ladder"))
        {
            ladder = null; // Usuwamy referencj� do drabiny
            isOnLadder = false; // Gracz opu�ci� drabin�
        }
    }
}
